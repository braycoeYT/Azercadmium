using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Furniture.Platforms;

namespace Azercadmium.Items.Ember
{
    public class CinderCedarPlatform : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Cinder Cedar Platform");

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodPlatform);
            item.createTile = ModContent.TileType<Platforms>();
            item.placeStyle = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CinderCedar>());
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}