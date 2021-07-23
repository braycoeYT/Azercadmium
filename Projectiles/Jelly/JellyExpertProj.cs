using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyExpertProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Big Eerie Jellyfish");
			Main.projFrames[projectile.type] = 3;
		}
		public override void SetDefaults() {
			projectile.width = 52;
			projectile.height = 52;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 210;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		NPC target;
		int Timer;
		public override void AI() {
			Timer++;
			if (projectile.alpha > 0 && projectile.timeLeft > 193)
				projectile.alpha -= 15;
			if (projectile.alpha < 255 && projectile.timeLeft <= 17)
				projectile.alpha += 15;
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
					projectile.frame = 0;
			}
			if (Main.maxNPCs > 0 && Main.maxNPCUpdates > 0) {
				lowestDistance = 999999;
				int npcCount;
				target = Main.npc[0];
				for (npcCount = 0; npcCount < Main.maxNPCs; npcCount++) {
					if (Main.npc[npcCount].active && !Main.npc[npcCount].townNPC && !Main.npc[npcCount].friendly) {
						if (Vector2.Distance(projectile.Center, Main.npc[npcCount].Center) < lowestDistance) {
							lowestDistance = Vector2.Distance(projectile.Center, Main.npc[npcCount].Center);
							target = Main.npc[npcCount];
						}
					}
				}
				if (target.active && target != null && Main.maxNPCs > 0 && Main.maxNPCUpdates > 0 && Main.maxNPCTypes > 0)
				{
					Vector2 look = target.Center - projectile.Center;
					if (look.X != 0f) {
					angle = (float)Math.Atan(look.Y / look.X);
					}
					else if (look.Y < 0f) {
						angle += (float)Math.PI;
					}
					if (look.X < 0f) {
						angle += (float)Math.PI;
					}
					if (Timer == 18)
					projectile.rotation = angle;
				}
				if (Timer == 17)
					projectile.velocity = (projectile.Center - target.Center) * (-0.022f);
			}
			projectile.velocity *= 0.98f;
			if (projectile.timeLeft == 1) {
				for (int i = 0; i < 4; i++)
					Projectile.NewProjectile(projectile.Center, new Vector2(0, 10).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<JellyExpertProj2>(), projectile.damage, projectile.knockBack, Main.myPlayer);
			}
		}
	}
}