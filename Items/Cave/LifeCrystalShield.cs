using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class LifeCrystalShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crystalline Heart Shield");
			Tooltip.SetDefault("Increases life regen by 2\nIncreases max life by 20");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 26;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 20;
			player.lifeRegen += 2;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LifeforceShield"));
			recipe.AddIngredient(ItemID.MeteoriteBar, 7);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}