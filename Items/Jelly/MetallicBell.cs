using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Jelly
{
	public class MetallicBell : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Not to be confused with the Bell, Fairy Bell, Reindeer Bells, Eerie Bell, or Eldritch Bell");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Bell);
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(0, 0, 12, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item35.WithPitchVariance(4f);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}