using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteOre : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Supercharged with loads of otherworldly energy");
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Kinoite.ProOre>();
			item.width = 16;
			item.height = 16;
			item.value = Item.sellPrice(0, 0, 35, 0);
			item.rare = ItemRarityID.Purple;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
	}
}