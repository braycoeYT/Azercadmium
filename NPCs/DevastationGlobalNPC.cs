using Microsoft.Xna.Framework;
using ReLogic.Text;
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
						npc.damage += 14;
						npc.defense += 6;
						break;
					case NPCID.EaterofWorldsHead:
						npc.lifeMax += 70;
						npc.damage += 12;
						break;
					case NPCID.EaterofWorldsBody:
						npc.lifeMax += 70;
						npc.damage += 6;
						npc.defense += 6;
						break;
					case NPCID.EaterofWorldsTail:
						npc.lifeMax += 70;
						npc.defense += 12;
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
					case NPCID.EyeofCthulhu:
						if (projectile.type == ProjectileID.FallingStar) {
							npc.life += damage;
							npc.HealEffect(damage, true);
						}
						break;
					case NPCID.EaterofWorldsBody:
						if (projectile.type == ProjectileID.Grenade || projectile.type == ProjectileID.BouncyGrenade || projectile.type == ProjectileID.StickyGrenade || projectile.type == ProjectileID.Bomb || projectile.type == ProjectileID.BombFish || projectile.type == ProjectileID.StickyBomb || projectile.type == ProjectileID.BouncyBomb || projectile.type == ProjectileID.Dynamite || projectile.type == ProjectileID.BouncyDynamite || projectile.type == ProjectileID.StickyDynamite || projectile.type == ProjectileID.HappyBomb || projectile.type == ProjectileID.RocketFireworkBlue || projectile.type == ProjectileID.RocketFireworkGreen || projectile.type == ProjectileID.RocketFireworkRed || projectile.type == ProjectileID.RocketFireworkYellow || projectile.type == ProjectileID.RocketFireworksBoxBlue || projectile.type == ProjectileID.RocketFireworksBoxGreen || projectile.type == ProjectileID.RocketFireworksBoxYellow || projectile.type == ProjectileID.RocketFireworksBoxRed || projectile.type == ProjectileID.RocketI || projectile.type == ProjectileID.RocketII || projectile.type == ProjectileID.RocketIII || projectile.type == ProjectileID.RocketIV || projectile.type == ProjectileID.RocketSkeleton || projectile.type == ProjectileID.RocketSnowmanI || projectile.type == ProjectileID.RocketSnowmanII || projectile.type == ProjectileID.RocketSnowmanIII || projectile.type == ProjectileID.RocketSnowmanIV || projectile.type == ProjectileID.GrenadeI || projectile.type == ProjectileID.GrenadeII || projectile.type == ProjectileID.GrenadeIII || projectile.type == ProjectileID.GrenadeIV || projectile.type == ProjectileID.PartyGirlGrenade) {
							npc.life += damage;
							npc.HealEffect(damage, true);
						}
						else if (projectile.penetrate == -1) {
							npc.life += damage / 2;
							npc.HealEffect(damage / 2, true);
						}
						else if (projectile.penetrate >= 10) {
							npc.life += damage / 2;
							npc.HealEffect(damage / 2, true);
						}
						else if (projectile.penetrate >= 5) {
							npc.life += damage / 4;
							npc.HealEffect(damage / 4, true);
						}
						else if (projectile.penetrate >= 2) {
							npc.life += 1;
							npc.HealEffect(1, true);
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
		int AITimer4;
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
							//lasers everywhere while spin
							if (AITimer2 % 10 == 0)
								Projectile.NewProjectile(npc.Center, new Vector2(0, 10).RotatedBy(npc.rotation), ProjectileID.DeathLaser, npc.damage / 4, 0f, Main.myPlayer);
						}
						//lasers lol
						if ((float)npc.life > (float)npc.lifeMax * 0.65f) {
							if (AITimer % (int)(240 * ((float)npc.life/(float)npc.lifeMax)) == 0)
								Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
							if (AITimer % (int)(240 * ((float)npc.life/(float)npc.lifeMax)) == 20)
								Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
							if (AITimer % (int)(240 * ((float)npc.life/(float)npc.lifeMax)) == 40)
								Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
						}
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
						if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.3f)
							AIFlag = true;
						if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.15f)
							AIFlag2 = true;
						if ((float)npc.life < (float)npc.lifeMax * 0.65f && !(npc.ai[0] == 1 || npc.ai[0] == 2))
						{
							npc.damage = 57;
							npc.defense = 6;
							for (int i = 0; i < npc.life; i += npc.lifeMax / 20) {
								npc.damage += 2;
								npc.defense += 1;
							}
							if (AITimer % 120 == 0)
							{
								if (AIFlag2) {
									Vector2 projDir = Vector2.Normalize(target.Center - npc.Center) * 8;
									Projectile.NewProjectile(npc.Center, projDir.RotatedBy(-0.54f), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, projDir.RotatedBy(-0.27f), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, projDir, ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, projDir.RotatedBy(0.27f), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, projDir.RotatedBy(0.54f), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
								}
								else if (AIFlag) {
									Vector2 projDir = Vector2.Normalize(target.Center - npc.Center) * 8;
									Projectile.NewProjectile(npc.Center, projDir.RotatedBy(-0.27f), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, projDir, ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
									Projectile.NewProjectile(npc.Center, projDir.RotatedBy(0.27f), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
								}
								else {
									Projectile.NewProjectile(npc.position, new Vector2(0, 8).RotatedBy(npc.rotation), ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
								}
							}
							if (AITimer % 5 == 0)
							Projectile.NewProjectile(npc.position, new Vector2(0, 0), mod.ProjectileType("FlameTrailEye"), npc.damage / 2, 0f, Main.myPlayer);
						}
						else {
							npc.damage = 41;
							npc.defense = 17;
						}
						//dash upgrade
						if (npc.ai[1] == 2f && npc.ai[2] == 0f) {
							npc.velocity *= 2f;
						}
							
						break;
						case NPCID.EaterofWorldsHead:
						npc.noGravity = true;
						AITimer++;
						if (AITimer % 10 == 0)
							Projectile.NewProjectile(npc.Center, new Vector2(0, -8).RotatedBy(npc.rotation + Main.rand.NextFloat(-0.25f, 0.26f)), ProjectileID.CursedFlameHostile, npc.damage / 4, 0f, Main.myPlayer);
						if (!AIFlag && npc.life < npc.lifeMax * 0.5f) {
							AIFlag = true;
							NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("VileObserver"));
						}
						break;
						case NPCID.EaterofWorldsBody:
						npc.noGravity = true;
						if (!AIFlag && npc.life < npc.lifeMax * 0.5f) {
							AIFlag = true;
							NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("VileObserver"));
						}
						break;
						case NPCID.EaterofWorldsTail:
						npc.noGravity = true;
						if (!AIFlag && npc.life < npc.lifeMax * 0.5f) {
							AIFlag = true;
							NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("VileObserver"));
						}
						break;
						case NPCID.BlazingWheel:
						AITimer++;
						if (AITimer % 5 == 0)
							Projectile.NewProjectile(npc.Center, new Vector2(0, 0), mod.ProjectileType("FlameTrailEye"), npc.damage, 0f, Main.myPlayer);
						break;
			}
		}
		public override void HitEffect(NPC npc, int hitDirection, double damage) {
			if (AzercadmiumWorld.devastation) {
				if (npc.townNPC == true && npc.life <= 0 && npc.type != NPCID.Angler) {
					if (Main.rand.Next(2) == 0)
						NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BigSkeleton);
					else
						NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BigPantlessSkeleton);
				}
				if (npc.type == NPCID.LavaSlime) {
					Vector2 projDir = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * 8;
					Projectile.NewProjectile(npc.Center, projDir, ProjectileID.Fireball, npc.damage / 4, 0f, Main.myPlayer);
				}
			}
		}
		public override void NPCLoot(NPC npc) {
			if (AzercadmiumWorld.devastation) {
				if (npc.type == NPCID.KingSlime) {
					Item.NewItem(npc.getRect(), ItemType<Items.Slime.ExtraNeonSlimyCore>());
				}
				if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || npc.type == mod.NPCType("VileObserver")) {
					if (Main.rand.Next(4) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Corruption.VileHeart>());
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