using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Items.Ember.Seeds
{
    public class HellSeeds : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Hell Seeds");

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GrassSeeds);
            item.createTile = ModContent.TileType<EmberGrass>();
        }
    }
}