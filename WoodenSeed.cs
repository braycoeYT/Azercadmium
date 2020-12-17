using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Wood
{
	public class WoodenSeed : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nBecause wooden dart was taken already");
        }
		public override void SetDefaults() {
			item.damage = 5;
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f;
			item.value = Item.sellPrice(0, 0, 0, 1);
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.Wood.WoodenSeed>();
			item.shootSpeed = 0f;
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}