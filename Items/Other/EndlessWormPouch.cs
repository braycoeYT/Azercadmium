using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other
{
	public class EndlessWormPouch : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bottomless Sack of Worms");
			Tooltip.SetDefault("Why would you even bother to try and craft this?");
        }
		public override void SetDefaults() {
			item.width = 24;
			item.height = 32;
			item.maxStack = 1;
			item.consumable = false;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.ammo = AmmoID.None;
			item.bait = 25;
		}
		public override void OnConsumeItem(Player player) {
			item.stack = 2;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Worm, 500);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}