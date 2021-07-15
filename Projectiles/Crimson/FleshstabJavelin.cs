using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Crimson
{
	public class FleshstabJavelin : ModProjectile
	{
		public override void SetDefaults() { //remember AzercadmiumProjectile
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Ichor, 60*Main.rand.Next(5, 11));
			for (int i = 0; i < 5; i++) {
				Projectile.NewProjectile(projectile.position, new Vector2(0, 12).RotatedByRandom(2), ProjectileID.IchorSplash, (int)(projectile.damage*0.75f), 2.5f, Main.myPlayer);
			}
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Ichor, 60*Main.rand.Next(5, 11));
			for (int i = 0; i < 5; i++) {
				Projectile.NewProjectile(projectile.position, new Vector2(0, 12).RotatedByRandom(2), ProjectileID.IchorSplash, (int)(projectile.damage*0.75f), 2.5f, Main.myPlayer);
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}