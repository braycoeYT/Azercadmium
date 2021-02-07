using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Slime
{
	public class GiantGelCluster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with flamethrowers and other gel-consuming weapons");
        }
		public override void SetDefaults() {
			item.damage = 0; //3
			item.ranged = true;
			item.width = 16;
			item.height = 14;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 0f; //0
			item.value = Item.sellPrice(0, 5, 0, 0); //0
			item.rare = ItemRarityID.Green;
			//item.shoot = ModContent.ProjectileType<Projectiles.Slime.GelShot>();
			//item.shootSpeed = 10f; //0
			item.ammo = AmmoID.Gel;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 400);
			recipe.AddIngredient(ItemID.PinkGel, 50);
			recipe.AddIngredient(ModContent.ItemType<Items.Slime.SlimyCore>(), 20);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}