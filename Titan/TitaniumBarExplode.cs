using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Titan
{
	public class TitaniumBarExplode : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titanium Bar");
        }
		int num = Main.rand.Next(3, 6);
		public override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 9999;
			aiType = 1;
			if (Main.expertMode) num += 2;
			if (AzercadmiumWorld.devastation) num += 2;
			num += (int)projectile.ai[0];
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
			projectile.rotation += 0.05f;
		}
		float lowestDistance;
		Player target;
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < num; i++) {
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 10).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("TitaniumShardHostile"), projectile.damage, 6, Main.myPlayer);
			}
			lowestDistance = 999999;
			int playerCount;
			for (playerCount = 0; playerCount < 255; playerCount++) {
				if (Main.player[playerCount].active) {
					if (Vector2.Distance(projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
						lowestDistance = Vector2.Distance(projectile.Center, Main.player[playerCount].Center + new Vector2(0, 6));
						target = Main.player[playerCount];
					}
				}
			}
			Projectile.NewProjectile(projectile.position, Vector2.Normalize((target.position - new Vector2(0, 0)) - projectile.Center) * 10, mod.ProjectileType("TitaniumShardHostile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		}
	}   
}