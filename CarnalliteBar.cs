using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Carnallite
{
	public class CarnalliteBar : ModItem
	{
		public override void SetDefaults() {
			item.rare = ItemRarityID.Lime;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Carnallite.CarnalliteBar>();
			item.placeStyle = 0;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CarnalliteOre>(), 4);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}