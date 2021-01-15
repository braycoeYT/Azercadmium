using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DirtShieldOfOblivion : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirt Shield of Oblivion");
			Tooltip.SetDefault("When the owner has low health, the dirt casing increases damage reduction by 10%");
		}
		public override void SetDefaults() {
			item.width = 52;
			item.height = 68;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = -1;
			item.expert = true;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statLifeMax2 / 2 > player.statLife)
				player.endurance += 0.1f;
		}
	}
}