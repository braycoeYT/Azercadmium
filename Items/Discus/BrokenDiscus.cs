using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class BrokenDiscus : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Scraped by time and the desert winds, but still viable as a material for building machinery");
		}
		public override void SetDefaults()  {
			item.value = Item.sellPrice(0, 0, 0, 50);
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}
	}
}