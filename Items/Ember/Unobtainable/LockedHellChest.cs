using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Chests;

namespace Azercadmium.Items.Ember.Unobtainable
{
    public class LockedHellChest : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Locked Cinder Chest");

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Chest);
            item.createTile = ModContent.TileType<Containers>();
            item.placeStyle = 1;
        }
    }
}