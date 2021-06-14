using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Developer.Braycoe
{
	public class Slimeblast : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slimeblast");
        }
		public override void SetDefaults() {
			projectile.width = 34;
			projectile.height = 34;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
			projectile.melee = true;
			aiType = ProjectileID.Bullet;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 6) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 6) * 60, false);
		}
		public override void AI() {
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
				if (flag4)
				{
					float arg_82C0_0 = num166;
					Vector2 vector19 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float num178 = num167 - vector19.X;
					float num179 = num168 - vector19.Y;
					float num180 = (float)Math.Sqrt((double)(num178 * num178 + num179 * num179));
					num180 = arg_82C0_0 / num180;
					num178 *= num180;
					num179 *= num180;
					int num181 = 8;
					projectile.velocity.X = (projectile.velocity.X * (float)(num181 - 1) + num178) / (float)num181;
					projectile.velocity.Y = (projectile.velocity.Y * (float)(num181 - 1) + num179) / (float)num181;
				}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 80);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
	}   
}