using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Discus
{
	public class RedOrbShard : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Red Orb Shard");
        }
		public override void SetDefaults() {
			projectile.width = 17;
			projectile.height = 17;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.magic = true;
			projectile.timeLeft = 480;
			projectile.ignoreWater = true;
			aiType = 1;
		}
	}   
}