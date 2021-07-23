using Azercadmium.Aaa;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class EerieSpear : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
		public float MovementFactor {
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
		int Timer;
		public override void AI() {
			Timer++;
			Player projOwner = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			if (!projOwner.frozen) {
				if (MovementFactor == 0f)
				{
					MovementFactor = 1f;
					projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 0.8f;
				}
				else
				{
					MovementFactor += 0.7f;
					if (Timer % 5 == 0)
						Projectile.NewProjectile(projectile.Center, projectile.velocity * 2f, ModContent.ProjectileType<EerieSpearProj>(), (int)(projectile.damage * 0.3f), 2f, Main.myPlayer);
				}
			}
			projectile.position += projectile.velocity * MovementFactor;
			if (projOwner.itemAnimation == 0) {
				projectile.Kill();
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1) {
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.Jelly.JellyDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}