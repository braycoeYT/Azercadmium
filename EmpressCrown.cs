using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class EmpressCrown : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Crown");
			Tooltip.SetDefault("For every 10% of hp lost, defense increases by 2");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statDefense += 20;
			for (int i = 0; i < player.statLife; i += player.statLifeMax2 / 10) {
				player.statDefense -= 2;
			}
		}
	}
}