using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Crimson
{
	public class GoldenShowerHidden : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Golden Shower (Hidden)");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.GoldenShower);
			item.noUseGraphic = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldenShower);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}