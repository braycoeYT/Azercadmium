using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteBar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Supercharged with an energy as strong as the birth of a star");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 12)); //first is speed, second is amount of frames
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Purple;
			item.width = 40;
			item.height = 32;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 1, 40, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Kinoite.KinoiteBar>();
			item.placeStyle = 0;
			item.noUseGraphic = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = Azercadmium.Magenta;
                }
            }
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "KinoiteOre", 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}