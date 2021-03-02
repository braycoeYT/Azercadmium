using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Hallow
{
	public class SunProtection : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sol Necklace");
			Tooltip.SetDefault("Dropped by the holiest and lightest of creatures\nLife regen is heavily increased in low health");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statLife < player.statLifeMax2 / 4)
			player.lifeRegen += 5;
		}
	}
}