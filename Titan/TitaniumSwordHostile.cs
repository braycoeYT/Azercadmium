using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Titan
{
	public class TitaniumSwordHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titanium Sword");
        }
		public override void SetDefaults() {
			//aiType = ProjectileID.Bullet;
			projectile.width = 48;
			projectile.height = 48;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
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
		Player target;
		public override void AI() {
			
			Timer++;
			if (Timer > 149) { //99 scale complete
				//projectile.aiStyle = 1;
				if (Timer == 150) {
					projectile.rotation = angle + (56.25f * (float)Math.PI); //45 = halfway?
					aiType = ProjectileID.Bullet;
					projectile.width = 30;
					projectile.height = 30;
				}
				projectile.velocity = 5f * new Vector2((float)Math.Cos(trueRotation), (float)Math.Sin(trueRotation));
				//new Vector2((float)Math.Cos(trueRotation), (float)Math.Sin(trueRotation)).RotatedBy((float)((Math.PI / 180) * 45));
			}
			else {
				lowestDistance = 999999;
				int playerCount;
				for (playerCount = 0; playerCount < 255; playerCount++) {
					if (Main.player[playerCount].active) {
						if (Vector2.Distance(projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
							lowestDistance = Vector2.Distance(projectile.Center, Main.player[playerCount].Center);
							target = Main.player[playerCount];
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
			}
		}
	}   
}