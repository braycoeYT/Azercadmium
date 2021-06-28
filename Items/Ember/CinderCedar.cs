using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Items.Ember
{
    public class CinderCedar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cinder Cedar");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Wood);
            item.createTile = ModContent.TileType<CinderCedarTile>();
            item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CinderCedarPlatform>(), 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
