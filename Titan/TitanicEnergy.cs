using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Items.Titan
{
	public class TitanicEnergy : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Can be used to convert basic hardmode ores into their alts");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 26;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.LightRed;
		}
	}
}