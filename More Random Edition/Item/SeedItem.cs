﻿using System.Collections.Generic;

namespace Randomizer
{
	/// <summary>
	/// Represents a seed
	/// </summary>
	public class SeedItem : Item
	{
		public int Price { get; set; }
		public string Description
		{
			get
			{
				if (Id == (int)ObjectIndexes.CoffeeBean)
				{
					Item coffee = ItemList.Items[(int)ObjectIndexes.Coffee];
					string coffeeName = Globals.GetTranslation("item-coffee-name", new { itemName = coffee.CoffeeIngredient });
					return Globals.GetTranslation("item-coffee-bean-description", new { itemName = coffee.CoffeeIngredient, coffeeName });
				}

				CropItem growsCrop = (CropItem)ItemList.Items[CropGrowthInfo.CropId];
				string flowerString = growsCrop.IsFlower ? "This is a flower. " : "";
				string scytheString = CropGrowthInfo.CanScythe ? "Harvest with the scythe. " : "";
				string trellisString = CropGrowthInfo.IsTrellisCrop ? "Grows on a trellis. " : "";
				string growthString = CropGrowthInfo.RegrowsAfterHarvest ?
					$"Takes {CropGrowthInfo.TimeToGrow} days to grow but keeps producing after that. " :
					$"Takes {CropGrowthInfo.TimeToGrow} days to mature. ";
				string seasonsString = $"Plant during: {CropGrowthInfo.GetSeasonsString(true)}. ";
				string indoorsString = growsCrop.Id == (int)ObjectIndexes.CactusFruit ? "Can only be grown indoors. " : "";
				string waterString = growsCrop.Id == (int)ObjectIndexes.UnmilledRice ? "Grows faster near water." : "";

				return $"{flowerString}{scytheString}{trellisString}{growthString}{seasonsString}{indoorsString}{waterString}";
			}
		}
		public CropGrowthInformation CropGrowthInfo { get { return CropGrowthInformation.CropIdsToInfo[Id]; } }
		public List<Seasons> GrowingSeasons { get; set; }

		public bool Randomize { get; set; } = true;

		public SeedItem(int id, List<Seasons> growingSeasons) : base(id)
		{
			IsSeed = true;
			DifficultyToObtain = ObtainingDifficulties.LargeTimeRequirements;
			GrowingSeasons = growingSeasons;
		}

		/// <summary>
		/// Gets the string that's part of Data/ObjectInformation
		/// </summary>
		/// <returns />
		public override string ToString()
		{
			return $"{Name}/{Price}/-300/Seeds -74/{Name}/{Description}";
		}
	}
}
