using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Azercadmium.Items.Smore.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GooeyCover : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Somehow just as strong as metal, but I wouldn't question it\nIncreases melee speed by 8%, ranged critical strike chance by 5, max mana by 20, and minion knockback by 50%");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.White;
			item.defense = 5;
		}
		public override void UpdateEquip(Player player) {
			player.meleeSpeed += 0.08f;
			player.rangedCrit += 5;
			player.statManaMax2 += 20;
			player.minionKB += 0.5f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Smore"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}