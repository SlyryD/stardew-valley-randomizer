using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Archipelago.Definitions
{
    public static class LocationDefinitions
    {
        // Bundle Rewards
        public static readonly LocationData SpringForagingBundle  = new(237000, "Spring Foraging - Bundle Reward");
        public static readonly LocationData SummerForagingBundle  = new(237001, "Summer Foraging - Bundle Reward");
        public static readonly LocationData FallForagingBundle    = new(237002, "Fall Foraging - Bundle Reward");
        public static readonly LocationData WinterForagingBundle  = new(237003, "Winter Foraging - Bundle Reward");
        public static readonly LocationData ConstructionBundle    = new(237004, "Construction - Bundle Reward");
        public static readonly LocationData ExoticForagingBundle  = new(237005, "Exotic Foraging - Bundle Reward");
        public static readonly LocationData SpringCropsBundle     = new(237006, "Spring Crops - Bundle Reward");
        public static readonly LocationData SummerCropsBundle     = new(237007, "Summer Crops - Bundle Reward");
        public static readonly LocationData FallCropsBundle       = new(237008, "Fall Crops - Bundle Reward");
        public static readonly LocationData QualityCropsBundle    = new(237009, "Quality Crops - Bundle Reward");
        public static readonly LocationData AnimalBundle          = new(237010, "Animal - Bundle Reward");
        public static readonly LocationData ArtisanBundle         = new(237011, "Artisan - Bundle Reward");
        public static readonly LocationData RiverFishBundle       = new(237012, "River Fish - Bundle Reward");
        public static readonly LocationData LakeFishBundle        = new(237013, "Lake Fish - Bundle Reward");
        public static readonly LocationData OceanFishBundle       = new(237014, "Ocean Fish - Bundle Reward");
        public static readonly LocationData NightFishingBundle    = new(237015, "Night Fishing - Bundle Reward");
        public static readonly LocationData CrabPotBundle         = new(237016, "Crab Pot - Bundle Reward");
        public static readonly LocationData SpecialtyFishBundle   = new(237017, "Specialty Fish - Bundle Reward");
        public static readonly LocationData BlacksmithsBundle     = new(237018, "Blacksmith's - Bundle Reward");
        public static readonly LocationData GeologistsBundle      = new(237019, "Geologist's - Bundle Reward");
        public static readonly LocationData AdventurersBundle     = new(237020, "Adventurer's - Bundle Reward");
        public static readonly LocationData ChefsBundle           = new(237021, "Chef's - Bundle Reward");
        public static readonly LocationData DyeBundle             = new(237022, "Dye - Bundle Reward");
        public static readonly LocationData FieldResearchBundle   = new(237023, "Field Research - Bundle Reward");
        public static readonly LocationData FodderBundle          = new(237024, "Fodder - Bundle Reward");
        public static readonly LocationData EnchantersBundle      = new(237025, "Enchanter's - Bundle Reward");
        public static readonly LocationData G2500Bundle           = new(237026, "2500 - Bundle Reward");
        public static readonly LocationData G5000Bundle           = new(237027, "5000 - Bundle Reward");
        public static readonly LocationData G10000Bundle          = new(237028, "10000 - Bundle Reward");
        public static readonly LocationData G25000Bundle          = new(237029, "25000 - Bundle Reward");

        // Bundle Set Rewards
        public static readonly LocationData CraftsRoomBundleSet    = new(237100, "Crafts Room - Bundle Set Reward");
        public static readonly LocationData PantryBundleSet        = new(237102, "Pantry - Bundle Set Reward");
        public static readonly LocationData FishTankBundleSet      = new(237104, "Fish Tank - Bundle Set Reward");
        public static readonly LocationData BoilerRoomBundleSet    = new(237106, "Boiler Room - Bundle Set Reward");
        public static readonly LocationData BulletinBoardBundleSet = new(237108, "Bulletin Board - Bundle Set Reward");
        public static readonly LocationData VaultBundleSet         = new(237110, "Vault - Bundle Set Reward");
        public static readonly LocationData MissingBundleBundleSet = new(237112, "Missing Bundle - Bundle Set Reward");

        // Stardrops
        public static readonly LocationData FairStardrop          = new(237200, "Stardew Valley Fair - Stardrop");
        public static readonly LocationData SpouseStardrop        = new(237202, "Spouse or Roommate - Stardrop");
        public static readonly LocationData KrobusStardrop        = new(237203, "Krobus - Stardrop");
        public static readonly LocationData CannoliStardrop       = new(237204, "Cannoli - Stardrop");
        public static readonly LocationData MasterAnglerStardrop  = new(237205, "Master Angler - Stardrop");

        // Mine Treasures
        public static readonly LocationData Floor10Treasure       = new(237300, "Floor 10 - Mine Treasure");
        public static readonly LocationData Floor20Treasure       = new(237301, "Floor 20 - Mine Treasure");
        public static readonly LocationData Floor40Treasure       = new(237302, "Floor 40 - Mine Treasure");
        public static readonly LocationData Floor50Treasure       = new(237303, "Floor 50 - Mine Treasure");
        public static readonly LocationData Floor60Treasure       = new(237304, "Floor 60 - Mine Treasure");
        public static readonly LocationData Floor70Treasure       = new(237305, "Floor 70 - Mine Treasure");
        public static readonly LocationData Floor80Treasure       = new(237306, "Floor 80 - Mine Treasure");
        public static readonly LocationData Floor90Treasure       = new(237307, "Floor 90 - Mine Treasure");
        public static readonly LocationData Floor100Treasure      = new(237308, "Floor 100 - Mine Treasure");
        public static readonly LocationData Floor110Treasure      = new(237309, "Floor 110 - Mine Treasure");
        public static readonly LocationData Floor120Treasure      = new(237310, "Floor 120 - Mine Treasure");

        // Museum Rewards
        public static readonly LocationData Items5Museum          = new(237400, "Donate 5 Items - Museum Reward");
        public static readonly LocationData Items10Museum         = new(237401, "Donate 10 Items - Museum Reward");
        public static readonly LocationData Items15Museum         = new(237402, "Donate 15 Items - Museum Reward");
        public static readonly LocationData Items20Museum         = new(237403, "Donate 20 Items - Museum Reward");
        public static readonly LocationData Items25Museum         = new(237404, "Donate 25 Items - Museum Reward");
        public static readonly LocationData Items30Museum         = new(237405, "Donate 30 Items - Museum Reward");
        public static readonly LocationData Items35Museum         = new(237406, "Donate 35 Items - Museum Reward");
        public static readonly LocationData Items40Museum         = new(237407, "Donate 40 Items - Museum Reward");
        public static readonly LocationData Items50Museum         = new(237408, "Donate 50 Items - Museum Reward");
        public static readonly LocationData Items60Museum         = new(237409, "Donate 60 Items - Museum Reward");
        public static readonly LocationData Items70Museum         = new(237410, "Donate 70 Items - Museum Reward");
        public static readonly LocationData Items80Museum         = new(237411, "Donate 80 Items - Museum Reward");
        public static readonly LocationData Items90Museum         = new(237412, "Donate 90 Items - Museum Reward");
        public static readonly LocationData Items95Museum         = new(237413, "Donate 95 Items - Museum Reward");

        public static readonly LocationData Minerals11Museum      = new(237420, "Donate 11 Minerals - Museum Reward");
        public static readonly LocationData Minerals21Museum      = new(237421, "Donate 21 Minerals - Museum Reward");
        public static readonly LocationData Minerals31Museum      = new(237422, "Donate 31 Minerals - Museum Reward");
        public static readonly LocationData Minerals41Museum      = new(237423, "Donate 41 Minerals - Museum Reward");
        public static readonly LocationData Minerals50Museum      = new(237424, "Donate 50 Minerals - Museum Reward");

        public static readonly LocationData Artifacts11Museum     = new(237430, "Donate 11 Artifacts - Museum Reward");
        public static readonly LocationData Artifacts15Museum     = new(237431, "Donate 15 Artifacts - Museum Reward");
        public static readonly LocationData Artifacts20Museum     = new(237432, "Donate 20 Artifacts - Museum Reward");
        public static readonly LocationData AncientDrumMuseum     = new(237433, "Donate Ancient Drum - Museum Reward");
        public static readonly LocationData AncientSeedMuseum     = new(237434, "Donate Ancient Seed - Museum Reward");
        public static readonly LocationData BoneFluteMuseum       = new(237435, "Donate Bone Flute - Museum Reward");
        public static readonly LocationData ChickenStatueMuseum   = new(237436, "Donate Chicken Statue - Museum Reward");
        public static readonly LocationData DwarfScrollsMuseum    = new(237437, "Donate Dwarf Scrolls - Museum Reward");
        public static readonly LocationData LeftSkeletonMuseum    = new(237438, "Donate Left Skeleton Bones - Museum Reward");
        public static readonly LocationData MidSkeletonMuseum     = new(237439, "Donate Mid Skeleton Bones - Museum Reward");
        public static readonly LocationData RightSkeletonMuseum   = new(237440, "Donate Right Skeleton Bones - Museum Reward");

        // Story Quest Rewards
        public static readonly LocationData IntroductionsQuest    = new(237500, "Introductions - Quest Reward");
        public static readonly LocationData HowToWinFriendsQuest  = new(237501, "How To Win Friends - Quest Reward");
        public static readonly LocationData GettingStartedQuest   = new(237502, "Getting Started - Quest Reward");
        public static readonly LocationData ToTheBeachQuest       = new(237503, "To The Beach - Quest Reward");
        public static readonly LocationData RaisingAnimalsQuest   = new(237504, "Raising Animals - Quest Reward");
        public static readonly LocationData AdvancementQuest      = new(237505, "Advancement - Quest Reward");
        public static readonly LocationData ArchaeologyQuest      = new(237509, "Archaeology - Quest Reward");
        public static readonly LocationData RatProblemQuest       = new(237510, "Rat Problem - Quest Reward");
        public static readonly LocationData MeetTheWizardQuest    = new(237511, "Meet the Wizard - Quest Reward");
        public static readonly LocationData InitiationQuest       = new(237514, "Initiation - Quest Reward");
        public static readonly LocationData RobinsLostAxeQuest    = new(237515, "Robin's Lost Axe - Quest Reward");
        public static readonly LocationData JodisRequestQuest     = new(237516, "Jodi's Request - Quest Reward");
        public static readonly LocationData MayorsShortsQuest     = new(237517, "Mayor's \"Shorts\" - Quest Reward");
        public static readonly LocationData BlackberryBasketQuest = new(237518, "Blackberry Basket - Quest Reward");
        public static readonly LocationData MarniesRequestQuest   = new(237519, "Marnie's Request - Quest Reward");
        public static readonly LocationData PamIsThirstyQuest     = new(237520, "Pam Is Thirsty - Quest Reward");
        public static readonly LocationData ADarkReagentQuest     = new(237521, "A Dark Reagent - Quest Reward");
        public static readonly LocationData CowsDelightQuest      = new(237522, "Cow's Delight - Quest Reward");
        public static readonly LocationData TheSkullKeyQuest      = new(237523, "The Skull Key - Quest Reward");
        public static readonly LocationData CropResearchQuest     = new(237524, "Crop Research - Quest Reward");
        public static readonly LocationData KneeTherapyQuest      = new(237525, "Knee Therapy - Quest Reward");
        public static readonly LocationData RobinsRequestQuest    = new(237526, "Robin's Request - Quest Reward");
        public static readonly LocationData QisChallengeQuest     = new(237527, "Qi's Challenge - Quest Reward");
        public static readonly LocationData TheMysteriousQiQuest  = new(237528, "The Mysterious Qi - Quest Reward");
        public static readonly LocationData CarvingPumpkinsQuest  = new(237529, "Carving Pumpkins - Quest Reward");
        public static readonly LocationData AWinterMysteryQuest   = new(237530, "A Winter Mystery - Quest Reward");
        public static readonly LocationData StrangeNoteQuest      = new(237531, "Strange Note - Quest Reward");
        public static readonly LocationData CrypticNoteQuest      = new(237532, "Cryptic Note - Quest Reward");
        public static readonly LocationData FreshFruitQuest       = new(237533, "Fresh Fruit - Quest Reward");
        public static readonly LocationData AquaticResearchQuest  = new(237534, "Aquatic Research - Quest Reward");
        public static readonly LocationData ASoldiersStarQuest    = new(237535, "A Soldier's Star - Quest Reward");
        public static readonly LocationData MayorsNeedQuest       = new(237536, "Mayor's Need - Quest Reward");
        public static readonly LocationData WantedLobsterQuest    = new(237537, "Wanted: Lobster - Quest Reward");
        public static readonly LocationData PamNeedsJuiceQuest    = new(237538, "Pam Needs Juice - Quest Reward");
        public static readonly LocationData FishCasseroleQuest    = new(237539, "Fish Casserole - Quest Reward");
        public static readonly LocationData CatchASquidQuest      = new(237540, "Catch a Squid - Quest Reward");
        public static readonly LocationData FishStewQuest         = new(237541, "Fish Stew - Quest Reward");
        public static readonly LocationData PierresNoticeQuest    = new(237542, "Pierre's Notice - Quest Reward");
        public static readonly LocationData ClintsAttemptQuest    = new(237543, "Clint's Attempt - Quest Reward");
        public static readonly LocationData AFavorForClintQuest   = new(237544, "A Favor For Clint - Quest Reward");
        public static readonly LocationData StaffOfPowerQuest     = new(237545, "Staff of Power - Quest Reward");
        public static readonly LocationData GrannysGiftQuest      = new(237546, "Granny's Gift - Quest Reward");
        public static readonly LocationData ExoticSpiritsQuest    = new(237547, "Exotic Spirits - Quest Reward");
        public static readonly LocationData CatchALingcodQuest    = new(237548, "Catch a Lingcod - Quest Reward");
        public static readonly LocationData DarkTalismanQuest     = new(237549, "Dark Talisman - Quest Reward");
        public static readonly LocationData GoblinProblemQuest    = new(237550, "Goblin Problem - Quest Reward");
        public static readonly LocationData ThePiratesWifeQuest   = new(237551, "The Pirate's Wife - Quest Reward");

        // Help Wanted Quest Rewards

        // Quest Items

        // Special Orders Rewards

        // Mr. Qi Special Orders Rewards

        // Farming Skill Rewards

        // Mining Skill Rewards

        // Foraging Skill Rewards

        // Fishing Skill Rewards

        // Combat Skill Rewards

        // Shop Items

        public static IEnumerable<LocationData> GetAllLocations(SlotData data)
        {
            var list = new List<LocationData>();
            foreach (var field in typeof(LocationDefinitions).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (field.FieldType != typeof(LocationData))
                {
                    continue;
                }

                var location = (LocationData) field.GetValue(null);

                list.Add(location);
            }

            return list;
        }

        public static LocationData GetLocation(SlotData data, int code)
        {
            return GetAllLocations(data).First(location => location.Code == code);
        }

        public static LocationData GetLocation(SlotData data, string name)
        {
            return GetAllLocations(data).First(location => location.Name == name);
        }
    }
}
