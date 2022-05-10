using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Archipelago.Definitions
{
    public static class ItemDefinitions
    {
        // Vendors
        public static readonly ItemData Blacksmith            = new(ItemCode.SPRING_SEEDS, "Blacksmith", ItemType.Weapon);
        public static readonly ItemData Enchantress           = new(ItemCode.SUMMER_SEEDS, "Enchantress", ItemType.Weapon);
        public static readonly ItemData Architect             = new(ItemCode.FALL_SEEDS, "Architect", ItemType.Weapon);

        // Classes
        public static readonly ItemData Knight                = new(ItemCode.KEG, "Knights", ItemType.Weapon);
        public static readonly ItemData Paladin               = new(ItemCode.BAIT, "Paladins", ItemType.Weapon);
        public static readonly ItemData Mage                  = new(ItemCode.DRESSED_SPINNER, "Mages", ItemType.Weapon);
        public static readonly ItemData Archmage              = new(ItemCode.WARP_TOTEM_BEACH, "Archmages", ItemType.Weapon);
        public static readonly ItemData Barbarian             = new(ItemCode.SMALL_GLOW_RING, "Barbarians", ItemType.Weapon);
        public static readonly ItemData BarbarianKing         = new(ItemCode.CRAB_POT, "Barbarian Kings", ItemType.Weapon);
        public static readonly ItemData Knave                 = new(ItemCode.DISH_O_THE_SEA, "Knaves", ItemType.Weapon);
        public static readonly ItemData Assassin              = new(ItemCode.FURNACE, "Assassins", ItemType.Weapon);
        public static readonly ItemData Shinobi               = new(ItemCode.OMNI_GEODE, "Shinobis", ItemType.Weapon);
        public static readonly ItemData Hokage                = new(ItemCode.SMALL_MAGNET_RING, "Hokages", ItemType.Weapon);
        public static readonly ItemData Miner                 = new(ItemCode.PINK_CAKE, "Miners", ItemType.Weapon);
        public static readonly ItemData Spelunker             = new(ItemCode.SEED_MAKER, "Spelunker", ItemType.Weapon);
        public static readonly ItemData Lich                  = new(ItemCode.RECYCLING_MACHINE, "Liches", ItemType.Weapon);
        public static readonly ItemData LichKing              = new(ItemCode.HEATER, "Lich Kings", ItemType.Weapon);
        public static readonly ItemData Spellthief            = new(ItemCode.GOLD_BAR, "Spellthieves", ItemType.Weapon);
        public static readonly ItemData Spellsword            = new(ItemCode.CHOCOLATE_CAKE, "Spellswords", ItemType.Weapon);
        public static readonly ItemData Dragon                = new(ItemCode.QUALITY_FERTILIZER, "Dragons", ItemType.Weapon);
        public static readonly ItemData Traitors              = new(ItemCode.LIGHTNING_ROD, "Traitors", ItemType.Weapon);
        public static readonly ItemData ProgressiveKnight     = new(ItemCode.WINTER_SEEDS, "Progressive Knights", ItemType.Weapon);
        public static readonly ItemData ProgressiveMage       = new(ItemCode.CHARCOAL_KILN, "Progressive Mages", ItemType.Weapon);
        public static readonly ItemData ProgressiveBarbarian  = new(ItemCode.AUTUMNS_BOUNTY, "Progressive Barbarians", ItemType.Weapon);
        public static readonly ItemData ProgressiveKnave      = new(ItemCode.SPEED_GRO, "Progressive Knaves", ItemType.Weapon);
        public static readonly ItemData ProgressiveShinobi    = new(ItemCode.QUALITY_SPRINKLER, "Progressive Shinobis", ItemType.Weapon);
        public static readonly ItemData ProgressiveMiner      = new(ItemCode.BEE_HOUSE, "Progressive Miners", ItemType.Weapon);
        public static readonly ItemData ProgressiveLich       = new(ItemCode.PRESERVES_JAR, "Progressive Liches", ItemType.Weapon);
        public static readonly ItemData ProgressiveSpellthief = new(ItemCode.CHEESE_PRESS, "Progressive Spellthieves", ItemType.Weapon);

        // Skills
        public static readonly ItemData HealthUp              = new(ItemCode.CRYSTALARIUM, "Health Up", ItemType.Weapon);
        public static readonly ItemData ManaUp                = new(ItemCode.CAVIAR, "Mana Up", ItemType.Weapon);
        public static readonly ItemData AttackUp              = new(ItemCode.BRIDGE_REPAIR, "Attack Up", ItemType.Weapon);
        public static readonly ItemData MagicDamageUp         = new(ItemCode.GREENHOUSE, "Magic Damage Up", ItemType.Weapon);
        public static readonly ItemData ArmorUp               = new(ItemCode.GLITTERING_BOULDER_REMOVED, "Armor Up", ItemType.Weapon);
        public static readonly ItemData EquipUp               = new(ItemCode.MINECARTS_REPAIRED, "Equip Up", ItemType.Weapon);
        public static readonly ItemData CritChanceUp          = new(ItemCode.FRIENDSHIP, "Crit Chance Up", ItemType.Weapon);
        public static readonly ItemData CritDamageUp          = new(ItemCode.BUS_REPAIR, "Crit Damage Up", ItemType.Weapon);
        public static readonly ItemData DownStrikeUp          = new(ItemCode.MOVIE_THEATER, "Down Strike Up", ItemType.Weapon);
        public static readonly ItemData GoldGainUp            = new(ItemCode.STARDROP, "Gold Gain Up", ItemType.Weapon);
        public static readonly ItemData PotionEfficiencyUp    = new(ItemCode.LEATHER_BOOTS, "Potion Efficiency Up", ItemType.Weapon);
        public static readonly ItemData InvulnTimeUp          = new(ItemCode.STEEL_SMALLSWORD, "Invulnerability Time Up", ItemType.Weapon);
        public static readonly ItemData ManaCostDown          = new(ItemCode.SLINGSHOT, "Mana Cost Down", ItemType.Weapon);
        public static readonly ItemData DeathDefiance         = new(ItemCode.TUNDRA_BOOTS, "Death Defiance", ItemType.Weapon);
        public static readonly ItemData Haggling              = new(ItemCode.CRYSTAL_DAGGER, "Haggling", ItemType.Weapon);
        public static readonly ItemData RandomizeChildren     = new(ItemCode.MASTER_SLINGSHOT, "Randomize Children", ItemType.Weapon);

        // Blueprints
        public static readonly ItemData ProgressiveArmor      = new(ItemCode.MELON_SEEDS, "Progressive Blueprints", ItemType.Regular);
        public static readonly ItemData SquireArmor           = new(ItemCode.STARFRUIT_SEEDS, "Squire Blueprints", ItemType.Regular);
        public static readonly ItemData SilverArmor           = new(ItemCode.A_NIGHT_ON_ECO_HILL_PAINTING, "Silver Blueprints", ItemType.Regular);
        public static readonly ItemData GuardianArmor         = new(ItemCode.JADE_HILLS_PAINTING, "Guardian Blueprints", ItemType.Regular);
        public static readonly ItemData ImperialArmor         = new(ItemCode.LG_FUTAN_BEAR, "Imperial Blueprints", ItemType.Regular);
        public static readonly ItemData RoyalArmor            = new(ItemCode.PUMPKIN_SEEDS, "Royal Blueprints", ItemType.Regular);
        public static readonly ItemData KnightArmor           = new(ItemCode.RARECROW_8, "Knight Blueprints", ItemType.Regular);
        public static readonly ItemData RangerArmor           = new(ItemCode.BEAR_STATUE, "Ranger Blueprints", ItemType.Regular);
        public static readonly ItemData SkyArmor              = new(ItemCode.RUSTY_KEY, "Sky Blueprints", ItemType.Regular);
        public static readonly ItemData DragonArmor           = new(ItemCode.TRIPLE_SHOT_ESPRESSO, "Dragon Blueprints", ItemType.Regular);
        public static readonly ItemData SlayerArmor           = new(ItemCode.WARP_TOTEM_FARM, "Slayer Blueprints", ItemType.Regular);
        public static readonly ItemData BloodArmor            = new(ItemCode.MAGIC_ROCK_CANDY, "Blood Blueprints", ItemType.Regular);
        public static readonly ItemData SageArmor             = new(ItemCode.STANDING_GEODE, "Sage Blueprints", ItemType.Regular);
        public static readonly ItemData RetributionArmor      = new(ItemCode.SINGING_STONE, "Retribution Armor Blueprints", ItemType.Regular);
        public static readonly ItemData HolyArmor             = new(ItemCode.OBSIDIAN_VASE, "Holy Armor Blueprints", ItemType.Regular);
        public static readonly ItemData DarkArmor             = new(ItemCode.CRYSTAL_CHAIR, "Dark Armor Blueprints", ItemType.Regular);

        // Runes
        public static readonly ItemData VaultRunes            = new(ItemCode.CRYSTALARIUM, "Vault Runes", ItemType.BigCraftable);
        public static readonly ItemData SprintRunes           = new(ItemCode.BURNT_OFFERING, "Sprint Runes", ItemType.BigCraftable);
        public static readonly ItemData VampireRunes          = new(ItemCode.SKELETON_STATUE, "Vampire Runes", ItemType.BigCraftable);
        public static readonly ItemData SkyRunes              = new(ItemCode.RARECROW_7, "Sky Runes", ItemType.BigCraftable);
        public static readonly ItemData SiphonRunes           = new(ItemCode.DRUM_BLOCK, "Siphon Runes", ItemType.BigCraftable);
        public static readonly ItemData RetaliationRunes      = new(ItemCode.ANCIENT_SEEDS, "Retaliation Runes", ItemType.BigCraftable);
        public static readonly ItemData BountyRunes           = new(ItemCode.FLUTE_BLOCK, "Bounty Runes", ItemType.BigCraftable);
        public static readonly ItemData HasteRunes            = new(ItemCode.CHICKEN_STATUE, "Haste Runes", ItemType.BigCraftable);
        public static readonly ItemData CurseRunes            = new(ItemCode.DWARVISH_TRANSLATION_GUIDE, "Curse Runes", ItemType.BigCraftable);
        public static readonly ItemData GraceRunes            = new(ItemCode.SLOTH_SKELETON_L, "Grace Runes", ItemType.BigCraftable);
        public static readonly ItemData BalanceRunes          = new(ItemCode.SLOTH_SKELETON_M, "Balance Runes", ItemType.BigCraftable);

        // Misc. Items
        public static readonly ItemData TripStatIncrease      = new(ItemCode.FIREWALKER_BOOTS, "Triple Stat Increase", ItemType.Special);
        public static readonly ItemData Gold1000              = new(ItemCode.OBSIDIAN_EDGE, "1000 Gold", ItemType.RegularRecipe);
        public static readonly ItemData Gold3000              = new(ItemCode.SPACE_BOOTS, "3000 Gold", ItemType.RegularRecipe);
        public static readonly ItemData Gold5000              = new(ItemCode.SKULL_KEY, "5000 Gold", ItemType.RegularRecipe);

        public static IEnumerable<ItemData> GetAllItems()
        {
            return typeof(ItemDefinitions)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(field => field.FieldType == typeof(ItemData))
                .Select(field => (ItemData) field.GetValue(null))
                .ToList();
        }

        public static ItemData GetItem(int code)
        {
            return GetAllItems().First(item => item.Code == code);
        }

        public static ItemData GetItem(string name)
        {
            return GetAllItems().First(item => item.Name == name);
        }

        public static ItemType GetItemType(this int code)
        {
            try
            {
                return GetItem(code).Type;
            }
            catch
            {
                return ItemType.BigCraftableRecipe;
            }
        }
    }
}
