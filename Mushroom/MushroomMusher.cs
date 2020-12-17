using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Mushroom
{
	public class MushroomMusher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a large wave");
		}
		public override void SetDefaults() {
			item.damage = 11;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 51;
			item.useAnimation = 51;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.2f;
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = false;
			item.shoot = mod.ProjectileType("MushroomWave");
			item.shootSpeed = 20f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 19);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}