using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class SparkingBatFoot : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sparking Bat Foot");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Stinger);
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 60, 0);
        }
    }
}
