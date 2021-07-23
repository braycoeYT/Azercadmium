using Azercadmium.Items.Jelly;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
    public class SharpenedFang : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sharpened Fang");
            Tooltip.SetDefault("Hitting enemies causes them to bleed\nCan be used with stake launchers");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Stake);
            item.damage = 11;
            item.crit = 9;
            item.shoot = ModContent.ProjectileType<Projectiles.Jelly.SharpenedFang>();
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OtherworldlyFang>());
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
    }
}
