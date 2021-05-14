using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Titan
{
	public class TitansExecutionerPassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan's Executioner");
        }
		public override void SetDefaults() {
			//aiType = ProjectileID.Bullet;
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.light = 0.33f;
			projectile.penetrate = -1;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 146);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int Timer;
		float trueRotation;
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		float spinSpeed = 0f;
		NPC target;
		public override void AI() {
			Timer++;
			if (Timer > 149) { //99 scale complete
				//projectile.aiStyle = 1;
				if (Timer == 150) {
					projectile.rotation = angle + (56.25f * (float)Math.PI); //45 = halfway?
					aiType = ProjectileID.Bullet;
					projectile.width = 30;
					projectile.height = 30;
					projectile.penetrate = 2;
				}
				projectile.velocity = 7.5f * new Vector2((float)Math.Cos(trueRotation), (float)Math.Sin(trueRotation));
				//new Vector2((float)Math.Cos(trueRotation), (float)Math.Sin(trueRotation)).RotatedBy((float)((Math.PI / 180) * 45));
			}
			else {
				lowestDistance = 999999;
				int npcCount;
				for (npcCount = 0; npcCount < Main.maxNPCs; npcCount++) {
					if (Main.npc[npcCount].active) {
						if (Vector2.Distance(projectile.Center, Main.npc[npcCount].Center) < lowestDistance) {
							lowestDistance = Vector2.Distance(projectile.Center, Main.npc[npcCount].Center);
							target = Main.npc[npcCount];
						}
					}
				}
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
				trueRotation = angle;
				if (spinSpeed < 0.2f)
					spinSpeed += 0.0025f;
				projectile.rotation += spinSpeed;
				projectile.velocity *= 0.955f;
			}
		}
	}   
}