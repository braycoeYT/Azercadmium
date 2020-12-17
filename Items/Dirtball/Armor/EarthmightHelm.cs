using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Dirtball.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EarthmightHelm : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Wearing this makes your mind dirty\nIncreases armor penetration by 1");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = -1;
			item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<EarthmightBreastplate>() && legs.type == ItemType<EarthmightLeggings>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases your max number of minions";
			player.maxMinions += 1;
		}
		public override void UpdateEquip(Player player) {
			player.armorPenetration += 1;
		}
	}
}