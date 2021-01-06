using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SandgrainElectroplates : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sandgrain Electroplates");
			Tooltip.SetDefault("4% increased ranged damage");
		}
		public override void SetDefaults() {
			item.width = 34;
			item.height = 24;
			item.value = Item.sellPrice(0, 0, 70, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 6;
		}
		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.04f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 8);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}