using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Items.Ember.Seeds
{
    public class HellGrassSeeds : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Hell Grass Seeds");

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 15;
            item.useAnimation = 15;
            item.createTile = ModContent.TileType<HellPlants>();
            item.placeStyle = 0;
            item.value = Item.buyPrice(silver: 1);
            item.maxStack = 999;
            item.autoReuse = true;
            item.useTurn = true;
        }
    }
}