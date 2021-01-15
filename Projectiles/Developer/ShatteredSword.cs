using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Developer
{
	public class ShatteredSword : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shattered Sword");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.TerraBeam);
			projectile.width = 40;
			projectile.height = 40;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 80;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 64);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}