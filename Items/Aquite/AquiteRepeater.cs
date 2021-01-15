using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Aquite
{
	public class AquiteRepeater : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires bubbles with each shot");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 6, 16, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 9;
			item.useTime = 9;
			item.damage = 49;
			item.width = 52;
			item.height = 20;
			item.knockBack = 0f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 14f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Cyan;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				// If you want to randomize the speed to stagger the projectiles
				float scale = 2f - (Main.rand.NextFloat() * .3f); //extra because bubble
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.FlaironBubble, (int)(damage * 0.75f), knockBack, player.whoAmI);
			}
				return true;
		}
	}
}