using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Archipelago.Definitions;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Exceptions;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;
using StardewModdingAPI;
using StardewValley;
using WebSocketSharp;

namespace Archipelago
{
    public class Client
    {
        public const int    MAXIMUM_RECONNECTION_ATTEMPTS = 3;
        public const string MINIMUM_AP_VERSION            = "0.3.3";

        /// <summary>An arbitrary number which identifies messages from Archipelago.</summary>
        private const int MESSAGE_ID = 91193225;

        private bool                            _allowReconnect;
        private DeathLinkService                _deathLinkService;
        private Dictionary<string, Permissions> _permissions = new();
        private int                             _reconnectionAttempt;
        private string                          _seed = "0";
        private ArchipelagoSession              _session;
        private List<string>                    _tags         = new() { "AP" };
        private DateTime                        _lastChatSent = DateTime.Now;

        private readonly IMonitor               _monitor;

        public Client(IMonitor monitor)
        {
            _monitor = monitor;
            Initialize();
        }

        public ConnectionStatus               ConnectionStatus        { get; private set; } = ConnectionStatus.Disconnected;
        public DateTime                       LastDeath               { get; private set; } = DateTime.MinValue;
        public ConnectionInfo                 CachedConnectionInfo    { get; private set; } = new();
        public DeathLink                      DeathLink               { get; private set; }
        public Dictionary<long, NetworkItem>  LocationCache           { get; private set; } = new();
        public SlotData                       Data                    { get; private set; }
        public Queue<NetworkItem>             ItemQueue               { get; private set; } = new();
        public List<long>                     CheckedLocations        { get; private set; } = new();
        public Queue<Tuple<string, ChatType>> IncomingChatQueue       { get; private set; } = new();
        public bool                           CheckedLocationsUpdated { get; set; }
        public bool                           StopReceivingItems      { get; set; }
        public bool                           CanForfeit              => _permissions["forfeit"] is Permissions.Goal or Permissions.Enabled;
        public bool                           CanCollect              => _permissions["collect"] is Permissions.Goal or Permissions.Enabled;

        public void Connect(ConnectionInfo info)
        {
            // Cache our connection info in case we get disconnected later.
            CachedConnectionInfo = info;

            // Disconnect from any session we are currently in if we are attempting to connect.
            if (_session != null)
            {
                Disconnect();
            }

            ConnectionStatus = ConnectionStatus.Connecting;
            try
            {
                _session = ArchipelagoSessionFactory.CreateSession(info.Hostname, info.Port);

                // Establish event handlers.
                _session.Socket.SocketClosed += OnSocketDisconnect;
                _session.Socket.ErrorReceived += OnError;
                _session.Items.ItemReceived += OnReceivedItems;
                _session.Socket.PacketReceived += OnPacketReceived;

                // Attempt to connect to the AP server.
                var result = _session.TryConnectAndLogin(
                    "Stardew Valley",
                    info.Name,
                    new Version(MINIMUM_AP_VERSION),
                    ItemsHandlingFlags.AllItems,
                    _tags.ToArray(),
                    password: info.Password
                );

                if (result.Successful)
                {
                    _reconnectionAttempt = 0;
                    return;
                }

                var failure = (LoginFailure) result;
                throw new ArchipelagoSocketClosedException(failure.Errors[0]);
            }
            catch
            {
                Disconnect();
                throw;
            }
        }

        public void Disconnect()
        {
            ConnectionStatus = ConnectionStatus.Disconnecting;

            // Clear DeathLink handlers.
            if (_deathLinkService != null)
            {
                _deathLinkService.OnDeathLinkReceived -= OnDeathLink;
            }

            // Clear session handlers.
            if (_session != null)
            {
                _session.Socket.SocketClosed -= OnSocketDisconnect;
                _session.Socket.ErrorReceived -= OnError;
                _session.Items.ItemReceived -= OnReceivedItems;
                _session.Socket.PacketReceived -= OnPacketReceived;
                _session.Socket.Disconnect();
            }

            // Reset all values back to their defaults.
            Initialize();
        }

        private void Initialize()
        {
            _session = null;
            _deathLinkService = null;
            _permissions = new Dictionary<string, Permissions>();
            _tags = new List<string> { "AP" };
            _allowReconnect = true;
            _reconnectionAttempt = 0;
            _seed = "0";

            ConnectionStatus = ConnectionStatus.Disconnected;
            CheckedLocations = new List<long>();
            LastDeath = DateTime.MinValue;
            DeathLink = null;
            LocationCache = new Dictionary<long, NetworkItem>();
            StopReceivingItems = false;
            Data = null;
            ItemQueue = new Queue<NetworkItem>();
        }

        public void Forfeit()
        {
            // Not sure if there's a better way to do this, but I know this works!
            _session.Socket.SendPacket(new SayPacket { Text = "!forfeit" });
        }

        public void Collect()
        {
            // Not sure if there's a better way to do this, but I know this works!
            _session.Socket.SendPacket(new SayPacket { Text = "!collect" });
        }

        public void AnnounceVictory()
        {
            _session.Socket.SendPacket(new StatusUpdatePacket { Status = ArchipelagoClientState.ClientGoal });
            // Stop receiving items so we don't get stuck in a loop at the end.
            StopReceivingItems = true;
        }

        public void ClearDeathLink()
        {
            if (_deathLinkService != null)
            {
                DeathLink = null;
            }
        }

        public void SendDeathLink(string cause)
        {
            // Log our current time so we can make sure we ignore our own DeathLink.
            LastDeath = DateTime.Now;

            if (!Data.DeathLink || _deathLinkService == null)
            {
                return;
            }

            var causeWithPlayerName = $"{_session.Players.GetPlayerAlias(Data.Slot)}'s {cause}.";
            _deathLinkService.SendDeathLink(
                new DeathLink(_session.Players.GetPlayerAlias(Data.Slot), causeWithPlayerName)
                    { Timestamp = LastDeath });
        }

        public void CheckLocations(params long[] locations)
        {
            _session.Locations.CompleteLocationChecks(locations);
        }

        public string GetPlayerName(int slot)
        {
            var name = _session.Players.GetPlayerAlias(slot);
            return string.IsNullOrEmpty(name) ? "Archipelago" : name;
        }

        public string GetItemName(int item)
        {
            var name = _session.Items.GetItemName(item);
            return string.IsNullOrEmpty(name) ? "Unknown Item" : name;
        }

        public string GetLocationName(int location)
        {
            var name = _session.Locations.GetLocationNameFromId(location);
            return string.IsNullOrEmpty(name) ? "Unknown Location" : name;
        }

        public void Chat(string message)
        {
            if (_lastChatSent.AddSeconds(1) < DateTime.Now)
            {
                _session.Socket.SendPacket(new SayPacket
                {
                    Text = message
                });

                _lastChatSent = DateTime.Now;
            }
        }

        private void OnSocketDisconnect(CloseEventArgs closeEventArgs)
        {
            // Check to see if we are still in a game, and attempt to reconnect if possible.
            switch (ConnectionStatus)
            {
                // We were failing to connect.
                case ConnectionStatus.Connecting:
                    Game1.hudMessages.RemoveAll(p => p.number == MESSAGE_ID);
                    Game1.addHUDMessage(new HUDMessage("Lost connection to AP Server...", HUDMessage.error_type) { noIcon = true, number = MESSAGE_ID });
                    _monitor.Log("Lost connection to AP Server...", StardewModdingAPI.LogLevel.Info);
                    break;

                // We're in a current game and lost connection, so attempt to reconnect gracefully.
                case ConnectionStatus.Connected:
                    _allowReconnect = true;

                    // Ignore this is a goto. Thanks for playing.
                    goto case ConnectionStatus.Connecting;
            }
        }

        private void OnReceivedItems(ReceivedItemsHelper helper)
        {
            var item = helper.DequeueItem();
            ItemQueue.Enqueue(item);

            if (Game1.PlayerStats.CheckReceived(item) && item.Player != Data.Slot)
            {
                var text = $"You received {GetItemName(item.Item)} from {GetPlayerName(item.Player)} ({GetLocationName(item.Location)})";
                IncomingChatQueue.Enqueue(new (text, ChatType.Item));
            }
        }

        private void OnDeathLink(DeathLink deathLink)
        {
            var newDeathLink = deathLink.Timestamp.ToString(CultureInfo.InvariantCulture);
            var oldDeathLink = LastDeath.ToString(CultureInfo.InvariantCulture);

            // Ignore deaths that died at the same time as us. Should also prevent the player from dying to themselves.
            if (newDeathLink != oldDeathLink)
            {
                DeathLink = deathLink;
            }
        }

        private void OnPacketReceived(ArchipelagoPacketBase packet)
        {
            _monitor.Log($"Received a {packet.GetType().Name} packet");
            _monitor.Log("==========================================");
            foreach (var property in packet.GetType().GetProperties())
                _monitor.Log($"{property.Name}: {property.GetValue(packet, null)}");

            _monitor.Log("");

            switch (packet)
            {
                case RoomUpdatePacket roomUpdatePacket:
                    OnRoomUpdate(roomUpdatePacket);
                    break;

                case RoomInfoPacket roomInfoPacket:
                    OnRoomInfo(roomInfoPacket);
                    break;

                case ConnectedPacket connectedPacket:
                    OnConnected(connectedPacket);
                    break;

                case PrintPacket printPacket:
                    OnPrint(printPacket);
                    break;

                case PrintJsonPacket printJsonPacket:
                    OnJsonPrint(printJsonPacket);
                    break;
            }
        }

        private void OnRoomInfo(RoomInfoPacket packet)
        {
            _seed = packet.SeedName;
            _permissions = packet.Permissions;

            // Send this so we have a cache of item/location names.
            _session.Socket.SendPacket(new GetDataPackagePacket());
        }

        private void OnRoomUpdate(RoomUpdatePacket packet)
        {
            foreach (var location in packet.CheckedLocations)
                if (!CheckedLocations.Contains(location))
                {
                    CheckedLocations.Add(location);
                    CheckedLocationsUpdated = true;
                }
        }

        private void OnConnected(ConnectedPacket packet)
        {
            Data = new SlotData(packet.SlotData, _seed, packet.Slot, CachedConnectionInfo.Name);

            // Check if DeathLink is enabled and establish the appropriate helper.
            if (Data.DeathLink)
            {
                _tags.Add("DeathLink");
                _session.UpdateConnectionOptions(_tags.ToArray(), ItemsHandlingFlags.AllItems);

                // Clear old DeathLink handlers.
                if (_deathLinkService != null)
                {
                    _deathLinkService.OnDeathLinkReceived -= OnDeathLink;
                }

                _deathLinkService = _session.CreateDeathLinkServiceAndEnable();
                _deathLinkService.OnDeathLinkReceived += OnDeathLink;
            }

            // Mark our checked locations.
            CheckedLocations = packet.LocationsChecked.ToList();

            // Build our location cache.
            var locations = LocationDefinitions.GetAllLocations(Data).Select(location => (long) location.Code).ToArray();
            _session.Locations.ScoutLocationsAsync(OnReceiveLocationCache, locations.ToArray());

            // Set ourselves to connected.
            ConnectionStatus = ConnectionStatus.Connected;
        }

        private void OnReceiveLocationCache(LocationInfoPacket packet)
        {
            foreach (var item in packet.Locations) LocationCache.Add(item.Location, item);
        }

        private void OnError(Exception exception, string message)
        {
            _monitor.Log(string.Format("Received an unhandled exception in ArchipelagoClient: {0}\n\n{1}", message, exception));
        }

        private void OnPrint(PrintPacket packet)
        {
            _monitor.Log(string.Format("AP Server: {0}", packet.Text));
            IncomingChatQueue.Enqueue(new (packet.Text, ChatType.Normal));
        }

        private void OnJsonPrint(PrintJsonPacket packet)
        {
            var text = new StringBuilder();
            var type = packet.MessageType switch
            {
                JsonMessageType.Hint     => ChatType.Hint,
                _                        => ChatType.Normal
            };

            if (packet.MessageType == JsonMessageType.ItemSend)
            {
                type = ChatType.Item;
            }

            foreach (var element in packet.Data)
            {
                string substring = element.Type switch
                {
                    JsonMessagePartType.PlayerId => GetPlayerName(int.Parse(element.Text)),
                    JsonMessagePartType.ItemId => GetItemName(int.Parse(element.Text)),
                    JsonMessagePartType.LocationId => GetLocationName(int.Parse(element.Text)),
                    _ => element.Text,
                };
                text.Append(substring);
            }

            IncomingChatQueue.Enqueue(new (text.ToString(), type));
        }
    }

    public enum ChatType
    {
        Normal,
        Item,
        Hint
    }
}
