using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Scavenger
{
	public class MechanicalGearPiece : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It keeps on running...");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Pink;
			item.expert = true;
		}
	}
}