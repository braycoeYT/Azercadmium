using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Items.Ember.Unobtainable
{
    public class EmberThorn : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DirtBlock);
            item.createTile = ModContent.TileType<EmberThornTile>();
        }
    }
}