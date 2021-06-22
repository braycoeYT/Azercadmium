using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Sky
{
	public class SpaceAmulet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("When swinging a weapon, occasionally summons a star from above to strike foes");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 77, 0);
			item.rare = ItemRarityID.Green;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.spaceAmulet = true;
		}
	}
}