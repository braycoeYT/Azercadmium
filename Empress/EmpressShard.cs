using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class EmpressShard : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Shard");
			Tooltip.SetDefault("A shard of the highest slime ruler");
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