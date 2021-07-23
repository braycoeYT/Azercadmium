using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Jelly
{
	public class OtherworldlyFang : ModItem
	{
		public override void SetDefaults() {
			item.width = 26;
			item.height = 22;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 50);
			item.rare = ItemRarityID.Orange;
		}
	}
}