using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.ID;
using Azercadmium.Tiles.Tree;

namespace Azercadmium.Items.Ember
{
    public class HellfireAcorn : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Acorn);
            item.createTile = ModContent.TileType<CinderCedarSapling>();
            item.value = Item.sellPrice(silver: 1, copper: 50);
            item.rare = ItemRarityID.Blue;
        }
    }
}