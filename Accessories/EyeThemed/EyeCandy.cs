using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Accessories.EyeThemed
{
	public class EyeCandy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye Candy");
			Tooltip.SetDefault("The wrapper says that this is strawberry flavored.\nAfter taking damage, mana cost is halved");
		}
		public override void SetDefaults() {
			item.width = 58;
			item.height = 23;
			item.accessory = true;
			item.value = 42000;
			item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.eyeCandy = true;
		}
	}
}