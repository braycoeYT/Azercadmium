using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs
{
	public class DevastationGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public int[] Timer = new int[5];
		public int[] Counter = new int[4];
		private int Stop = 0;
		public override void SetDefaults(NPC npc) {
			if (AzercadmiumWorld.devastation) {
				switch (npc.type) {
					case NPCID.BlueSlime:
                        switch (npc.netID) {
                            case NPCID.Pinky:
								npc.lifeMax += 150;
							break;
						}
					break;
					case NPCID.KingSlime:
						npc.lifeMax += 600;
						//npc.damage += 4;
						break;
					case NPCID.EyeofCthulhu:
						npc.lifeMax += 700;
						//npc.damage += 4;
						npc.defense = 2;
						break;
				}
			}
		}
		public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit) {
			if (AzercadmiumWorld.devastation) {
				switch (npc.type) {
					case NPCID.BlueSlime:
                        switch (npc.netID) {
                            case NPCID.Pinky:
								if (Main.rand.Next(20) == 0) {
									damage = 0;
									projectile.velocity *= -1;
									projectile.friendly = false;
									projectile.hostile = true;
								}
							break;
						}
					break;
				}
			}
		}
		//switch (npc.type) {
		//			case NPCID.BlueSlime:
         //               switch (npc.netID) {
      //                      case NPCID.Pinky:
		//				}
//}
		public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit) {
			if (AzercadmiumWorld.devastation) { 
				switch (npc.type) {
					case NPCID.BlueSlime:
                        switch (npc.netID) {
							case NPCID.GreenSlime:
								target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(2, 6) * 60, true);
							break;
							case NPCID.BlueSlime:
								target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(2, 6) * 60, true);
							break;
							case NPCID.RedSlime:
								target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(3, 8) * 60, true);
							break;
							case NPCID.PurpleSlime:
								target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(4, 9) * 60, true);
							break;
							case NPCID.YellowSlime:
								target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(5, 11) * 60, true);
							break;
							case NPCID.BlackSlime:
								target.AddBuff(BuffID.Blackout, Main.rand.Next(1, 3) * 60, true);
							break;
							case NPCID.Pinky:
								target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(6, 12) * 60, true);
							break;
					}
					break;
					case NPCID.DemonEye:
						target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(1, 4) * 60, true);
						break;
					case NPCID.ServantofCthulhu:
						target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(1, 4) * 60, true);
						break;
					case NPCID.KingSlime:
						target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(3, 9) * 60, true);
						break;
					case NPCID.EyeofCthulhu:
						target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(3, 9) * 60, true);
						break;
				}
			}
		}
		public override bool PreAI(NPC npc)
		{
			if (AzercadmiumWorld.devastation) {
				if (Stop > 0)
            {
                Stop--;
                npc.position = npc.oldPosition;
                npc.frameCounter = 0;
            }
			switch (npc.type)
			{
				case NPCID.Pinky:
					npc.ai[0] = -2000; //nonstop bouncing
					Timer[0]++;
					if (Timer[0] > 120)
					{
						Timer[1]++;
						if (Timer[1] > 10)
						{
							Timer[1] = 0;
							Timer[2]++;
					        Shoot(npc, 10, 200, 12, ProjectileID.SpikedSlimeSpike, npc.damage / 2, 1f, true, DustID.PinkSlime);
						}
						if (Timer[2] >= 3)
						{
							Timer[0] = 0;
							Timer[2] = 0;
						}
					}
					break;
			}
			}
			return true;
		}
		int AITimer;
		int AITimer2;
		int AITimer3;
		bool AIFlag;
		bool AIFlag2;
		public override void AI(NPC npc) {
			if (AzercadmiumWorld.devastation)
			switch (npc.type)
			{
					case NPCID.DemonEye:
						if (AITimer == 0) AITimer = Main.rand.Next(1, 480);
						AITimer++;
						if (AITimer % 480 == 0 && npc.spriteDirection == 0)
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + 90), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
						else if (AITimer % 480 == 0)
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + 270), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
						break;
					case NPCID.ServantofCthulhu:
						if (AITimer == 0) AITimer = Main.rand.Next(1, 480);
						AITimer++;
						if (AITimer % 480 == 0 && npc.spriteDirection == 0)
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + 180), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
						else if (AITimer % 480 == 0)
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + 0), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
						break;
					case NPCID.KingSlime:
						AITimer++;
						if (AITimer % 300 == 299) {
							if ((double)npc.life < (double)npc.lifeMax * 0.5) {
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 100, 0, 0, mod.ProjectileType("GiantSlimeSpike"), npc.damage / 3, 0f, Main.myPlayer);
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 100, 0, 0, mod.ProjectileType("GiantSlimeSpike"), npc.damage / 3, 0f, Main.myPlayer);
							}
							Projectile.NewProjectile(npc.Center.X - 200, npc.Center.Y, 0, 0, mod.ProjectileType("GiantSlimeSpike"), npc.damage / 3, 0f, Main.myPlayer);
							Projectile.NewProjectile(npc.Center.X + 200, npc.Center.Y, 0, 0, mod.ProjectileType("GiantSlimeSpike"), npc.damage / 3, 0f, Main.myPlayer);
						}
						if (!(npc.ai[1] == 5f || npc.ai[1] == 6f)) {
							npc.ai[0] += 2f;
						}
						break;
					case NPCID.EyeofCthulhu:
						Player target = Main.player[npc.target];
						//making dance eye while spin
						AITimer++;
						if (npc.ai[0] == 1 || npc.ai[0] == 2) {
							AITimer2++;
							if (AITimer2 % 60 == 5)
								NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DreaminEye"));
						}
						//lasers lol
						if ((float)npc.life > (float)npc.lifeMax * 0.65f)
							if (AITimer % (int)(240 * ((float)npc.life/(float)npc.lifeMax)) == 0)
								Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
						//keep on dreamin
						Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						float num13 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector.X;
						float num14 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 200f - vector.Y;
						float num15 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
						float num16 = num15;
						if ((npc.position.Y + (float)npc.height < Main.player[npc.target].position.Y && num16 < 500f) || (Main.expertMode && num16 < 500f)) {
							if (npc.ai[0] == 3 && (float)npc.life < (float)npc.lifeMax * 0.65f) {
								AITimer3++;
								if (AITimer3 >= 110f) {
									AITimer3 = 0;
									NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DreaminEye"));
								}
							}
						}
						if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.25f)
							AIFlag = true;
						if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.1f)
							AIFlag2 = true;
						/*if ((float)npc.life < (float)npc.lifeMax * 0.65f && ((float)npc.life > (float)npc.lifeMax * 0.15f) && !(npc.ai[0] == 1 || npc.ai[0] == 2))
						{
							if (AITimer % (int)(240 * ((float)npc.life/(float)npc.lifeMax)) == 0)
							{
								if (AIFlag2) {
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("GiantDemonScythe"), npc.damage / 2, 0f, Main.myPlayer);
								}
								else if (AIFlag) {
									if (Main.rand.NextFloat() < .5f)
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("GiantDemonScythe"), npc.damage / 2, 0f, Main.myPlayer);
									else
										Projectile.NewProjectile(npc.position, new Vector2(0, 14).RotatedBy(npc.rotation), mod.ProjectileType("CthulhuTooth"), npc.damage / 3, 0f, Main.myPlayer);
								}
								else {
									if (Main.rand.NextFloat() < .25f)
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("GiantDemonScythe"), npc.damage / 2, 0f, Main.myPlayer);
									else
										Projectile.NewProjectile(npc.position, new Vector2(0, 14).RotatedBy(npc.rotation), mod.ProjectileType("CthulhuTooth"), npc.damage / 3, 0f, Main.myPlayer);
								}
							}
						}
						else if ((float)npc.life < (float)npc.lifeMax * 0.15f && !(npc.ai[0] == 1 || npc.ai[0] == 2))
						{
							if (AITimer % (int)(240 * 0.15f) == 0)
							{
								if (AIFlag2) {
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("GiantDemonScythe"), npc.damage / 2, 0f, Main.myPlayer);
								}
								else if (AIFlag) {
									if (Main.rand.NextFloat() < .5f)
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("GiantDemonScythe"), npc.damage / 2, 0f, Main.myPlayer);
									else
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("CthulhuTooth"), npc.damage / 3, 0f, Main.myPlayer);
								}
								else {
									if (Main.rand.NextFloat() < .25f)
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("GiantDemonScythe"), npc.damage / 2, 0f, Main.myPlayer);
									else
										Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), mod.ProjectileType("CthulhuTooth"), npc.damage / 3, 0f, Main.myPlayer);
								}
							}
						}*/
							
						break;
			}
		}
		public override void NPCLoot(NPC npc) {
			if (AzercadmiumWorld.devastation) {
				if (npc.type == NPCID.KingSlime) {
					Item.NewItem(npc.getRect(), ItemType<Items.Slime.ExtraNeonSlimyCore>());
				}
			}
		}
		private void Shoot(NPC npc, int delay, float distance, int speed, int proj, int dmg, float kb, bool hostile = false, int dustID = -1)
        {
			if (AzercadmiumWorld.devastation)
			{
				int t = npc.HasPlayerTarget ? npc.target : npc.FindClosestPlayer();
            if (t == -1)
                return;

            Player player = Main.player[t];
            //npc facing player target or if already started attack
            if (player.active && !player.dead && npc.direction == (Math.Sign(player.position.X - npc.position.X)) || Stop > 0)
            {
                if (delay != 0 && Stop == 0 && npc.Distance(player.Center) < distance)
                {
                    Stop = delay;

                    if (dustID != -1)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            Vector2 vector6 = Vector2.UnitY * 5f;
                            vector6 = vector6.RotatedBy((i - (20 / 2 - 1)) * 6.28318548f / 20) + npc.Center;
                            Vector2 vector7 = vector6 - npc.Center;
                            int d = Dust.NewDust(vector6 + vector7, 0, 0, dustID);
                            Main.dust[d].noGravity = true;
                            Main.dust[d].velocity = vector7;
                            Main.dust[d].scale = 1.5f;
                        }
                    }

                }
                else if (delay == 0 || Stop == delay / 2)
                {
                    Vector2 velocity = Vector2.Zero;

                    if (npc.Distance(player.Center) < distance || delay != 0)
                    {
                        velocity = Vector2.Normalize(player.Center - npc.Center) * speed;
                    }

                    if (velocity != Vector2.Zero)
                    {
                        int p = Projectile.NewProjectile(npc.Center, velocity, proj, dmg, kb, Main.myPlayer);
                        if (p < 1000)
                        {
                            if (hostile)
                            {
                                Main.projectile[p].friendly = false;
                                Main.projectile[p].hostile = true;
                            }
                        }

                        Counter[0] = 0;
                    } 
                }
            }
			}
        }
	}
}