using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Crimson
{
	public class BloodiedArrow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Pierces multiple times");
		}
		public override void SetDefaults() {
			item.damage = 14;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 0, 8);
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileType<Projectiles.Crimson.BloodiedArrow>();
			item.shootSpeed = 2f;
			item.ammo = AmmoID.Arrow;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 5);
			recipe.AddIngredient(mod.ItemType("BloodySpiderLeg"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}   
}