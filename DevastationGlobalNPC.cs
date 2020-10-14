using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
				}
			}
		}
		public override bool PreAI(NPC npc)
		{
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
			return true;
		}
		private void Shoot(NPC npc, int delay, float distance, int speed, int proj, int dmg, float kb, bool hostile = false, int dustID = -1)
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