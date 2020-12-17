using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Devastation
{
	public class GiantDemonScythe : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Giant Demon Scythe");
			Main.projFrames[projectile.type] = 8;
        }
		public override void SetDefaults() {
			aiType = ProjectileID.DemonScythe;
			projectile.width = 90;
			projectile.height = 90;
			projectile.aiStyle = 44;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = 999;
			
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Weak, Main.rand.Next(60, 91) * 60);
			target.AddBuff(BuffID.Cursed, Main.rand.Next(1, 3) * 60);
			target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(2, 6) * 60);
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
			if (++projectile.frameCounter >= 2) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 8)
					projectile.frame = 0;
			}
		}
		public override void Kill(int timeLeft) {
			Vector2 projDir = Vector2.Normalize(target.Center - projectile.Center) * 1;
			Projectile.NewProjectile(projectile.Center, projDir.RotatedBy(-0.27f), ProjectileID.DemonScythe, projectile.damage, projectile.knockBack, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center, projDir, ProjectileID.DemonScythe, projectile.damage, projectile.knockBack, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center, projDir.RotatedBy(0.27f), ProjectileID.DemonScythe, projectile.damage, projectile.knockBack, Main.myPlayer);
		}
	}   
}