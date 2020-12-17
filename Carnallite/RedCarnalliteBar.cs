using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Carnallite
{
	public class RedCarnalliteBar : ModItem
	{
		public override void SetDefaults() {
			item.rare = ItemRarityID.Lime;
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 48, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Carnallite.RedCarnalliteBar>();
			item.placeStyle = 0;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<GreenCarnalliteBar>(), 2);
			recipe.AddIngredient(mod.ItemType("EmpressShard"));
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}