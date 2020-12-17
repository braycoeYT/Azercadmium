using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Eye
{
	public class GlazedLens : ModItem
	{
		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Blue;
		}
	}
}