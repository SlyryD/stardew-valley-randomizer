﻿using System.Collections.Generic;

namespace Randomizer
{
	/// <summary>
	/// Contains data about boots
	/// </summary>
	public class BootData
	{
		/// <summary>
		/// All the boot data from the xnb data file
		/// </summary>
		public static List<BootItem> AllBoots = new List<BootItem>
		{
			new BootItem(504, "Sneakers", "A little flimsy... but fashionable!", 50, 1, 0, 0),
			new BootItem(505, "Rubber Boots", "Protection from the elements.", 50, 0, 1, 1),
			new BootItem(506, "Leather Boots", "The leather is very supple.", 50, 1, 1, 2),
			new BootItem(507, "Work Boots", "Steel-toed for extra protection.", 50, 2, 0, 3),
			new BootItem(508, "Combat Boots", "Reinforced with iron mesh.", 150, 3, 0, 4),
			new BootItem(509, "Tundra Boots", "The fuzzy lining keeps your ankles so warm.", 150, 2, 1, 5),
			new BootItem(510, "Thermal Boots", "Designed with extreme weather in mind.", 50, 1, 2, 6),
			new BootItem(511, "Dark Boots", "Made from thick black leather.", 250, 4, 2, 7),
			new BootItem(512, "Firewalker Boots", "It's said these can withstand the hottest magma.", 250, 3, 3, 8),
			new BootItem(513, "Genie Shoes", "A curious energy permeates the fabric.", 250, 1, 6, 9),
			new BootItem(514, "Space Boots", "An iridium weave gives them a purple sheen.", 450, 4, 4, 10),
			new BootItem(515, "Cowboy Boots", "It's the height of country fashion.", 250, 2, 2, 11),
			new BootItem(804, "Emily's Magic Boots", "Made with love by Emily. 100% compostable!", 250, 4, 4, 13),
			new BootItem(806, "Leprechaun Shoes", "The buckle's made of solid gold.", 250, 2, 1, 14),
		};
	}
}
