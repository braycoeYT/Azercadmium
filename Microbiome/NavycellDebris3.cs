using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Microbiome
{
	public class NavycellDebris3 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Navycell Debris");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.damage = 26;
		}
		public override void AI()
		{
			projectile.rotation += 0.02f;
		}
	}   
}