using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Devastation
{
	public class CthulhuTooth : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cthulhu Tooth");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 44;
			projectile.height = 44;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = 999;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Weak, Main.rand.Next(60, 91) * 60);
			target.AddBuff(BuffID.Cursed, Main.rand.Next(1, 3) * 60);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 148);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int Timer;
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		Player target;
		public override void AI() {
			Timer++;
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
		}
		/*public override void Kill(int timeLeft) {
			Vector2 projDir = Vector2.Normalize(target.Center - projectile.Center) * 8;
			Projectile.NewProjectile(projectile.Center, projDir, ProjectileID.DemonScythe, projectile.damage, projectile.knockBack, Main.myPlayer);
		}*/
	}   
}