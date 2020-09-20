using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Dyes
{
	public class CocoaBeans : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Used to make Brown Dye");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 20;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Blue;
		}
	}
}