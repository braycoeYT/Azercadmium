using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Fish
{
	public class LabyrinthFish : ModItem
	{
		public override void SetDefaults() {
			item.width = 40;
			item.height = 34;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.rare = ItemRarityID.Blue;
		}
	}
}