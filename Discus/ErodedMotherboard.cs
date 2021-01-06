using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class ErodedMotherboard : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("While moving, you leave an electrical trail behind you\nThe electrical trail does 30 true damage");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.erodedMotherboard = true;
		}
	}
}