using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Zinc
{
	public class ZincBar : ModItem
	{
		public override void SetDefaults() {
			item.rare = ItemRarityID.White;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 4, 80);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Zinc.ZincBar>();
			item.placeStyle = 0;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincOre"), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}