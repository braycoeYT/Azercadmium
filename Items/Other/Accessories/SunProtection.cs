using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Other.Accessories
{
	public class SunProtection : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sol Necklace");
			Tooltip.SetDefault("When you have low health, you have heavily increased life regen");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statLife < player.statLifeMax2 / 4)
			player.lifeRegen += 5;
		}
	}
}