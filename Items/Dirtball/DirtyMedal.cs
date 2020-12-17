using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Dirtball
{
	public class DirtyMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Max minions increased by one");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.maxMinions += 1;
		}
	}
}