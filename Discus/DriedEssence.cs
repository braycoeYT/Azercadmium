using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class DriedEssence : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It seems to go well with water");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 200;
			item.rare = ItemRarityID.Blue;
			item.useStyle = ItemUseStyleID.HoldingUp;
		}
	}
}