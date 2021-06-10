using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class HellKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cinder Key");
            Tooltip.SetDefault("Rarely found in Ember Crates\nOpens all cinder chests");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GoldenKey);
            item.maxStack = 1;
            item.SetShopValues(7, Item.sellPrice(gold: 6, silver: 66));
        }
    }
}