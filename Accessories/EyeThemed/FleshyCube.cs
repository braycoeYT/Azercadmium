using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Accessories.EyeThemed
{
	public class FleshyCube : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases max number of minions");
		}
		public override void SetDefaults() {
			item.width = 76;
			item.height = 66;
			item.accessory = true;
			item.value = 150000;
			item.rare = ItemRarityID.LightRed;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.maxMinions += 1;
		}
	}
}