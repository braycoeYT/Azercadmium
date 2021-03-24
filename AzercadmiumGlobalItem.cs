using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace Azercadmium
{
	public class AzercadmiumGlobalItem : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			string Dirtball = Language.GetTextValue("Dirtball Treasure Bag");
			string TitanTankorb = Language.GetTextValue("Titan Tankorb Treasure Bag");
			string MatrixScavenger = Language.GetTextValue("Matrix Scavenger Treasure Bag");

			if (item.type == mod.ItemType("DirtballBag"))
			{
				TooltipLine line = new TooltipLine(mod, "Dirtball", Dirtball);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1, line);
			}

			if (item.type == mod.ItemType("TitanBag"))
			{
				TooltipLine line = new TooltipLine(mod, "TitanTankorb", TitanTankorb);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1, line);
			}

			if (item.type == mod.ItemType("ScavengerBag"))
			{
				TooltipLine line = new TooltipLine(mod, "MatrixScavenger", MatrixScavenger);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1, line);
			}
		}
	}
}