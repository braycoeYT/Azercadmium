using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Forest
{
	public class SproutedSeedling : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprouted Seed");
			Tooltip.SetDefault("For use with blowpipes\nEach seedshot creates a damaging temporary sapling on impact");
        }
		public override void SetDefaults() {
			item.damage = 8; //3
			item.ranged = true;
			item.width = 12;
			item.height = 14;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = Item.sellPrice(0, 0, 0, 2); //0
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.Wood.SproutedSeedling>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 75);
			recipe.AddIngredient(ItemID.Acorn);
			recipe.AddIngredient(ItemID.GrassSeeds);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}