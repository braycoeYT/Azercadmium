using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Accessories.Shields
{
	public class LifeCrystalShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Life Crystal Shield");
			Tooltip.SetDefault("Increases life regen by 2\nIncreases max life by 40");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 26;
			item.accessory = true;
			item.value = 200000;
			item.rare = ItemRarityID.Blue;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 40;
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