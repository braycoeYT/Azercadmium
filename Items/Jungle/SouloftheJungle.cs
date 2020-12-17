using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jungle
{
	public class SouloftheJungle : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul of the Jungle");
			Tooltip.SetDefault("Increases max health by 25\nSummons spores over time that will damage enemies\nGreatly increases life regen when not moving\nReleases bees when damaged\nIncreases the strength of friendly bees");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 25;
			player.SporeSac();
			player.sporeSac = true;
			player.shinyStone = true;
			player.strongBees = true;
			player.bee = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SporeSac);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ItemID.HiveBackpack);
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.Stinger, 8);
			recipe.AddIngredient(ItemID.Vine, 5);
			recipe.AddIngredient(ItemID.LifeFruit, 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}