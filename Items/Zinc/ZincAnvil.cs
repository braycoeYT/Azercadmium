using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Zinc
{
	public class ZincAnvil : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Used to craft items from metal bars");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.White;
			item.width = 40;
			item.height = 20;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 24, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Zinc.ZincAnvil>();
			item.placeStyle = 0;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}