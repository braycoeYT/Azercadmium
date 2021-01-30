using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class HardenedDirtShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hardened Dirt Shield");
			Tooltip.SetDefault("When the owner has low health, the dirt casing increases damage reduction by 15%");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = -1;
			item.expert = true;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statLifeMax2 / 2 > player.statLife)
				player.endurance += 0.15f;
		}
	}
}