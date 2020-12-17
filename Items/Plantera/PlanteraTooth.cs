using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Plantera
{
	public class PlanteraTooth : ModItem
	{
		public override void SetDefaults() {
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 9, 0);
			item.rare = ItemRarityID.LightPurple;
		}
	}
}