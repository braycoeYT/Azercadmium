using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Darkron
{
	public class Shadowbang : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'...and out with a bang!'\nShoots 8 bullets in a ring shape");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 4, 60, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 41;
			item.useTime = 41;
			item.damage = 31;
			item.width = 36;
			item.height = 28;
			item.knockBack = 3.4f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Pink;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-14, -4);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Projectile.NewProjectile(position.X - 25, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X + 25, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y - 25, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y + 25, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X + 12, position.Y - 12, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X + 12, position.Y + 12, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X - 12, position.Y - 12, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X - 12, position.Y + 12, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}