using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Slime
{
	public class SlimeArrow : ModItem
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slime Arrow");
			Tooltip.SetDefault("Makes your enemies slimy");
        }
		public override void SetDefaults() {
			item.damage = 7;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2.5f;
			item.value = Item.sellPrice(0, 0, 0, 7);
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.Slime.SlimeArrow>();
			item.shootSpeed = 3f;
			item.ammo = AmmoID.Arrow;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 200);
			recipe.AddIngredient(ItemType<SlimyCore>());
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this, 200);
			recipe.AddRecipe();
		}
	}   
}