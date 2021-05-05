using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Titan
{
	public class TitanBlast : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Blast");
        }
		public override void SetDefaults() {
			projectile.aiStyle = -1;
			projectile.width = 26;
			projectile.height = 26;
			projectile.timeLeft = 300;
			projectile.tileCollide = false;
			projectile.hostile = true;
			projectile.light = 0.5f;
		}
		int Timer;
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		Player target;
		public override void AI() {
			Timer++;
			if (Timer <= 120)
				return;
			int num3;
																	if (projectile.ai[0] == 0f && projectile.ai[1] > 0f)
																	{
																		float[] var_2_2065C_cp_0 = projectile.ai;
																		int var_2_2065C_cp_1 = 1;
																		float num73 = var_2_2065C_cp_0[var_2_2065C_cp_1];
																		var_2_2065C_cp_0[var_2_2065C_cp_1] = num73 - 1f;
																	}
																	else if (projectile.ai[0] == 0f && projectile.ai[1] == 0f)
																	{
																		projectile.ai[0] = 1f;
																		projectile.ai[1] = (float)Player.FindClosest(projectile.position, projectile.width, projectile.height);
																		projectile.netUpdate = true;
																		float num754 = projectile.velocity.Length();
																		projectile.velocity = Vector2.Normalize(projectile.velocity) * (num754 + 4f);
																		/*for (int num755 = 0; num755 < 8; num755 = num3 + 1)
																		{
																			Vector2 vector72 = Vector2.UnitX * -8f;
																			vector72 += -Vector2.UnitY.RotatedBy((double)((float)num755 * 3.14159274f / 4f), default(Vector2)) * new Vector2(2f, 8f);
																			vector72 = vector72.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
																			int num756 = Dust.NewDust(projectile.Center, 0, 0, 228, 0f, 0f, 0, default(Color), 1f);
																			Main.dust[num756].scale = 1.5f;
																			Main.dust[num756].noGravity = true;
																			Main.dust[num756].position = projectile.Center + vector72;
																			Main.dust[num756].velocity = projectile.velocity * 0f;
																			num3 = num755;
																		}*/
																	}
																	else if (projectile.ai[0] == 1f)
																	{
																		projectile.tileCollide = true;
																		float[] var_2_2087A_cp_0 = projectile.localAI;
																		int var_2_2087A_cp_1 = 1;
																		float num73 = var_2_2087A_cp_0[var_2_2087A_cp_1];
																		var_2_2087A_cp_0[var_2_2087A_cp_1] = num73 + 1f;
																		float num757 = 180f;
																		float num758 = 0f;
																		float num759 = 30f;
																		/*if (projectile.localAI[1] == num757)
																		{
																			projectile.Kill();
																			return;
																		}*/
																		if (projectile.localAI[1] >= num758 && projectile.localAI[1] < num758 + num759)
																		{
																			Vector2 v3 = Main.player[(int)projectile.ai[1]].Center - projectile.Center;
																			float num760 = projectile.velocity.ToRotation();
																			float num761 = v3.ToRotation();
																			double num762 = (double)(num761 - num760);
																			if (num762 > 3.1415926535897931)
																			{
																				num762 -= 6.2831853071795862;
																			}
																			if (num762 < -3.1415926535897931)
																			{
																				num762 += 6.2831853071795862;
																			}
																			projectile.velocity = projectile.velocity.RotatedBy(num762 * 0.20000000298023224, default(Vector2));
																		}
																		if (projectile.localAI[1] % 5f == 0f)
																		{
																			/*for (int num763 = 0; num763 < 4; num763 = num3 + 1)
																			{
																				Vector2 vector73 = Vector2.UnitX * -8f;
																				vector73 += -Vector2.UnitY.RotatedBy((double)((float)num763 * 3.14159274f / 4f), default(Vector2)) * new Vector2(2f, 4f);
																				vector73 = vector73.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
																				int num764 = Dust.NewDust(projectile.Center, 0, 0, 228, 0f, 0f, 0, default(Color), 1f);
																				Main.dust[num764].scale = 1.5f;
																				Main.dust[num764].noGravity = true;
																				Main.dust[num764].position = projectile.Center + vector73;
																				Main.dust[num764].velocity = projectile.velocity * 0f;
																				num3 = num763;
																			}*/
																		}
																	}
																	num3 = projectile.frameCounter + 1;
																	projectile.frameCounter = num3;
																	/*if (num3 >= 3)
																	{
																		projectile.frameCounter = 0;
																		num3 = projectile.frame + 1;
																		projectile.frame = num3;
																		if (num3 >= 3)
																		{
																			projectile.frame = 0;
																		}
																	}*/
																	int num765 = 0;
																	while ((float)num765 < 1f + projectile.ai[0])
																	{
																		Vector2 value18 = Vector2.UnitY.RotatedBy((double)projectile.rotation, default(Vector2)) * 8f * (float)(num765 + 1);
																		/*int num766 = Dust.NewDust(projectile.Center, 0, 0, 228, 0f, 0f, 0, default(Color), 1f);
																		Main.dust[num766].position = projectile.Center + value18;
																		Main.dust[num766].scale = 1f;
																		Main.dust[num766].noGravity = true;*/
																		num3 = num765;
																		num765 = num3 + 1;
																	}
																	for (int num767 = 0; num767 < 255; num767 = num3 + 1)
																	{
																		Player player5 = Main.player[num767];
																		/*if (player5.active && !player5.dead && Vector2.Distance(player5.Center, projectile.Center) <= 42f)
																		{
																			projectile.Kill();
																			return;
																		}*/
																		num3 = num767;
																	}
																	return;
		}
		public override void PostAI() {
			projectile.rotation = projectile.velocity.ToRotation();
		}
	}   
}