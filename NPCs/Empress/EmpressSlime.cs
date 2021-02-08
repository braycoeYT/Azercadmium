using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Empress
{
	[AutoloadBossHead]
	public class EmpressSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Slime");
			Main.npcFrameCount[npc.type] = 12;
		}
        public override void SetDefaults()
		{
			npc.width = 158;
			npc.height = 172;
			npc.damage = 60;
			npc.defense = 41;
			npc.lifeMax = 35000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 16, 0, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = -1; //51 original <-- lol look at that noob using vanilla ai
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.netAlways = true;
			Mod azercadmiumMusic = ModLoader.GetMod("AzercadmiumMusic");
			if (azercadmiumMusic != null) 
				music = azercadmiumMusic.GetSoundSlot(SoundType.Music, "Sounds/Music/ImitationalAcrophobia");
			else 
				music = MusicID.Boss2;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 48000 + numPlayers * 8000;
			npc.damage = 120;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 60000 + numPlayers * 10000;
				npc.damage = 180;
			}
        }
		public override void OnHitPlayer(Player player, int damage, bool crit) {
			if (Main.rand.NextBool(2))
				player.AddBuff(BuffID.Venom, 200, true);
		}
		public override void HitEffect(int hitDirection, double damage)
        {
			if (npc.lifeMax / 2 < npc.life)
			{
				if (Main.rand.Next(20) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Empress.RoyalMotherSlime>(), 0, npc.whoAmI);
			}
			else
			{
				if (Main.rand.Next(20) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Empress.RoyalSlimer>(), 0, npc.whoAmI);
			}
			/*for (int i = 0; i < 10; i++)
			{
				int dustType = 266;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}*/
		}
		
        int Timer;
		int animationTimer;
		int flee = 0;
		int attack = 0;
		int attackMax = 0;
		int attackNum = 0;
		int attackBonus;
		int attackTimer;
		int jumpMode = 0;
		int jumpTimer = 0;
		int jumpTimer2 = 0;
		//int jumpTimer3 = 0;
		int jumpDir;
		bool attackDone = true;
		bool spawnCrown = true;
		Vector2 targetPos;

		public override void AI()
		{
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Timer++;
			//thing?

			attackBonus = 0;
			if (Main.expertMode) attackBonus = 30;
			if (AzercadmiumWorld.devastation) attackBonus = 60;

			if (spawnCrown && npc.life < npc.lifeMax / 2) {
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<AngeryCrown>());
				spawnCrown = false;
			}

			//start of thing

			float num234 = 1f;
						bool flag8 = false;
						bool flag9 = false;
						npc.aiAction = 0;
						if (npc.ai[3] == 0f && npc.life > 0)
						{
							npc.ai[3] = (float)npc.lifeMax;
						}
						if (npc.localAI[3] == 0f && Main.netMode != 1)
						{
							npc.ai[0] = -100f;
							npc.localAI[3] = 1f;
							npc.TargetClosest(true);
							npc.netUpdate = true;
						}
						if (Main.player[npc.target].dead)
						{
							npc.TargetClosest(true);
							if (Main.player[npc.target].dead)
							{
								npc.timeLeft = 0;
								if (Main.player[npc.target].Center.X < npc.Center.X)
								{
									npc.direction = 1;
								}
								else
								{
									npc.direction = -1;
								}
							}
						}
						if (!Main.player[npc.target].dead && npc.ai[2] >= 300f && npc.ai[1] < 5f && npc.velocity.Y == 0f)
						{
							npc.ai[2] = 0f;
							npc.ai[0] = 0f;
							npc.ai[1] = 5f;
							if (Main.netMode != 1)
							{
								npc.TargetClosest(false);
								Point point3 = npc.Center.ToTileCoordinates();
								Point point4 = Main.player[npc.target].Center.ToTileCoordinates();
								Vector2 vector30 = Main.player[npc.target].Center - npc.Center;
								int num235 = 10;
								int num236 = 0;
								int num237 = 7;
								int num238 = 0;
								bool flag10 = false;
								if (vector30.Length() > 2000f)
								{
									flag10 = true;
									num238 = 100;
								}
								while (!flag10 && num238 < 100)
								{
									num238++;
									int num239 = Main.rand.Next(point4.X - num235, point4.X + num235 + 1);
									int num240 = Main.rand.Next(point4.Y - num235, point4.Y + 1);
									if ((num240 < point4.Y - num237 || num240 > point4.Y + num237 || num239 < point4.X - num237 || num239 > point4.X + num237) && (num240 < point3.Y - num236 || num240 > point3.Y + num236 || num239 < point3.X - num236 || num239 > point3.X + num236) && !Main.tile[num239, num240].nactive())
									{
										int num241 = num240;
										int num242 = 0;
										bool flag11 = Main.tile[num239, num241].nactive() && Main.tileSolid[(int)Main.tile[num239, num241].type] && !Main.tileSolidTop[(int)Main.tile[num239, num241].type];
										if (flag11)
										{
											num242 = 1;
										}
										else
										{
											while (num242 < 150 && num241 + num242 < Main.maxTilesY)
											{
												int num243 = num241 + num242;
												bool flag12 = Main.tile[num239, num243].nactive() && Main.tileSolid[(int)Main.tile[num239, num243].type] && !Main.tileSolidTop[(int)Main.tile[num239, num243].type];
												if (flag12)
												{
													num242--;
													break;
												}
												int num = num242;
												num242 = num + 1;
											}
										}
										num240 += num242;
										bool flag13 = true;
										if (flag13 && Main.tile[num239, num240].lava())
										{
											flag13 = false;
										}
										if (flag13 && !Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
										{
											flag13 = false;
										}
										if (flag13)
										{
											npc.localAI[1] = (float)(num239 * 16 + 8);
											npc.localAI[2] = (float)(num240 * 16 + 16);
											break;
										}
									}
								}
								if (num238 >= 100)
								{
									Vector2 bottom = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].Bottom;
									npc.localAI[1] = bottom.X;
									npc.localAI[2] = bottom.Y;
								}
							}
						}
						if (!Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
						{
							float[] var_9_AE8B_cp_0 = npc.ai;
							int var_9_AE8B_cp_1 = 2;
							float num244 = var_9_AE8B_cp_0[var_9_AE8B_cp_1];
							var_9_AE8B_cp_0[var_9_AE8B_cp_1] = num244 + 1f;
						}
						if (Math.Abs(npc.Top.Y - Main.player[npc.target].Bottom.Y) > 320f)
						{
							float[] var_9_AEDF_cp_0 = npc.ai;
							int var_9_AEDF_cp_1 = 2;
							float num244 = var_9_AEDF_cp_0[var_9_AEDF_cp_1];
							var_9_AEDF_cp_0[var_9_AEDF_cp_1] = num244 + 1f;
						}
						Dust dust;
						if (npc.ai[1] == 5f)
						{
							flag8 = true;
							npc.aiAction = 1;
							float[] var_9_AF25_cp_0 = npc.ai;
							int var_9_AF25_cp_1 = 0;
							float num244 = var_9_AF25_cp_0[var_9_AF25_cp_1];
							var_9_AF25_cp_0[var_9_AF25_cp_1] = num244 + 1f;
							num234 = MathHelper.Clamp((60f - npc.ai[0]) / 60f, 0f, 1f);
							num234 = 0.5f + num234 * 0.5f;
							if (npc.ai[0] >= 60f)
							{
								flag9 = true;
							}
							if (npc.ai[0] == 60f)
							{
								//Gore.NewGore(npc.Center + new Vector2(-40f, (float)(-(float)npc.height / 2)), npc.velocity, 734, 1f);
							}
							if (npc.ai[0] >= 60f && Main.netMode != 1)
							{
								npc.Bottom = new Vector2(npc.localAI[1], npc.localAI[2]);
								npc.ai[1] = 6f;
								npc.ai[0] = 0f;
								npc.netUpdate = true;
							}
							if (Main.netMode == 1 && npc.ai[0] >= 120f)
							{
								npc.ai[1] = 6f;
								npc.ai[0] = 0f;
							}
							if (!flag9)
							{
								int num;
								for (int num245 = 0; num245 < 10; num245 = num + 1)
								{
									int num246 = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, 183, npc.velocity.X, npc.velocity.Y, 150, new Color(255, 0, 0, 80), 2f);
									Main.dust[num246].noGravity = true;
									dust = Main.dust[num246];
									dust.velocity *= 0.5f;
									num = num245;
								}
							}
						}
						else if (npc.ai[1] == 6f)
						{
							flag8 = true;
							npc.aiAction = 0;
							float[] var_9_B163_cp_0 = npc.ai;
							int var_9_B163_cp_1 = 0;
							float num244 = var_9_B163_cp_0[var_9_B163_cp_1];
							var_9_B163_cp_0[var_9_B163_cp_1] = num244 + 1f;
							num234 = MathHelper.Clamp(npc.ai[0] / 30f, 0f, 1f);
							num234 = 0.5f + num234 * 0.5f;
							if (npc.ai[0] >= 30f && Main.netMode != 1)
							{
								npc.ai[1] = 0f;
								npc.ai[0] = 0f;
								npc.netUpdate = true;
								npc.TargetClosest(true);
							}
							if (Main.netMode == 1 && npc.ai[0] >= 60f)
							{
								npc.ai[1] = 0f;
								npc.ai[0] = 0f;
								npc.TargetClosest(true);
							}
							int num;
							for (int num247 = 0; num247 < 10; num247 = num + 1)
							{
								int num248 = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, 183, npc.velocity.X, npc.velocity.Y, 150, new Color(78, 136, 255, 80), 2f);
								Main.dust[num248].noGravity = true;
								dust = Main.dust[num248];
								dust.velocity *= 2f;
								num = num247;
							}
						}
						npc.dontTakeDamage = (npc.hide = flag9);
						if (npc.velocity.Y == 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.8f;
							if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
							{
								npc.velocity.X = 0f;
							}
							if (!flag8)
							{
								npc.ai[0] += 2f;
								if ((double)npc.life < (double)npc.lifeMax * 0.8)
								{
									npc.ai[0] += 1f;
								}
								if ((double)npc.life < (double)npc.lifeMax * 0.6)
								{
									npc.ai[0] += 1f;
								}
								if ((double)npc.life < (double)npc.lifeMax * 0.4)
								{
									npc.ai[0] += 2f;
								}
								if ((double)npc.life < (double)npc.lifeMax * 0.2)
								{
									npc.ai[0] += 3f;
								}
								if ((double)npc.life < (double)npc.lifeMax * 0.1)
								{
									npc.ai[0] += 4f;
								}
								if (npc.ai[0] >= 0f)
								{
									npc.netUpdate = true;
									npc.TargetClosest(true);
									if (npc.ai[1] == 3f)
									{
										npc.velocity.Y = -13f;
										npc.velocity.X = npc.velocity.X + 3.5f * (float)npc.direction;
										npc.ai[0] = -200f;
										npc.ai[1] = 0f;
									}
									else if (npc.ai[1] == 2f)
									{
										npc.velocity.Y = -6f;
										npc.velocity.X = npc.velocity.X + 4.5f * (float)npc.direction;
										npc.ai[0] = -120f;
										npc.ai[1] += 1f;
									}
									else
									{
										npc.velocity.Y = -8f;
										npc.velocity.X = npc.velocity.X + 4f * (float)npc.direction;
										npc.ai[0] = -120f;
										npc.ai[1] += 1f;
									}
								}
								else if (npc.ai[0] >= -30f)
								{
									npc.aiAction = 1;
								}
							}
						}
						else if (npc.target < 255 && ((npc.direction == 1 && npc.velocity.X < 3f) || (npc.direction == -1 && npc.velocity.X > -3f)))
						{
							if ((npc.direction == -1 && (double)npc.velocity.X < 0.1) || (npc.direction == 1 && (double)npc.velocity.X > -0.1))
							{
								npc.velocity.X = npc.velocity.X + 0.2f * (float)npc.direction;
							}
							else
							{
								npc.velocity.X = npc.velocity.X * 0.93f;
							}
						}
						int num249 = Dust.NewDust(npc.position, npc.width, npc.height, 183, npc.velocity.X, npc.velocity.Y, 255, new Color(255, 0, 0, 80), npc.scale * 1.2f);
						Main.dust[num249].noGravity = true;
						dust = Main.dust[num249];
						dust.velocity *= 0.5f;
						if (npc.life > 0)
						{
							float num250 = (float)npc.life / (float)npc.lifeMax;
							num250 = num250 * 0.5f + 0.75f;
							num250 *= num234;
							if (num250 != npc.scale)
							{
								npc.position.X = npc.position.X + (float)(npc.width / 2);
								npc.position.Y = npc.position.Y + (float)npc.height;
								npc.scale = num250;
								npc.width = (int)(98f * npc.scale);
								npc.height = (int)(92f * npc.scale);
								npc.position.X = npc.position.X - (float)(npc.width / 2);
								npc.position.Y = npc.position.Y - (float)npc.height;
							}
						}

			//start of jump ai
			if (jumpMode == 0)
			{
				npc.noGravity = false;
				npc.noTileCollide = false;
				if (npc.lifeMax / 2 > npc.life)
				jumpTimer2 = 7;
				else
				jumpTimer2 = 6;
				if (Main.expertMode)
				jumpTimer2 += 2;
				jumpTimer++;
				if (jumpTimer > 600)
					jumpMode = 1;
				//jumpTimer3 = 0;
			}
			if (jumpMode == 1)
			{
				npc.noGravity = false;
				npc.noTileCollide = false;
				if (target.position.X > npc.position.X)
				jumpDir = 0;
				else
				jumpDir = 1;
				jumpMode = 2;
			}
			if (jumpMode == 2)
			{
				jumpTimer++;
				if (jumpTimer % 30 == 0)
				jumpTimer2 += 1;
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (jumpDir == 0)
					npc.velocity.X = jumpTimer2;
				else
					npc.velocity.X = jumpTimer2 * -1;
				if (npc.position.Y < target.position.Y - 150 && Math.Abs(npc.position.X - target.position.X) < 10)
				jumpMode = 3;
				if (npc.position.X > target.position.X)
					jumpDir = 1;
				else
					jumpDir = 0;
				/*if (jumpDir == 0)
				{
					npc.velocity.X = jumpTimer2;
					if (npc.position.X > target.position.X - 5 && npc.position.Y < target.position.Y)
					jumpMode = 3;
				}
				if (jumpDir == 1)
				{
					npc.velocity.X = jumpTimer2 * -1;
					if (npc.position.X < target.position.X + 5 && npc.position.Y < target.position.Y)
					jumpMode = 3;
				}*/
				if (npc.position.Y < target.position.Y - 400)
					npc.position.Y = target.position.Y - 400;
				if (npc.lifeMax / 2 > npc.life && Main.expertMode)
				npc.velocity.Y = -10;
				else if (npc.lifeMax / 2 > npc.life || Main.expertMode)
				npc.velocity.Y = -8;
				else
				npc.velocity.Y = -7;
			}
			if (jumpMode == 3)
			{
				npc.noGravity = false;
				if (npc.position.Y < target.position.Y)
					npc.noTileCollide = true;
				else
					npc.noTileCollide = false;
				npc.velocity.X = 0;
				npc.velocity.Y = 8;
				//jumpTimer3++;
				if (npc.position.Y > target.position.Y) //+ 600 //npc.collideY || 
				jumpMode = 4;
			}
			if (jumpMode == 4)
			{
				jumpDir = 0;
				jumpTimer = 0;
				jumpTimer2 = 0;
				//jumpTimer3 = 0;
				jumpMode = 0;
				Main.PlaySound(SoundID.Item62);
				if (Main.expertMode)
				{
					for (float rotation = 0; rotation < 360;)
					{
						rotation += 30;
						Projectile.NewProjectile(npc.Center, new Vector2(0, 5).RotatedBy((Math.PI / 180) * rotation, default), mod.ProjectileType("EmpressSpike"), 35, 1f, Main.myPlayer);
					}
				}
			}
			//end of jump ai
			if (npc.lifeMax / 2 > npc.life)
			{
				if (Main.expertMode)
				{
					int healSpeed = (int)(npc.life / 400);
					if (healSpeed != 0)
					{
						if (Timer % healSpeed == 0)
						{
							npc.life += 1;
							if (npc.life > npc.lifeMax)
								npc.life = npc.lifeMax;
						}
					}
					else
						npc.life += 1;
				}
				else
				{
					int healSpeed = (int)(npc.life / 500);
					if (healSpeed != 0)
					{
						if (Timer % healSpeed == 0)
						{
							npc.life += 1;
							if (npc.life > npc.lifeMax)
								npc.life = npc.lifeMax;
						}
					}
					else
						npc.life += 1;
				}
			}
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 7f;
                if (flee >= 450)
                    npc.active = false;
            }
			
			
			targetPos = Main.player[npc.target].Center;

			if (Timer % 800 == 0)
			{
				float numberNPC = Main.rand.Next(1, 4);
				for (int i = 0; i < numberNPC; i++)
				{
					Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
				}
			}
			if (attackDone) {
				attack = Main.rand.Next(3);
				attackDone = false;
				attackMax = Main.rand.Next(3, 7);
				attackNum = 0;
				attackTimer = 0;
			}
			switch (attack) {
				case 0:
					attackTimer++; 
					if (attackTimer == 1)
					{
						float numberNPC = Main.rand.Next(1, 4);
						for (int i = 0; i < numberNPC; i++)
						{
							Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
						}
					}
					if (attackTimer >= 120 - attackBonus)
						attackDone = true;
					break;
				case 1:
					attackTimer++;
					if (attackTimer % (60 - (attackBonus / 3)) == 0) {
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, mod.ProjectileType("EmpressGlob"), 32, 10, Main.myPlayer);
						attackNum += 1;
					}
					if (attackMax < attackNum)
						attackDone = true;
					break;
				case 2:
					attackTimer++;
					if (attackTimer == 1) {
						float numberProjectiles = Main.rand.Next(5, 10);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 32, 2, Main.myPlayer);
						}
					}
					if (attackTimer >= 120 - attackBonus)
						attackDone = true;
					break;
			}
			if (Timer % 4 == 0)
				animationTimer++;
			if (animationTimer > 5)
				animationTimer = 0;
			if (npc.life > npc.lifeMax * 0.5f)
				npc.frame.Y = animationTimer * 178;
			else
				npc.frame.Y = 1068 + animationTimer * 178;
		}
		public override void NPCLoot() {
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Empress.EmpressBag>());
			else {
				int rand = Main.rand.Next(3);
				switch (rand)
				{
					case 0:
						Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Empress.Exallite>());
						break;
					case 1:
						Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Empress.RoyalSlimeGun>());
						break;
					case 2:
						Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Empress.SacredCarrotTome>());
						break;
				}
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Empress.EmpressShard>(), Main.rand.Next(9, 15));
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Elemental.ElementalGoop>(), Main.rand.Next(30, 61));
			}
			AzercadmiumWorld.downedEmpress = true;
		}
		public override void BossLoot(ref string name, ref int potionType) {
			potionType = ItemID.GreaterHealingPotion;
		}
	}
}