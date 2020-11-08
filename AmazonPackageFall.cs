using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Mech
{
	public class AmazonPackageFall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Package");
        }
		public override void SetDefaults() {
			projectile.width = 24;
			projectile.height = 28;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 0), mod.ProjectileType("AmazonPackage"), projectile.damage, 0, Main.myPlayer);
		}
	}   
}