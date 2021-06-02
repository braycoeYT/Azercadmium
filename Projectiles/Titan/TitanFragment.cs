using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Titan
{
	public class TitanFragment : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Fragment");
        }
		public override void SetDefaults() {
			//aiType = ProjectileID.Bullet;
			projectile.width = 25;
			projectile.height = 25;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.light = 0.1f;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 146);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int Timer;
		int currentHurt = -1; 
		float trueRotation;
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		float spinSpeed = 0f;
		float spinRotation = Main.rand.NextFloat(0, 360);
		float spinRotationSpeed = Main.rand.NextFloat(0.6f, 2.2f);
		bool check;
		NPC target = Main.npc[0];
		public override void AI() {
			Timer++;
			AzercadmiumPlayer p = Main.player[projectile.owner].GetModPlayer<AzercadmiumPlayer>();
			if (currentHurt < 0) {
				currentHurt = p.hurtCounter;
			}
			if (!p.titanFragment)
				projectile.Kill();
			if (p.hurtCounter > currentHurt) {
				projectile.alpha = 0;
				//projectile.aiStyle = 1;
				if (!check) {
					projectile.rotation = angle + (56.25f * (float)Math.PI); //45 = halfway?
					aiType = ProjectileID.Bullet;
					projectile.penetrate = -1;
					check = true;
				}
				if (Timer == 150) {
					projectile.rotation = angle + (56.25f * (float)Math.PI); //45 = halfway?
					aiType = ProjectileID.Bullet;
					projectile.width = 30;
					projectile.height = 30;
					projectile.penetrate = 2;
				}
				projectile.velocity = 12f * new Vector2((float)Math.Cos(trueRotation), (float)Math.Sin(trueRotation));
				//new Vector2((float)Math.Cos(trueRotation), (float)Math.Sin(trueRotation)).RotatedBy((float)((Math.PI / 180) * 45));
			}
			else {
				projectile.timeLeft = 600;
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
				if (spinSpeed < 0.15f)
					spinSpeed += 0.0025f;
				if (projectile.alpha > 0)
					projectile.alpha -= 3;
				projectile.rotation += spinSpeed;
				projectile.position = Main.player[projectile.owner].position + new Vector2(0, 100).RotatedBy(spinRotation*Math.PI/180);
				spinRotation += spinRotationSpeed;
				if (spinRotationSpeed > 360)
					spinRotation -= 360;
			}
		}
	}   
}