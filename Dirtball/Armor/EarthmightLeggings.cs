using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Dirtball.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class EarthmightLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("These leggings make your feet numb\nIncreases armor penetration by 1");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = -1;
			item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.armorPenetration += 1;
		}
	}
}