using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class Dirty3String : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirty 3-String");
			Tooltip.SetDefault("Casts 1-3 arrows at the cost of a low firerate");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 43;
			item.useTime = 43;
			item.damage = 14;
			item.width = 24;
			item.height = 40;
			item.knockBack = 0f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = -1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			float numberProjectiles = Main.rand.Next(1, 4);
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			if (numberProjectiles > 1)
				return false;
			else
				return true;
		}
	}
}