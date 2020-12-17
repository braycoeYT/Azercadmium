using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class EmpressBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases your max amount of minions\nIncreases minion damage by 11%");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.defense = 18;
		}
		public override void UpdateEquip(Player player) {
			player.maxMinions += 1;
			player.minionDamage += 0.11f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmpressShard"), 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}