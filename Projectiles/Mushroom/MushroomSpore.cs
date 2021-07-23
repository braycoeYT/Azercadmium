using Azercadmium.Aaa;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Mushroom
{
	public class MushroomSpore : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mushroom Spore");
        }
		public override void SetDefaults() {
			projectile.aiStyle = -1;
			projectile.width = 14;
			projectile.height = 16;
			projectile.ranged = false;
			projectile.timeLeft = 600;
			projectile.tileCollide = false;
			projectile.alpha = 0;
			projectile.friendly = true;
		}
		int Timer;
		public override void AI() {
			Timer++;
				float num165 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
				float num166 = projectile.localAI[0];
				if (num166 == 0f)
				{
					projectile.localAI[0] = num165;
					num166 = num165;
				}
				if (projectile.alpha > 0)
				{
					projectile.alpha -= 25;
				}
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
				float num167 = projectile.position.X;
				float num168 = projectile.position.Y;
				float num169 = 300f;
				bool flag4 = false;
				int num170 = 0;
				if (projectile.ai[1] == 0f)
				{
					for (int num171 = 0; num171 < 200; num171++)
					{
						if (Main.npc[num171].CanBeChasedBy(projectile, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num171 + 1)))
						{
							float num172 = Main.npc[num171].position.X + (float)(Main.npc[num171].width / 2);
							float num173 = Main.npc[num171].position.Y + (float)(Main.npc[num171].height / 2);
							float num174 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num172) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num173);
							if (num174 < num169 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num171].position, Main.npc[num171].width, Main.npc[num171].height))
							{
								num169 = num174;
								num167 = num172;
								num168 = num173;
								flag4 = true;
								num170 = num171;
							}
						}
					}
					if (flag4)
					{
						projectile.ai[1] = (float)(num170 + 1);
					}
					flag4 = false;
				}
				if (projectile.ai[1] > 0f)
				{
					int num175 = (int)(projectile.ai[1] - 1f);
					if (Main.npc[num175].active && Main.npc[num175].CanBeChasedBy(projectile, true) && !Main.npc[num175].dontTakeDamage)
					{
						float num176 = Main.npc[num175].position.X + (float)(Main.npc[num175].width / 2);
						float num177 = Main.npc[num175].position.Y + (float)(Main.npc[num175].height / 2);
						if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num176) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num177) < 1000f)
						{
							flag4 = true;
							num167 = Main.npc[num175].position.X + (float)(Main.npc[num175].width / 2);
							num168 = Main.npc[num175].position.Y + (float)(Main.npc[num175].height / 2);
						}
					}
					else
					{
						projectile.ai[1] = 0f;
					}
				}
				if (!projectile.friendly)
				{
					flag4 = false;
				}
				if (flag4 && Timer > 99)
				{
					float arg_82C0_0 = num166;
					Vector2 vector19 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float num178 = num167 - vector19.X;
					float num179 = num168 - vector19.Y;
					float num180 = (float)Math.Sqrt((double)(num178 * num178 + num179 * num179));
					num180 = arg_82C0_0 / num180;
					num178 *= num180;
					num179 *= num180;
					int num181 = 40;
					projectile.velocity.X = (projectile.velocity.X * (float)(num181 - 1) + num178) / (float)num181;
					//projectile.velocity.Y = (projectile.velocity.Y * (float)(num181 - 1) + num179) / (float)num181;
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.05f;
				if (projectile.velocity.Y > 16f) {
					projectile.velocity.Y = 16f;
				}
				projectile.rotation = projectile.velocity.X * 0.05f;
		}
	}   
}