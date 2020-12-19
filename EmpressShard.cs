using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class EmpressShard : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Royal Gelatin");
			Tooltip.SetDefault("It shines and pulsates slowly");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 12, 0);
			item.rare = ItemRarityID.Lime;
		}
	}
}