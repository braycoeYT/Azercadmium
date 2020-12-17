using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Empress
{
	public class SlimeLarva : ModNPC
	{
		public override void SetStaticDefaults()  {
			DisplayName.SetDefault("Slime Larva");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 12;
			npc.height = 13;
			npc.damage = 36;
			npc.defense = 0;
			npc.lifeMax = 16;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 29;
            npc.damage = 51;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit) {
			if (Main.rand.NextBool(4))
				player.AddBuff(BuffID.Venom, Main.rand.Next(1, 3) * 60, true);
		}
		int Timer;
		int growRand = Main.rand.Next(4);
		public override void AI() {
			Timer++;
			bool flag = false;
			if (!Main.dayTime || npc.life != npc.lifeMax || (double)npc.position.Y > Main.worldSurface * 16.0 || Main.slimeRain)
			{
				flag = true;
			}
			if (npc.ai[2] > 1f)
			{
				npc.ai[2] -= 1f;
			}
			if (npc.wet)
			{
				if (npc.collideY)
				{
					npc.velocity.Y = -1f; //2
				}
				if (npc.velocity.Y < 0f && npc.ai[3] == npc.position.X)
				{
					npc.direction *= -1;
					npc.ai[2] = 200f;
				}
				if (npc.velocity.Y > 0f)
				{
					npc.ai[3] = npc.position.X;
				}		
				if (npc.velocity.Y > 2f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.9f;
				}
				npc.velocity.Y = npc.velocity.Y - 0.5f;
				if (npc.velocity.Y < -4f)
				{
					npc.velocity.Y = -4f;
				}
				if (npc.ai[2] == 1f & flag)
				{
					npc.TargetClosest(true);
				}
			}
			npc.aiAction = 0;
			if (npc.ai[2] == 0f)
			{
				npc.ai[0] = -100f;
				npc.ai[2] = 1f;
				npc.TargetClosest(true);
			}
			if (npc.velocity.Y == 0f)
			{
				if (npc.collideY && npc.oldVelocity.Y != 0f && Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					npc.position.X = npc.position.X - (npc.velocity.X + (float)npc.direction);
				}
				if (npc.ai[3] == npc.position.X)
				{
					npc.direction *= -1;
					npc.ai[2] = 200f;
				}
				npc.ai[3] = 0f;
				npc.velocity.X = npc.velocity.X * 0.8f;
				if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
				{
					npc.velocity.X = 0f;
				}
				if (flag)
				{
					npc.ai[0] += 1f;
				}
				npc.ai[0] += 1f;
				int num19 = 0;
				if (npc.ai[0] >= 0f)
				{
					num19 = 1;
				}
				if (npc.ai[0] >= -1000f && npc.ai[0] <= -500f)
				{
					num19 = 2;
				}
				if (npc.ai[0] >= -2000f && npc.ai[0] <= -1500f)
				{
					num19 = 3;
				}
				if (num19 > 0)
				{
					npc.netUpdate = true;
					if (flag && npc.ai[2] == 1f)
					{
						npc.TargetClosest(true);
					}
					if (num19 == 3)
					{
						npc.velocity.Y = -4f; //8
						npc.ai[0] = -200f;
						npc.ai[3] = npc.position.X;
					}
					else
					{
						npc.velocity.Y = -3f; //6
						npc.velocity.X = npc.velocity.X + (float)(npc.direction); //2
						npc.ai[0] = -120f;
						if (num19 == 1)
						{
							npc.ai[0] -= 1000f;
						}
						else
						{
							npc.ai[0] -= 2000f;
						}
					}
				}
				else if (npc.ai[0] >= -30f)
				{
					npc.aiAction = 1;
					return;
				}
			}
			else if (npc.target < 255 && ((npc.direction == 1 && npc.velocity.X < 3f) || (npc.direction == -1 && npc.velocity.X > -3f)))
			{
				if (npc.collideX && Math.Abs(npc.velocity.X) == 0.2f)
				{
					npc.position.X = npc.position.X - 1.4f * (float)npc.direction;
				}
				if (npc.collideY && npc.oldVelocity.Y != 0f && Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					npc.position.X = npc.position.X - (npc.velocity.X + (float)npc.direction);
				}
				if ((npc.direction == -1 && (double)npc.velocity.X < 0.01) || (npc.direction == 1 && (double)npc.velocity.X > -0.01))
				{
					npc.velocity.X = npc.velocity.X + 0.2f * (float)npc.direction;
					return;
				}
				npc.velocity.X = npc.velocity.X * 0.93f;
			}
			if ((Main.expertMode && Timer > 420 + (growRand * 60)) || (!Main.expertMode && Timer > 480 + (growRand * 60))) {
				if (npc.collideY)
				npc.position.Y -= 10;
				if (Main.expertMode)
					growRand = Main.rand.Next(7);
				else
					growRand = Main.rand.Next(3);
				if (growRand == 0) npc.Transform(NPCID.GreenSlime);
				if (growRand == 1) npc.Transform(NPCID.BlueSlime);
				if (growRand == 2) npc.Transform(NPCID.PurpleSlime);
				if (growRand == 3) npc.Transform(NPCID.RedSlime);
				if (growRand == 4) npc.Transform(NPCID.YellowSlime);
				if (growRand == 5) npc.Transform(NPCID.GreenSlime);
				if (growRand == 6) npc.Transform(NPCID.BlueSlime);
				
			}
		}
	}
}