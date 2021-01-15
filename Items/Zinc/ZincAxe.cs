using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Zinc
{
	public class ZincAxe : ModItem
	{
		public override void SetDefaults() {
			item.damage = 6;
			item.melee = true;
			item.width = 28;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.6f;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
			item.axe = 10;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 9);
			recipe.AddRecipeGroup("Wood", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}