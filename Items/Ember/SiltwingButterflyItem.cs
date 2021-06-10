using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.NPCs.Ember.Critters;

namespace Azercadmium.Items.Ember
{
    public class SiltwingButterflyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Siltwing");
            //Tooltip.SetDefault("Attracts a catch 2x faster than normal bait");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MonarchButterfly);
            item.bait = 12;
            item.SetShopValues(2, Item.sellPrice(silver: 5));
            item.makeNPC = (short)ModContent.NPCType<SiltwingButterfly>();
        }
    }
}