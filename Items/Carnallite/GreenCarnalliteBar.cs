using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Carnallite
{
	public class GreenCarnalliteBar : ModItem
	{
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Carnallite.GreenCarnalliteBar>();
			item.placeStyle = 0;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<GreenCarnalliteOre>(), 4);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}