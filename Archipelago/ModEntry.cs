using System;
using Archipelago;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace YourProjectName
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        public Client ArchipelagoManager { get; private set; }

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            ArchipelagoManager = new Client(Monitor);

            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the game state is updated (≈60 times per second).</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // Wait for Arch to say its ready.
            switch (ArchipelagoManager.ConnectionStatus)
            {
                // We're ready!
                case ConnectionStatus.Connected:
                    {
                        // Do not attempt to start the game if we connect off the Arch screen. Most likely means we lost connection in gameplay and reconnected.
                        if (ScreenManager.CurrentScreen is not RandomizerScreen)
                        {
                            break;
                        }

                        // Initialize Save Data
                        ChangeProfile(ArchipelagoManager.Data.Seed, ArchipelagoManager.Data.Slot);

                        SoundManager.PlaySound("Game_Start");
                        var newGame = !PlayerStats.CharacterFound;
                        var heroIsDead = PlayerStats.IsDead;
                        var startingRoom = PlayerStats.LoadStartingRoom;

                        // Initialize Name Array.
                        InitializeNameArray(ArchipelagoManager.Data.AllowDefaultNames, ArchipelagoManager.Data.AdditionalSirNames);
                        InitializeFemaleNameArray(ArchipelagoManager.Data.AllowDefaultNames, ArchipelagoManager.Data.AdditionalLadyNames);

                        if (newGame)
                        {
                            PlayerStats.CharacterFound = true;
                            PlayerStats.Gold = 0;
                            PlayerStats.Class = ArchipelagoManager.Data.StartingClass;

                            // Unlock the player's starting class.
                            var skill = (ClassType)ArchipelagoManager.Data.StartingClass switch
                            {
                                ClassType.Knight => SkillSystem.GetSkill(SkillType.KnightUnlock),
                                ClassType.Mage => SkillSystem.GetSkill(SkillType.MageUnlock),
                                ClassType.Barbarian => SkillSystem.GetSkill(SkillType.BarbarianUnlock),
                                ClassType.Knave => SkillSystem.GetSkill(SkillType.AssassinUnlock),
                                ClassType.Miner => SkillSystem.GetSkill(SkillType.BankerUnlock),
                                ClassType.Shinobi => SkillSystem.GetSkill(SkillType.NinjaUnlock),
                                ClassType.Lich => SkillSystem.GetSkill(SkillType.LichUnlock),
                                ClassType.Spellthief => SkillSystem.GetSkill(SkillType.SpellswordUnlock),
                                _ => throw new ArgumentException("Unsupported Starting Class")
                            };

                            SkillSystem.LevelUpTrait(skill, false, false);

                            PlayerStats.HeadPiece = (byte)CDGMath.RandomInt(1, 5);
                            PlayerStats.EnemiesKilledInRun.Clear();

                            // Set AP Settings
                            PlayerStats.TimesCastleBeaten = ArchipelagoManager.Data.Difficulty;

                            // Set the player's initial gender.
                            PlayerStats.IsFemale = ArchipelagoManager.Data.IsFemale;

                            if (PlayerStats.IsFemale)
                            {
                                PlayerStats.PlayerName = ArchipelagoManager.Data.AdditionalLadyNames.Count > 0
                                    ? $"Lady {ArchipelagoManager.Data.AdditionalLadyNames[0]}"
                                    : "Lady Jenny";
                            }
                            else
                            {
                                PlayerStats.PlayerName = ArchipelagoManager.Data.AdditionalSirNames.Count > 0
                                    ? $"Sir {ArchipelagoManager.Data.AdditionalSirNames[0]}"
                                    : "Sir Lee";
                            }

                            SaveManager.SaveFiles(SaveType.PlayerData, SaveType.Lineage, SaveType.UpgradeData);
                            ScreenManager.DisplayScreen((int)ScreenType.StartingRoom, true);
                        }
                        else
                        {
                            if (heroIsDead)
                            {
                                ScreenManager.DisplayScreen((int)ScreenType.Lineage, true);
                            }
                            else
                            {
                                ScreenManager.DisplayScreen(startingRoom ? (int)ScreenType.StartingRoom : (int)ScreenType.Level,
                                    true);
                            }
                        }

                        SoundManager.StopMusic(0.2f);
                        break;
                    }
            }
        }
    }
}