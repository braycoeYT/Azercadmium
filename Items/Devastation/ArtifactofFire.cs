using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Azercadmium.Items.Devastation
{
	public class ArtifactofFire : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Artifact of Fire");
			Tooltip.SetDefault("Not to be confused with the Emblem of Fire\nLeaves a trail of fire behind the user while moving\nUsing a weapon/tool has a small chance of releasing a fireball\nDevastation");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 24;
			item.accessory = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Green;
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
        }
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.artifactofFire = true;
		}
	}
}