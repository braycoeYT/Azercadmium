using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Empress
{
	public class ExalliteClusterStick : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Exallite Cluster");
        }
		public override void SetDefaults() {
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.melee = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 30;
		}
		public override void PostAI() {
			projectile.rotation = 0f;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 80);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
	}   
}