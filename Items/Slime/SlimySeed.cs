using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Slime
{
	public class SlimySeed : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slimy Seed");
			Tooltip.SetDefault("For use with blowpipes\nEach seedshot has a high chance of sliming enemies");
        }
		public override void SetDefaults() {
			item.damage = 6;
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = Item.sellPrice(0, 0, 0, 1); //0
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.Slime.SlimySeed>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 50);
			recipe.AddIngredient(ItemID.Gel);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}