using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Titan
{
	public class TitanFragment : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Generates up to 10 fragments to rotate around the player\nAfter damage is taken, the fragments are shot out at extreme speeds towards foes");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.titanFragment = true;
		}
	}
}