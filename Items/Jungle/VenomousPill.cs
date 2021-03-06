using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jungle
{
	public class VenomousPill : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I heard if you take a bit of venom each day you can build up a resistance\nImmunity to venom");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 19;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Pink;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[BuffID.Venom] = true;
		}
	}
}