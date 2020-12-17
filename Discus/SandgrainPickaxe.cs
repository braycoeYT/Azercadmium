using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class SandgrainPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sandgrain Pickaxe");
			Tooltip.SetDefault("Can mine meteorite");
		}
		public override void SetDefaults() {
			item.damage = 7;
			item.melee = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.1f;
			item.value = Item.sellPrice(0, 0, 25, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 54;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 4);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}