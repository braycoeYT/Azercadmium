using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Darkron
{
	public class Blackout : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blackout");
		}
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
			if (Timer % 3 == 0 && MovementFactor > 3f) {
				Projectile.NewProjectile(projectile.Center, projectile.velocity, ModContent.ProjectileType<MiniDarkronBlob>(), projectile.damage / 3, 0.75f, Main.myPlayer);
			}
			Player projOwner = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			// As long as the player isn't frozen, the spear can move
			if (!projOwner.frozen) {
				if (MovementFactor == 0f)
				{
					MovementFactor = 3f; //3
					projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 2.4f; //2.4
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 2.1f; //2.1
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