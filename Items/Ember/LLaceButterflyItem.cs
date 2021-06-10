using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.NPCs.Ember.Critters;

namespace Azercadmium.Items.Ember
{
    public class LLaceButterflyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("'L' Lace");
            //Tooltip.SetDefault("Can be used to fish in dangerous lava");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MonarchButterfly);
            item.bait = 25;
            item.SetShopValues(3, Item.sellPrice(silver: 35));
            item.makeNPC = (short)ModContent.NPCType<LLaceButterfly>();
        }
    }
}
