using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Chests;

namespace Azercadmium.Items.Ember
{
    public class HellChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cinder Chest");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Chest);
            item.createTile = ModContent.TileType<Containers>();
            item.placeStyle = 0;
        }
    }
}