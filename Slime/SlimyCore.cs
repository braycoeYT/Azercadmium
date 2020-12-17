using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Slime
{
	public class SlimyCore : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slimy Core");
			Tooltip.SetDefault("Part of a slime nucleus");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.White;
		}
	}
}