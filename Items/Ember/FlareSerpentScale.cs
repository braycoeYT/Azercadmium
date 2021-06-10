using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class FlareSerpentScale : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Flare Serpent Scale");
            Tooltip.SetDefault("Quite shiny");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Stinger);
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.maxStack = 999;
        }
    }
}
