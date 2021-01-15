using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Zinc
{
	public class ZincHammer : ModItem
	{
		public override void SetDefaults() {
			item.damage = 8;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.6f;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.hammer = 43;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 10);
			recipe.AddRecipeGroup("Wood", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}