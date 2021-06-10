using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.NPCs.Ember.Critters;

namespace Azercadmium.Items.Ember
{
    public class InfernoButterflyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Igneous Butterfly");
            //Tooltip.SetDefault("Can be used to fish in dangerous lava");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MonarchButterfly);
            item.bait = 30;
            item.SetShopValues(3, Item.sellPrice(silver: 50));
            item.makeNPC = (short)ModContent.NPCType<InfernoButterfly>();
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;
    }
}
