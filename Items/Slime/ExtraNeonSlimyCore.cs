using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Azercadmium.Items.Slime
{
	public class ExtraNeonSlimyCore : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Grants immunity to Slimy Ooze, and slightly increases jump height\nDevastation");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 40)); //first is speed, second is amount of frames
		}
		public override void SetDefaults() {
			item.width = 42;
			item.height = 42;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
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
			player.buffImmune[mod.BuffType("SlimyOoze")] = true;
			player.jumpSpeedBoost += 1f;
		}
	}
}