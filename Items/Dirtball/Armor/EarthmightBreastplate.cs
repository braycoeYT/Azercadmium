using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Dirtball.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class EarthmightBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Become one with dirt\nIncreases armor penetration by 2");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = -1;
			item.defense = 5;
		}
		public override void UpdateEquip(Player player) {
			player.armorPenetration += 2;
		}
	}
}