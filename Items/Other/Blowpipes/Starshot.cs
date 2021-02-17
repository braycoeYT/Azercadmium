using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Other.Blowpipes
{
	public class Starshot : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nPierces infinitely and ignores gravity");
        }
		public override void SetDefaults() {
			item.damage = 5;
			item.ranged = true;
			item.width = 18;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f;
			item.value = Item.sellPrice(0, 0, 0, 50);
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileType<Projectiles.Other.Blowpipes.Starshot>();
			item.shootSpeed = 0f;
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}