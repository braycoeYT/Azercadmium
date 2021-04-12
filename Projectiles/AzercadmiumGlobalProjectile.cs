using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles
{
	public class AzercadmiumGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity => true;
		bool init;
		public override void SetDefaults(Projectile projectile) {
			if (projectile.type == ProjectileID.Flare || projectile.type == ProjectileID.BlueFlare)
				projectile.timeLeft = 3600;
		}
		public override void AI(Projectile projectile) {
			if (!init) {
				Player player = Main.player[projectile.owner];
				AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
				if (Azercadmium.JavelinCache[projectile.type])
					projectile.penetrate += p.javelinPenetration;
				init = true;
			}
		}
	}
}