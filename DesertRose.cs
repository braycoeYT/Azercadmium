using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Desert
{
	public class DesertRose : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rains Desert Sigils down from the sky");
		}
		public override void SetDefaults() {
			item.damage = 22;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.8f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DesertSigil");
			item.shootSpeed = 14f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-2, 2), 12);
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(Main.MouseWorld.X, position.Y - 600, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.5f), (int)(knockBack * 0.5f), player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SandBlock, 32);
			recipe.AddIngredient(ItemID.HardenedSand, 24);
			recipe.AddIngredient(ItemID.Cactus, 12);
			recipe.AddRecipeGroup("Azercadmium:AnyShadowScale", 3);
			recipe.AddIngredient(ItemID.PinkPricklyPear);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}