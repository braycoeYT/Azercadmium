using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Items.Ember
{
    public class HellLeafWand : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LeafWand);
            item.rare = ItemRarityID.Orange;
            item.tileWand = ModContent.ItemType<CinderCedar>();
            item.createTile = ModContent.TileType<LivingHellLeaves>();
        }
    }
}
