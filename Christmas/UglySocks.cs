using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;

namespace Azercadmium.Items.Christmas
{
	public class UglySocks : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Aaay! New socks! I knew that was the number one thing you wanted this year!.. Why are you looking at me like that?");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Gray;
		}
	}
}