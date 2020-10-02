using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Other.Accessories
{
	public class IronfistMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases true melee damage by 35%");
		}
		public override void SetDefaults() {
			item.width = 50;
			item.height = 50;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.trueMelee35 = true;
		}
	}
}