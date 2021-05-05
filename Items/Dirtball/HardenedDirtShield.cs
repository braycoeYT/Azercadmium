using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class HardenedDirtShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hardened Dirt Shield");
			Tooltip.SetDefault("When the owner has less than half health, the dirt casing increases damage reduction by 15%\nBeing in the jungle increases your life regen\nIncreases max mana by 20");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 22, 0);
			item.rare = -1;
			item.expert = true;
			item.defense = 2;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statLifeMax2 / 2 > player.statLife)
				player.endurance += 0.15f;
			if (player.ZoneJungle)
				player.lifeRegen += 2;
			player.statManaMax2 += 20;
		}
	}
}