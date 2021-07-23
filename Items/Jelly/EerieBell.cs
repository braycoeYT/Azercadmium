using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Jelly
{
	public class EerieBell : ModItem
	{
		public override void SetDefaults() {
			item.width = 34;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Orange;
		}
	}
}