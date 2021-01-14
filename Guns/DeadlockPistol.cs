using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Guns
{
	public class DeadlockPistol : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Deadlock Pistol");
			Tooltip.SetDefault("Moderately inaccurate");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 1, 75, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 34;
			item.useTime = 34;
			item.damage = 7;
			item.width = 58;
			item.height = 28;
			item.knockBack = 0.2f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 5.2f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item41;
			item.autoReuse = false;
			item.rare = ItemRarityID.Blue;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlintlockPistol);
			recipe.AddIngredient(ItemID.WormTooth, 3);
			recipe.AddRecipeGroup("Azercadmium:AnyGem", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlintlockPistol);
			recipe.AddIngredient(mod.ItemType("BloodySpiderLeg"), 3);
			recipe.AddRecipeGroup("Azercadmium:AnyGem", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}