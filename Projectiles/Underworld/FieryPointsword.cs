using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Underworld
{
	public class FieryPointsword : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fiery Pointsword");
		}
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
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
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 5), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 5), false);
		}
		public float MovementFactor {
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
		float oldRotation;
		public override void AI() {
			Player projOwner = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			oldRotation = projectile.rotation;
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			if (!projOwner.frozen) {
				if (MovementFactor == 0f)
				{
					MovementFactor = 65f; //65
					projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 0f; //2.4
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 0f; //2.1
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
	}
}