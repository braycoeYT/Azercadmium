using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Jungle
{
	public class MagicalVaccine : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Scares those flat-earthers out of town\nImmunity to feral bite");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[148] = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddRecipeGroup("IronBar", 3);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}