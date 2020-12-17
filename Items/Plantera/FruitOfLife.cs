using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Plantera
{
	public class FruitOfLife : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fruit of Life");
			Tooltip.SetDefault("Increases max life by 20\nYou gain life every time you take damage");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 20, 0);
			item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 20;
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.hurtHeal = true;
		}
	}
}