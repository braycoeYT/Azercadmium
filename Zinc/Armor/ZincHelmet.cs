using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Zinc.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ZincHelmet : ModItem
	{
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.defense = 3;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<ZincBreastplate>() && legs.type == ItemType<ZincLeggings>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "3 Defense";
			player.statDefense += 3;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}