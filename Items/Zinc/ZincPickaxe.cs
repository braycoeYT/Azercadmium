using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Zinc
{
	public class ZincPickaxe : ModItem
	{
		public override void SetDefaults() {
			item.damage = 6;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.1f;
			item.value = Item.sellPrice(0, 0, 6, 90);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 43;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 12);
			recipe.AddRecipeGroup("Wood", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}