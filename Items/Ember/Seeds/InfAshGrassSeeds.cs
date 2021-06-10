using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Items.Ember.Seeds
{
    public class InfAshGrassSeeds : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Bottomless Ash Grass Seeds");

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 15;
            item.useAnimation = 15;
            item.createTile = ModContent.TileType<AshPlants>();
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(silver: 5);
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AshGrassSeeds>(), 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}