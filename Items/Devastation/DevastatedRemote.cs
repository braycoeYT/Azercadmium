using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Azercadmium.Items.Devastation
{
	public class DevastatedRemote : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Tracks your devastation level\nDevastation");
		}
		public override void SetDefaults() {
			item.width = 26;
			item.height = 24;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
					if (Main.GameUpdateCount % 240 < 120)
                    tooltipLine.overrideColor = new Color((int)(146 - (int)(Main.GameUpdateCount % 120) * 0.40832f), (int)(255 - (int)((Main.GameUpdateCount % 120) * 1.65832f)), (int)(138 - (int)((Main.GameUpdateCount % 120) * 1.066f)));
					else
					tooltipLine.overrideColor = new Color((int)(97 + (int)(Main.GameUpdateCount % 120) * 0.40832f), (int)(56 + (int)((Main.GameUpdateCount % 120) * 1.65832f)), (int)(10 + (int)((Main.GameUpdateCount % 120) * 1.066f)));
					//146, 255, 138 and 97, 56, 10
                }
            }
			DevastationPlayer p = Main.LocalPlayer.GetModPlayer<DevastationPlayer>();
            TooltipLine activateTooltip = new TooltipLine(mod, "Tooltip1", "Devastation Level: " + p.devLevel);
			TooltipLine activateTooltip2 = new TooltipLine(mod, "Tooltip2", "Current Devastation Point Count: " + p.devPoints);
			TooltipLine activateTooltip3 = new TooltipLine(mod, "Tooltip3", "Devastation Points for leveling up: " + p.maxDevPoints);
			TooltipLine activateTooltip4 = new TooltipLine(mod, "Tooltip4", "Current cap for leveling up (can be increased by defeating certain bosses): " + p.devLevelCap);
			TooltipLine activateTooltip5 = new TooltipLine(mod, "Tooltip5", "Max Health increased by " + p.devLevel);
			TooltipLine activateTooltip6 = new TooltipLine(mod, "Tooltip6", "Damage increased by " + (0.0015f * p.devLevel * 100) + "%");
			TooltipLine activateTooltip7 = new TooltipLine(mod, "Tooltip7", "Defense increased by " + (int)(0.1f * p.devLevel));
			list.Add(activateTooltip);
			list.Add(activateTooltip2);
			list.Add(activateTooltip3);
			list.Add(activateTooltip4);
			list.Add(activateTooltip5);
			list.Add(activateTooltip6);
			list.Add(activateTooltip7);
        }
	}
}