using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Other.Bats
{
	public class ExplosiveMarshmallow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Explosive Marshmallow");
        }
		public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.position, new Microsoft.Xna.Framework.Vector2(0, 0), ProjectileID.DD2ExplosiveTrapT2Explosion, projectile.damage, 0, Main.myPlayer);
		}
	}   
}