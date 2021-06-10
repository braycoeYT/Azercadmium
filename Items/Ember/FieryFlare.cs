using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class FieryFlare : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fiery Flare");
            Tooltip.SetDefault("Spawns a flame wall on impact with a tile");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flare);
            item.damage = 15;
            item.shoot = ModContent.ProjectileType<Projectiles.Ember.FieryFlare>();
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flare, 100);
			recipe.AddIngredient(ModContent.ItemType<FlareSerpentScale>());
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
    }
}
