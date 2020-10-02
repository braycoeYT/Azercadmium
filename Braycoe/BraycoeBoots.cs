using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Braycoe
{
	public class BraycoeBoots : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Braycoe's Boots");
			Tooltip.SetDefault("Don't use this. Hyperspeed and insanity. I would remove this but everyone likes it for some reason.");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = ItemRarityID.Purple;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.maxRunSpeed += 20f;
			player.wingTimeMax += 30;
		}
	}
}