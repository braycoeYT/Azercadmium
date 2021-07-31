using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class MiniJellyLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mini Jelly Laser");
		}
		public override void SetDefaults() {
			projectile.height = 290;
			projectile.width = 6;
			projectile.friendly = true;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.timeLeft = 10 + (int)(projectile.ai[1] / 1.5f);
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 4 + (int)(projectile.ai[1] / 10);
			projectile.tileCollide = false;
		}
		bool a;
		public override void AI(){
			if (!a) {
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
				projectile.position += projectile.velocity;
				projectile.velocity = new Vector2(0, 0);
				a = true;
				Main.PlaySound(SoundID.Item33);
			}
		}
	}
}