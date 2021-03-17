using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Solar
{
	public class BlazingBacklasher : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blazing Backlasher");
        }
		public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Daybreak, 300);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 262);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int Timer;
		float num31;
		float num32;
		float num38 = 0.25f; //0.25f
		Vector2 vector;
		float num39;
		float num40;
		float num42 = 12f; //18f
		float num43 = 0.6f; //0.4f
		Vector2 vector2; 
		float num44;
		float num45; 
		float num46;
		public override void AI() {
			num31 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
			num32 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
			vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			num39 = num31 - vector.X;
			num40 = num32 - vector.Y;
			vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			num44 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector2.X;
			num45 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector2.Y;
			num46 = (float)Math.Sqrt((double)(num44 * num44 + num45 * num45));
			Timer++;
			if (Timer % 20 == 0) 
				Projectile.NewProjectile(projectile.position + projectile.velocity * -5, new Microsoft.Xna.Framework.Vector2(0, 0), ProjectileID.SolarWhipSwordExplosion, projectile.damage, 0, Main.myPlayer);
			else if (Timer > 10) {
				projectile.width = 32;
				projectile.height = 32;
			}
			if (projectile.ai[0] == 0f) {
				if (projectile.velocity.X < num39)
						{
							projectile.velocity.X = projectile.velocity.X + num38;
							if (projectile.velocity.X < 0f && num39 > 0f)
							{
								projectile.velocity.X = projectile.velocity.X + num38 * 2f;
							}
						}
						else if (projectile.velocity.X > num39)
						{
							projectile.velocity.X = projectile.velocity.X - num38;
							if (projectile.velocity.X > 0f && num39 < 0f)
							{
								projectile.velocity.X = projectile.velocity.X - num38 * 2f;
							}
						}
						if (projectile.velocity.Y < num40)
						{
							projectile.velocity.Y = projectile.velocity.Y + num38;
							if (projectile.velocity.Y < 0f && num40 > 0f)
							{
								projectile.velocity.Y = projectile.velocity.Y + num38 * 2f;
							}
						}
						else if (projectile.velocity.Y > num40)
						{
							projectile.velocity.Y = projectile.velocity.Y - num38;
							if (projectile.velocity.Y > 0f && num40 < 0f)
							{
								projectile.velocity.Y = projectile.velocity.Y - num38 * 2f;
							}
						}
			}
			else {
				if (projectile.type == 383)
					{
						Vector2 vector3 = new Vector2(num44, num45) - projectile.velocity;
						if (vector3 != Vector2.Zero)
						{
							Vector2 value = vector3;
							value.Normalize();
							projectile.velocity += value * Math.Min(num43, vector3.Length());
						}
					}
					else
					{
						if (projectile.velocity.X < num44)
						{
							projectile.velocity.X = projectile.velocity.X + num43;
							if (projectile.velocity.X < 0f && num44 > 0f)
							{
								projectile.velocity.X = projectile.velocity.X + num43;
							}
						}
						else if (projectile.velocity.X > num44)
						{
							projectile.velocity.X = projectile.velocity.X - num43;
							if (projectile.velocity.X > 0f && num44 < 0f)
							{
								projectile.velocity.X = projectile.velocity.X - num43;
							}
						}
						if (projectile.velocity.Y < num45)
						{
							projectile.velocity.Y = projectile.velocity.Y + num43;
							if (projectile.velocity.Y < 0f && num45 > 0f)
							{
								projectile.velocity.Y = projectile.velocity.Y + num43;
							}
						}
						else if (projectile.velocity.Y > num45)
						{
							projectile.velocity.Y = projectile.velocity.Y - num43;
							if (projectile.velocity.Y > 0f && num45 < 0f)
							{
								projectile.velocity.Y = projectile.velocity.Y - num43;
							}
						}
					}
			}
		}
	}   
}