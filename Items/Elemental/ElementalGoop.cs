using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;

namespace Azercadmium.Items.Elemental
{
	public class ElementalGoop : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Looks extra tasty!\nDrops from elemental themed slimes post-Plantera");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Lime;
		}
	}
}