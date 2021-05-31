using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Titan
{
	public class TitanTracker : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan's Tracker");
		}
        public override void SetDefaults() {
			npc.value = 0f;
			npc.width = 28;
			npc.height = 28;
			npc.aiStyle = -1;
			npc.lifeMax = 45;
			npc.damage = 31;
			npc.defense = 2;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
        }
		int Timer = Main.rand.Next(1, 480);
		int aiStyleClone = NPCID.Probe;
		public override void AI() {
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
			}
			float num = 6f;
			float num2 = 0.05f;
			if (aiStyleClone == 6 || aiStyleClone == 173)
			{
				num = 4f;
				num2 = 0.02f;
				if (aiStyleClone == 6 && Main.expertMode)
				{
					num2 = 0.035f;
				}
			}
			else if (aiStyleClone == 94)
			{
				num = 4.2f;
				num2 = 0.022f;
			}
			else if (aiStyleClone == 252)
			{
				if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
				{
					num = 6f;
					num2 = 0.1f;
				}
				else
				{
					num2 = 0.01f;
					num = 2f;
				}
			}
			else if (aiStyleClone == 42 || (aiStyleClone >= 231 && aiStyleClone <= 235))
			{
				num = 3.5f;
				num2 = 0.021f;
				if (aiStyleClone == 231)
				{
					num = 3f;
					num2 = 0.017f;
				}
				num *= 1f - npc.scale;
				num2 *= 1f - npc.scale;
			}
			else if (aiStyleClone == 205)
			{
				num = 3.25f;
				num2 = 0.018f;
			}
			else if (aiStyleClone == 176)
			{
				num = 4f;
				num2 = 0.017f;
			}
			else if (aiStyleClone == 23)
			{
				num = 1f;
				num2 = 0.03f;
			}
			else if (aiStyleClone == 5)
			{
				num = 5f;
				num2 = 0.03f;
			}
			else if (aiStyleClone == 210 || aiStyleClone == 211)
			{
				npc.localAI[0] += 1f;
				float num3 = (npc.localAI[0] - 60f) / 60f;
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				else
				{
					if (npc.velocity.X > 6f)
					{
						npc.velocity.X = 6f;
					}
					if (npc.velocity.X < -6f)
					{
						npc.velocity.X = -6f;
					}
					if (npc.velocity.Y > 6f)
					{
						npc.velocity.Y = 6f;
					}
					if (npc.velocity.Y < -6f)
					{
						npc.velocity.Y = -6f;
					}
				}
				num = 5f;
				num2 = 0.1f;
				num2 *= num3;
			}
			Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float num4 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
			float num5 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
			num4 = (float)((int)(num4 / 8f) * 8);
			num5 = (float)((int)(num5 / 8f) * 8);
			vector.X = (float)((int)(vector.X / 8f) * 8);
			vector.Y = (float)((int)(vector.Y / 8f) * 8);
			num4 -= vector.X;
			num5 -= vector.Y;
			float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
			float num7 = num6;
			bool flag = false;
			if (num6 > 600f)
			{
				flag = true;
			}
			if (num6 == 0f)
			{
				num4 = npc.velocity.X;
				num5 = npc.velocity.Y;
			}
			else
			{
				num6 = num / num6;
				num4 *= num6;
				num5 *= num6;
			}
			if (aiStyleClone == 6 || aiStyleClone == 42 || aiStyleClone == 94 || aiStyleClone == 139 || aiStyleClone == 173 || aiStyleClone == 176 || aiStyleClone == 205 || aiStyleClone == 210 || aiStyleClone == 211 || (aiStyleClone >= 231 && aiStyleClone <= 235))
			{
				if (num7 > 100f || aiStyleClone == 42 || aiStyleClone == 94 || aiStyleClone == 176 || aiStyleClone == 210 || aiStyleClone == 211 || (aiStyleClone >= 231 && aiStyleClone <= 235))
				{
					npc.ai[0] += 1f;
					if (npc.ai[0] > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + 0.023f;
					}
					else
					{
						npc.velocity.Y = npc.velocity.Y - 0.023f;
					}
					if (npc.ai[0] < -100f || npc.ai[0] > 100f)
					{
						npc.velocity.X = npc.velocity.X + 0.023f;
					}
					else
					{
						npc.velocity.X = npc.velocity.X - 0.023f;
					}
					if (npc.ai[0] > 200f)
					{
						npc.ai[0] = -200f;
					}
				}
				if (num7 < 150f && (aiStyleClone == 6 || aiStyleClone == 94 || aiStyleClone == 173))
				{
					npc.velocity.X = npc.velocity.X + num4 * 0.007f;
					npc.velocity.Y = npc.velocity.Y + num5 * 0.007f;
				}
			}
			if (Main.player[npc.target].dead)
			{
				num4 = (float)npc.direction * num / 2f;
				num5 = -num / 2f;
			}
			if (npc.velocity.X < num4)
			{
				npc.velocity.X = npc.velocity.X + num2;
				if (aiStyleClone != 173 && aiStyleClone != 6 && aiStyleClone != 42 && (aiStyleClone < 231 || aiStyleClone > 235) && aiStyleClone != 94 && aiStyleClone != 139 && npc.velocity.X < 0f && num4 > 0f)
				{
					npc.velocity.X = npc.velocity.X + num2;
				}
			}
			else if (npc.velocity.X > num4)
			{
				npc.velocity.X = npc.velocity.X - num2;
				if (aiStyleClone != 173 && aiStyleClone != 6 && aiStyleClone != 42 && (aiStyleClone < 231 || aiStyleClone > 235) && aiStyleClone != 94 && aiStyleClone != 139 && npc.velocity.X > 0f && num4 < 0f)
				{
					npc.velocity.X = npc.velocity.X - num2;
				}
			}
			if (npc.velocity.Y < num5)
			{
				npc.velocity.Y = npc.velocity.Y + num2;
				if (aiStyleClone != 173 && aiStyleClone != 6 && aiStyleClone != 42 && (aiStyleClone < 231 || aiStyleClone > 235) && aiStyleClone != 94 && aiStyleClone != 139 && npc.velocity.Y < 0f && num5 > 0f)
				{
					npc.velocity.Y = npc.velocity.Y + num2;
				}
			}
			else if (npc.velocity.Y > num5)
			{
				npc.velocity.Y = npc.velocity.Y - num2;
				if (aiStyleClone != 173 && aiStyleClone != 6 && aiStyleClone != 42 && (aiStyleClone < 231 || aiStyleClone > 235) && aiStyleClone != 94 && aiStyleClone != 139 && npc.velocity.Y > 0f && num5 < 0f)
				{
					npc.velocity.Y = npc.velocity.Y - num2;
				}
			}
			if (aiStyleClone == 23)
			{
				if (num4 > 0f)
				{
					npc.spriteDirection = 1;
					npc.rotation = (float)Math.Atan2((double)num5, (double)num4);
				}
				else if (num4 < 0f)
				{
					npc.spriteDirection = -1;
					npc.rotation = (float)Math.Atan2((double)num5, (double)num4) + 3.14f;
				}
			}
			else if (aiStyleClone == 139)
			{
				npc.localAI[0] += 1f;
				if (npc.justHit)
				{
					npc.localAI[0] = 0f;
				}
				if (Main.netMode != NetmodeID.MultiplayerClient && npc.localAI[0] >= 120f)
				{
					npc.localAI[0] = 0f;
					if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						int num8 = 25;
						if (Main.expertMode)
						{
							num8 = 22;
						}
						int num9 = ModContent.ProjectileType<Projectiles.Titan.TitanBolt>(); //84
						Projectile.NewProjectile(vector.X, vector.Y, num4, num5, num9, num8, 0f, Main.myPlayer, 0f, 0f);
					}
				}
				int arg_A81_0 = (int)npc.position.X + npc.width / 2;
				int num10 = (int)npc.position.Y + npc.height / 2;
				int arg_A8B_0 = arg_A81_0 / 16;
				num10 /= 16;
				if (!WorldGen.SolidTile(arg_A8B_0, num10))
				{
					Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);
				}
				if (num4 > 0f)
				{
					npc.spriteDirection = 1;
					npc.rotation = (float)Math.Atan2((double)num5, (double)num4);
				}
				if (num4 < 0f)
				{
					npc.spriteDirection = -1;
					npc.rotation = (float)Math.Atan2((double)num5, (double)num4) + 3.14f;
				}
			}
			else if (aiStyleClone == 6 || aiStyleClone == 94 || aiStyleClone == 173)
			{
				npc.rotation = (float)Math.Atan2((double)num5, (double)num4) - 1.57f;
			}
			else if (aiStyleClone == 42 || aiStyleClone == 176 || aiStyleClone == 205 || (aiStyleClone >= 231 && aiStyleClone <= 235))
			{
				if (npc.velocity.X > 0f)
				{
					npc.spriteDirection = 1;
				}
				if (npc.velocity.X < 0f)
				{
					npc.spriteDirection = -1;
				}
				npc.rotation = npc.velocity.X * 0.1f;
			}
			else
			{
				npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
			}
			if (aiStyleClone == 6 || aiStyleClone == 23 || aiStyleClone == 42 || aiStyleClone == 94 || aiStyleClone == 139 || aiStyleClone == 173 || aiStyleClone == 176 || aiStyleClone == 205 || aiStyleClone == 210 || aiStyleClone == 211 || (aiStyleClone >= 231 && aiStyleClone <= 235))
			{
				float num11 = 0.7f;
				if (aiStyleClone == 6 || aiStyleClone == 173)
				{
					num11 = 0.4f;
				}
				if (npc.collideX)
				{
					npc.netUpdate = true;
					npc.velocity.X = npc.oldVelocity.X * -num11;
					if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
					{
						npc.velocity.X = 2f;
					}
					if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
					{
						npc.velocity.X = -2f;
					}
				}
				if (npc.collideY)
				{
					npc.netUpdate = true;
					npc.velocity.Y = npc.oldVelocity.Y * -num11;
					if (npc.velocity.Y > 0f && (double)npc.velocity.Y < 1.5)
					{
						npc.velocity.Y = 2f;
					}
					if (npc.velocity.Y < 0f && (double)npc.velocity.Y > -1.5)
					{
						npc.velocity.Y = -2f;
					}
				}
				if (aiStyleClone == 23)
				{
					int num12 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X, npc.position.Y - npc.velocity.Y), npc.width, npc.height, 6, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num12].noGravity = true;
					Dust expr_EC5_cp_0_cp_0 = Main.dust[num12];
					expr_EC5_cp_0_cp_0.velocity.X = expr_EC5_cp_0_cp_0.velocity.X * 0.3f;
					Dust expr_EE0_cp_0_cp_0 = Main.dust[num12];
					expr_EE0_cp_0_cp_0.velocity.Y = expr_EE0_cp_0_cp_0.velocity.Y * 0.3f;
				}
				else if (aiStyleClone != 42 && aiStyleClone != 139 && aiStyleClone != 176 && aiStyleClone != 205 && aiStyleClone != 210 && aiStyleClone != 211 && aiStyleClone != 252 && (aiStyleClone < 231 || aiStyleClone > 235) && Main.rand.Next(20) == 0)
				{
					int num13 = 18;
					if (aiStyleClone == 173)
					{
						num13 = 5;
					}
					int num14 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), num13, npc.velocity.X, 2f, 75, npc.color, npc.scale);
					Dust expr_1013_cp_0_cp_0 = Main.dust[num14];
					expr_1013_cp_0_cp_0.velocity.X = expr_1013_cp_0_cp_0.velocity.X * 0.5f;
					Dust expr_102E_cp_0_cp_0 = Main.dust[num14];
					expr_102E_cp_0_cp_0.velocity.Y = expr_102E_cp_0_cp_0.velocity.Y * 0.1f;
				}
			}
			else if (aiStyleClone != 252 && Main.rand.Next(40) == 0)
			{
				int num15 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
				Dust expr_10D4_cp_0_cp_0 = Main.dust[num15];
				expr_10D4_cp_0_cp_0.velocity.X = expr_10D4_cp_0_cp_0.velocity.X * 0.5f;
				Dust expr_10EF_cp_0_cp_0 = Main.dust[num15];
				expr_10EF_cp_0_cp_0.velocity.Y = expr_10EF_cp_0_cp_0.velocity.Y * 0.1f;
			}
			if ((aiStyleClone == 6 || aiStyleClone == 94 || aiStyleClone == 173) && npc.wet)
			{
				if (npc.velocity.Y > 0f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.95f;
				}
				npc.velocity.Y = npc.velocity.Y - 0.3f;
				if (npc.velocity.Y < -2f)
				{
					npc.velocity.Y = -2f;
				}
			}
			if (aiStyleClone == 205 && npc.wet)
			{
				if (npc.velocity.Y > 0f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.95f;
				}
				npc.velocity.Y = npc.velocity.Y - 0.5f;
				if (npc.velocity.Y < -4f)
				{
					npc.velocity.Y = -4f;
				}
				npc.TargetClosest(true);
			}
			if (aiStyleClone == 42 || aiStyleClone == 176 || (aiStyleClone >= 231 && aiStyleClone <= 235))
			{
				if (npc.wet)
				{
					if (npc.velocity.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y * 0.95f;
					}
					npc.velocity.Y = npc.velocity.Y - 0.5f;
					if (npc.velocity.Y < -4f)
					{
						npc.velocity.Y = -4f;
					}
					npc.TargetClosest(true);
				}
				if (npc.ai[1] == 101f)
				{
					Main.PlaySound(SoundID.Item17, npc.position);
					npc.ai[1] = 0f;
				}
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					npc.ai[1] += (float)Main.rand.Next(5, 20) * 0.1f * npc.scale;
					if (aiStyleClone == 176)
					{
						npc.ai[1] += (float)Main.rand.Next(5, 20) * 0.1f * npc.scale;
					}
					if (Main.player[npc.target].stealth == 0f && Main.player[npc.target].itemAnimation == 0)
					{
						npc.ai[1] = 0f;
					}
					if (npc.ai[1] >= 130f)
					{
						if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
						{
							float num16 = 8f;
							Vector2 vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)(npc.height / 2));
							float num17 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector2.X + (float)Main.rand.Next(-20, 21);
							float num18 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector2.Y + (float)Main.rand.Next(-20, 21);
							if ((num17 < 0f && npc.velocity.X < 0f) || (num17 > 0f && npc.velocity.X > 0f))
							{
								float num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
								num19 = num16 / num19;
								num17 *= num19;
								num18 *= num19;
								int num20 = (int)(10f * npc.scale);
								if (aiStyleClone == 176)
								{
									num20 = (int)(30f * npc.scale);
								}
								int num21 = 55;
								int num22 = Projectile.NewProjectile(vector2.X, vector2.Y, num17, num18, num21, num20, 0f, Main.myPlayer, 0f, 0f);
								Main.projectile[num22].timeLeft = 300;
								npc.ai[1] = 101f;
								npc.netUpdate = true;
							}
							else
							{
								npc.ai[1] = 0f;
							}
						}
						else
						{
							npc.ai[1] = 0f;
						}
					}
				}
			}
			if (aiStyleClone == 139 & flag)
			{
				if ((npc.velocity.X > 0f && num4 > 0f) || (npc.velocity.X < 0f && num4 < 0f))
				{
					if (Math.Abs(npc.velocity.X) < 12f)
					{
						npc.velocity.X = npc.velocity.X * 1.05f;
					}
				}
				else
				{
					npc.velocity.X = npc.velocity.X * 0.9f;
				}
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && aiStyleClone == 94 && !Main.player[npc.target].dead)
			{
				if (npc.justHit)
				{
					npc.localAI[0] = 0f;
				}
				npc.localAI[0] += 1f;
				if (npc.localAI[0] == 180f)
				{
					if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2) + npc.velocity.X), (int)(npc.position.Y + (float)(npc.height / 2) + npc.velocity.Y), 112, 0, 0f, 0f, 0f, 0f, 255);
					}
					npc.localAI[0] = 0f;
				}
			}
			/*if ((Main.dayTime && aiStyleClone != 173 && aiStyleClone != 6 && aiStyleClone != 23 && aiStyleClone != 42 && aiStyleClone != 94 && aiStyleClone != 176 && aiStyleClone != 205 && aiStyleClone != 210 && aiStyleClone != 211 && aiStyleClone != 252 && (aiStyleClone < 231 || aiStyleClone > 235)) || Main.player[npc.target].dead)
			{
				npc.velocity.Y = npc.velocity.Y - num2 * 2f;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
			}*/
			if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
			{
				npc.netUpdate = true;
			}
		}
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 2; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void NPCLoot() {
			for (int i = 0; i < 5; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}