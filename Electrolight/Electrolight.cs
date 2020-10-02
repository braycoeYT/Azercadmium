using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Electrolight
{
	public class Electrolight : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electrolight");
			Tooltip.SetDefault("Unbelievably electrical");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.rare = ItemRarityID.LightRed;
		}
	}
}