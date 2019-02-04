﻿using System.Collections.Generic;

namespace Randomizer
{
	/// <summary>
	/// A class to track information about the room's bundles
	/// </summary>
	public class RoomInformation
	{
		public CommunityCenterRooms Room { get; set; }
		public List<Bundle> Bundles { get; set; }
		public int StartingIndex { get; set; }
		public int EndingIndex { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="room">The room</param>
		/// <param name="startingIndex">The room ID to start at</param>
		/// <param name="endingIndex">The index to end at</param>
		public RoomInformation(CommunityCenterRooms room, int startingIndex, int endingIndex)
		{
			Room = room;
			StartingIndex = startingIndex;
			EndingIndex = endingIndex;
		}
	}

	/// <summary>
	/// Randomizes community center bundles
	/// </summary>
	public class BundleRandomizer
	{
		/// <summary>
		/// Information about all the rooms
		/// </summary>
		public static List<RoomInformation> Rooms = new List<RoomInformation>
		{
			//new RoomInformation(CommunityCenterRooms.Pantry, 0, 5),
			//new RoomInformation(CommunityCenterRooms.FishTank, 6, 11),
			new RoomInformation(CommunityCenterRooms.CraftsRoom, 13, 19), // skip 18
			//new RoomInformation(CommunityCenterRooms.BoilerRoom, 20, 22),
			//new RoomInformation(CommunityCenterRooms.Vault, 23, 26),
			//new RoomInformation(CommunityCenterRooms.BulletinBoard, 31, 35),
		};

		private static Dictionary<string, string> _randomizedBundles = new Dictionary<string, string>();

		//TODO: list of ids for bundle types used

		/// <summary>
		/// The randomizing function
		/// </summary>
		/// <returns>A dictionary of bundles to their output string</returns>
		public static Dictionary<string, string> Randomize()
		{
			foreach (RoomInformation room in Rooms)
			{
				CreateBundlesForRoom(room);
			}

			return _randomizedBundles;
		}

		/// <summary>
		/// Creates the bundles for the room
		/// </summary>
		/// <param name="room">The room to create bundles for</param>
		private static void CreateBundlesForRoom(RoomInformation room)
		{
			if (room.StartingIndex > room.EndingIndex)
			{
				Globals.ConsoleWrite("ERROR: Community center room information does not have correct indexes defined.");
				return;
			}

			List<Bundle> bundles = new List<Bundle>();
			List<BundleTypes> bundleTypesUsed = new List<BundleTypes>();
			for (int i = room.StartingIndex; i < room.EndingIndex + 1; i++)
			{
				if (i == 18) { continue; } // That's just how this is set up
				Bundle bundle = CreateBundleForRoom(room.Room, i, bundleTypesUsed);
				bundleTypesUsed.Add(bundle.BundleType);
			}
		}

		/// <summary>
		/// Creates a random bundle for the given room
		/// </summary>
		/// <param name="room">The room to create the bundle for</param>
		/// <param name="roomId">The room id</param>
		/// <param name="bundleTypesUsed">The bundle types already used</param>
		/// <returns>The created bundle</returns>
		private static Bundle CreateBundleForRoom(CommunityCenterRooms room, int roomId, List<BundleTypes> bundleTypesUsed)
		{
			Bundle bundle = new Bundle(room, roomId, bundleTypesUsed);
			_randomizedBundles[bundle.Key] = bundle.ToString();
			return bundle;
		}
	}
}

