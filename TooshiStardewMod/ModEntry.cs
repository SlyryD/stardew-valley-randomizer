﻿using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Randomizer
{
	/// <summary>The mod entry point</summary>
	public class ModEntry : Mod
	{
		public static Dictionary<string, bool> configDict;

		public PossibleSwap[] PossibleSwaps = {
			new PossibleSwap("Pierre", "Lewis"),
			new PossibleSwap("Wizard", "Sandy"),
			new PossibleSwap("Willy", "Pam"),
			new PossibleSwap("Abigail", "Marnie"),
			new PossibleSwap("MrQi", "Gunther"),
			new PossibleSwap("Marlon", "Governor"),
			new PossibleSwap("Caroline", "Evelyn"),
			new PossibleSwap("Pam", "Haley"),
			new PossibleSwap("Morris", "Krobus"),
			new PossibleSwap("Gus", "Elliott"),
			new PossibleSwap("Linus", "Pam"),
			new PossibleSwap("Kent", "Pierre"),
			new PossibleSwap("Sandy", "Maru"),
			new PossibleSwap("Sebastian", "Wizard"),
			new PossibleSwap("Jas", "Vincent"),
			new PossibleSwap("Krobus", "Dwarf"),
			new PossibleSwap("Leah", "Marnie"),
			new PossibleSwap("Henchman", "Bouncer"),
			new PossibleSwap("Harvey", "Gus"),
			new PossibleSwap("Bouncer", "Gunther"),
			new PossibleSwap("Gunther", "Governor"),
			new PossibleSwap("Evelyn", "Jodi"),
			new PossibleSwap("George", "Wizard"),
			new PossibleSwap("Emily", "Marnie"),
			new PossibleSwap("Sam", "Linus"),
			new PossibleSwap("Alex", "Gus"),
			new PossibleSwap("Penny", "Sandy"),
			new PossibleSwap("Morris", "Governor"),
			new PossibleSwap("Haley", "Alex"),
			new PossibleSwap("Harvey", "Maru"),
			new PossibleSwap("Abigail", "Sebastian"),
			new PossibleSwap("Penny", "Sam"),
			new PossibleSwap("Leah", "Elliott"),
			new PossibleSwap("Shane", "Emily"),
			new PossibleSwap("Shane", "Pam")
		};

		private AssetLoader _modAssetLoader;
		private AssetEditor _modAssetEditor;

		private IModHelper _helper;

		/// <summary>The mod entry point, called after the mod is first loaded</summary>
		/// <param name="helper">Provides simplified APIs for writing mods</param>
		public override void Entry(IModHelper helper)
		{
			_helper = helper;
			Globals.ModRef = this;

			//config file read in
			string[] config = System.IO.File.ReadAllLines("Mods/Randomizer/RandomizerSettings.txt");
			configDict = new Dictionary<string, bool>();

			foreach (string line in config)
			{
				string[] tokens = line.Split('=');
				if (tokens.Length != 2 || line.Trim().StartsWith("//")) continue;
				configDict.Add(tokens[0].Trim().ToLower(), (tokens[1].Trim().ToLower() == "true"));
			}

			this._modAssetLoader = new AssetLoader(this);
			this._modAssetEditor = new AssetEditor(this);
			helper.Content.AssetLoaders.Add(this._modAssetLoader);
			helper.Content.AssetEditors.Add(this._modAssetEditor);

			this.PreLoadReplacments();
			SaveEvents.AfterLoad += (sender, args) => this.CalculateAllReplacements();

			bool canReplaceMusic = configDict.ContainsKey("music") ? configDict["music"] : true;
			if (canReplaceMusic) { GameEvents.UpdateTick += (sender, args) => this.TryReplaceSong(); }

			bool canReplaceRain = configDict.ContainsKey("rain") ? configDict["rain"] : true;
			if (canReplaceRain) { helper.Events.GameLoop.DayEnding += _modAssetLoader.ReplaceRain; }
		}

		/// <summary>
		/// Loads the replacements that can be loaded before a game is selected
		/// </summary>
		public void PreLoadReplacments()
		{
			this._modAssetLoader.CalculateReplacementsBeforeLoad();
			this._modAssetEditor.CalculateEditsBeforeLoad();
		}

		/// <summary>
		/// Does all the randomizer replacements that take place after a game is loaded
		/// </summary>
		public void CalculateAllReplacements()
		{
			//Seed is pulled from farm name
			byte[] seedvar = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(Game1.player.farmName));
			int seed = BitConverter.ToInt32(seedvar, 0);

			this.Monitor.Log($"Seed Set: {seed}");

			Globals.RNG = new Random(seed);
			Globals.SpoilerLog = new SpoilerLogger(Game1.player.farmName);

			// Make replacements and edits
			this._modAssetLoader.CalculateReplacements();
			this._modAssetEditor.CalculateEdits();
			Globals.SpoilerLog.WriteFile();

			// Invalidate all replaced and edited assets so they are reloaded
			this._modAssetLoader.InvalidateCache();
			this._modAssetEditor.InvalidateCache();

			ChangeDayOneForagables();
			FixParsnipSeedBox();
		}

		/// <summary>
		/// Fixes the foragables on day 1 - the save file is created too quickly for it to be
		/// randomized right away, so we'll change them on the spot on the first day
		/// </summary>
		public void ChangeDayOneForagables()
		{
			// Replace all the foragables on day 1
			SDate currentDate = SDate.Now();
			if (currentDate.DaysSinceStart < 2)
			{
				List<GameLocation> locations = Game1.locations
					.Concat(
						from location in Game1.locations.OfType<BuildableGameLocation>()
						from building in location.buildings
						where building.indoors.Value != null
						select building.indoors.Value
					).ToList();

				List<Item> newForagables =
				ItemList.GetForagables(Seasons.Spring)
					.Where(x => x.ShouldBeForagable) // Removes the 1/1000 items
					.Cast<Item>().ToList();

				foreach (GameLocation location in locations)
				{
					List<int> foragableIds = ItemList.GetForagables().Select(x => x.Id).ToList();
					List<Vector2> tiles = location.Objects.Pairs
						.Where(x => foragableIds.Contains(x.Value.ParentSheetIndex))
						.Select(x => x.Key)
						.ToList();

					foreach (Vector2 oldForagableKey in tiles)
					{
						Item newForagable = Globals.RNGGetRandomValueFromList(newForagables);
						location.Objects[oldForagableKey].ParentSheetIndex = newForagable.Id;
						location.Objects[oldForagableKey].Name = newForagable.Name;
					}
				}
			}
		}

		/// <summary>
		/// Fixes the item name that you get at the start of the game
		/// </summary>
		public void FixParsnipSeedBox()
		{
			GameLocation farmHouse = Game1.locations.Where(x => x.Name == "FarmHouse").First();

			foreach (GameLocation location in Game1.locations)
			{
				List<StardewValley.Objects.Chest> chestsInRoom =
					farmHouse.Objects.Values.Where(x =>
						x.DisplayName == "Chest")
						.Cast<StardewValley.Objects.Chest>()
						.Where(x => x.giftbox)
					.ToList();

				if (chestsInRoom.Count > 0)
				{
					string parsnipSeedsName = ItemList.GetItemName((int)ObjectIndexes.ParsnipSeeds);
					StardewValley.Item itemInChest = chestsInRoom[0].items[0];
					if (itemInChest.Name == "Parsnip Seeds")
					{
						itemInChest.Name = parsnipSeedsName;
						itemInChest.DisplayName = parsnipSeedsName;
					}
				}
			}
		}

		/// <summary>
		/// The last song that played/is playing
		/// </summary>
		private string _lastCurrentSong { get; set; }

		/// <summary>
		/// Attempts to replace the current song with a different one
		/// If the song was barely replaced, it doesn't do anything
		/// </summary>
		public void TryReplaceSong()
		{
			//Game1.addHUDMessage(new HUDMessage(Game1.currentSong?.Name));

			string currentSong = Game1.currentSong?.Name;
			if (this._modAssetEditor.MusicReplacements.TryGetValue(currentSong?.ToLower() ?? "", out string value) && _lastCurrentSong != currentSong)
			{
				_lastCurrentSong = value;
				Game1.changeMusicTrack(value);
			}
		}
	}
}