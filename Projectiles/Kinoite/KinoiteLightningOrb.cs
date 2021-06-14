using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Kinoite
{
	public class KinoiteLightningOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lightning Orb");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults() {
			projectile.width = 90;
			projectile.height = 90;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.magic = true;
			projectile.timeLeft = 186;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;  
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		int Timer; 
		public override void AI() {
			Timer++;
			if (++projectile.frameCounter >= 4) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
					projectile.frame = 0;
			}
			if (Timer % 15 == 0)
				Projectile.NewProjectile(projectile.Center, projectile.velocity * -3, ModContent.ProjectileType<KinoiteBolt2>(), (int)(projectile.damage * 0.9f), 0, Main.myPlayer);
			if (Timer % 45 == 0) {
				float lowestDistance = 999999;
			int playerCount;
			Player target = Main.player[1];
			for (playerCount = 0; playerCount < 255; playerCount++) {
				if (Main.player[playerCount].active) {
					if (Vector2.Distance(projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
						lowestDistance = Vector2.Distance(projectile.Center, Main.player[playerCount].Center + new Vector2(0, 6));
						 target = Main.player[playerCount];
					}
				}
			}
			Vector2 vector3 = Vector2.Normalize((target.position - new Vector2(0, 0)) - projectile.Center) * 10;
				for (int i = 0; i < 8; i++) {
					Projectile.NewProjectile(projectile.Center, vector3.RotatedBy((float)((double)(Math.PI / 180) * (45*i))), ModContent.ProjectileType<KinoiteEnergy>(), (int)(projectile.damage * 0.5f), 2f, Main.myPlayer, 0f, 0f);
				}
			}
			if (Timer > 60)
				projectile.alpha += 2;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}