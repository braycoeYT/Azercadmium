using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Smore
{
	public class GrahamCracker : ModItem
	{
		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 0, 20);
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hay, 2);
			recipe.AddTile(TileID.CookingPots);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}