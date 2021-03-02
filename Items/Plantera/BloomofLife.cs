using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Plantera
{
	public class BloomofLife : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bloom of Life");
			Tooltip.SetDefault("Increases max life by 20\nHeals life after taking damage");
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