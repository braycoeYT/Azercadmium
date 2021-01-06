using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SandgrainElectroboots : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sandgrain Electroboots");
			Tooltip.SetDefault("3% increased ranged damage\nImmune to desert winds");
		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.03f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 6);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}