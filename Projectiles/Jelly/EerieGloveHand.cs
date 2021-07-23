using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class EerieGloveHand : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eerie Glove");
			Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults() {
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.timeLeft = 1;
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
					MovementFactor = 1f; //65
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
			projectile.frame = projectile.direction + 1;
			if (projectile.frame == 0)
				MovementFactor = 0.5f;
			else
				MovementFactor = 1f;
			projectile.position += projectile.velocity * MovementFactor;
			if (projectile.frame == 0)
				projectile.position += projectile.velocity.RotatedBy(MathHelper.ToRadians(90));
			if (projOwner.itemAnimation == 0) {
				projectile.Kill();
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1) {
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
			projectile.rotation += MathHelper.ToRadians(235f); //45
			//projectile.spriteDirection = projectile.direction;
		}
	}
}