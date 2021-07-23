using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace Azercadmium.Projectiles.Jelly
{
	public class MonsoonProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eldritch Monsoon");
			Main.projFrames[projectile.type] = 2;
		}
		public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 300;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		NPC target;
		public override void AI() {
			if (projectile.alpha > 0 && projectile.timeLeft > 240)
				projectile.alpha -= 15;
			if (projectile.alpha < 255 && projectile.timeLeft <= 17)
				projectile.alpha += 15;
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
					projectile.frame = 0;
			}
			if (projectile.timeLeft == 240) {
				projectile.velocity = 16f * new Vector2((float)Math.Cos(projectile.rotation), (float)Math.Sin(projectile.rotation));
			}
			if (projectile.timeLeft > 240) {
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
						projectile.rotation = angle;
					}
				}
			}
			projectile.velocity *= 0.98f;
		}
	}
}