using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Other.Accessories
{
	public class IronfistMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases true melee damage by 15%");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.trueMelee15 = true;
		}
	}
}