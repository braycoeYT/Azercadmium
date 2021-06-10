using IL.Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class BurntPoisonDart : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Burnt Poison Dart");
            Tooltip.SetDefault("Can either poison or burn enemies");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.PoisonDart);
            item.shoot = ModContent.ProjectileType<Projectiles.Ember.BurntPoisonDart>();
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BurntStinger>());
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
    }
}
