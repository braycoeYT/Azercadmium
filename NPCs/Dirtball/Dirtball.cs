using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Dirtball
{
	[AutoloadBossHead]
	public class Dirtball : ModNPC
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtball");
			Main.npcFrameCount[npc.type] = 16;
		}
        public override void SetDefaults() {
			npc.width = 138;
			npc.height = 110; //144
			npc.damage = 20;
			npc.lifeMax = 900;
			npc.defense = 10;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = Item.buyPrice(0, 0, 75, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.lavaImmune = true;
			Mod azercadmiumMusic = ModLoader.GetMod("AzercadmiumMusic");
			if (azercadmiumMusic != null) 
				music = azercadmiumMusic.GetSoundSlot(SoundType.Music, "Sounds/Music/MechanicalMud");
			else 
				music = MusicID.Boss3;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 1250;
            npc.damage = 32;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 1600;
				npc.damage = 52;
			}
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (Main.expertMode)
				shieldValue -= 0.008f;
			else
				shieldValue -= 0.01f;
			
			for (int i = 0; i < 10; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		float shieldValue = 1f;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		bool chat1 = !AzercadmiumWorld.downedDirtball;
		Player target;
		int difficultyBonus;
		float num321;
		float num322;
		bool dashDone = true;
		bool summonedDirtBlocks = Main.expertMode;
		bool summonedDirtboi = true;
		int dashTimer = 0;
		int summonNum = 0;
		public override void AI() {
			AzercadmiumGlobalNPC.dirtballBoss = npc.whoAmI;
			//npc.takenDamageMultiplier = 1 - shieldValue;
			if (AzercadmiumWorld.devastation) difficultyBonus = 60;
			else if (Main.expertMode) difficultyBonus = 30;
			else difficultyBonus = 0;
			Timer++;
			if (summonedDirtBlocks) {
				int dirtBlockCount = 75;
				if (AzercadmiumWorld.devastation) dirtBlockCount = 90;
				for (int i = 0; i < dirtBlockCount; i++) {
					NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-60, 61), (int)npc.Center.Y + Main.rand.Next(-60, 61), mod.NPCType("DirtBlock"));
					summonedDirtBlocks = false;
				}
			}
			if (summonedDirtboi) {
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Dirtboi"));
				summonedDirtboi = false;
			}
			npc.TargetClosest(true);
			/*if (chat1 && GetInstance<AzercadmiumConfig>().dirtballHint) {
				Color messageColor = Color.SaddleBrown;
				string chat = "Dirtball's shield gives him complete damage reduction! The shield will weaken with every hit.";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
				chat1 = false;
			}*/
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)(-3.75f + npc.scale);
			npc.rotation = npc.velocity.X * 0.05f;
			npc.TargetClosest(true);
			target = Main.player[npc.target];
			
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1) {
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1) {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = -10f;
                if (flee >= 450)
                    npc.active = false;
            }
			int phase = 1;
			float hpFlag = 0.4f;
			if (Main.expertMode)
				hpFlag = 0.5f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.6f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 2;
			if (phase == 2)
				npc.height = 110;
			if (Timer % 6 == 0)
				animationTimer++;
			if (animationTimer > 6)
				animationTimer = 0;
			if (phase == 1)
				npc.frame.Y = animationTimer * 164;
			if (phase == 2)
				npc.frame.Y = animationTimer * 164 + 1148;


			if (movement)
			{

				bool flag19 = false;
								if (movement) {

									if (npc.ai[2] >= 0f)
									{
										int num287 = 16;
										bool flag21 = false;
										bool flag22 = false;
										if (npc.position.X > npc.ai[0] - (float)num287 && npc.position.X < npc.ai[0] + (float)num287)
										{
											flag21 = true;
										}
										else if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
										{
											flag21 = true;
										}
										num287 += 24;
										if (npc.position.Y > npc.ai[1] - (float)num287 && npc.position.Y < npc.ai[1] + (float)num287)
										{
											flag22 = true;
										}
										if (flag21 & flag22)
										{
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 30f && num287 == 16)
											{
												flag19 = true;
											}
											if (npc.ai[2] >= 60f)
											{
												npc.ai[2] = -200f;
												npc.direction *= -1;
												npc.velocity.X = npc.velocity.X * -1.5f; //-1f
												npc.collideX = false;
											}
										}
										else
										{
											npc.ai[0] = npc.position.X;
											npc.ai[1] = npc.position.Y;
											npc.ai[2] = 0f;
										}
										npc.TargetClosest(true);
									}
									else
									{
										npc.ai[2] += 1f;
										if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
										{
											npc.direction = -1;
										}
										else
										{
											npc.direction = 1;
										}
									}
								int num288 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
								int num289 = (int)((npc.position.Y + (float)npc.height) / 16f);
								//bool flag23 = true;
								bool flag24 = false;
								int num290 = 3;

									if (npc.justHit) {
										//npc.ai[3] = 0f;
										//npc.localAI[1] = 0f;
									}
									float num291 = 10f; //7f
									Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
									float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
									float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
									float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
									num294 = num291 / num294;
									num292 *= num294;
									num293 *= num294;
									if (npc.ai[3] == 32f) {
										int num297;
										if (phase == 1 && attack != 4) num297 = Projectile.NewProjectile(vector33.X, vector33.Y, num292 / 2, num293 / 2, mod.ProjectileType("DirtGlobHostile"), 9, 0f, Main.myPlayer, 0f, 0f);
										if (phase == 2 && attack != 4) num297 = Projectile.NewProjectile(vector33.X, vector33.Y, (int)(num292 / 1.75), (int)(num293 / 1.75), ProjectileID.EyeLaser, 13, 0f, Main.myPlayer);
									}
									num290 = 8;
									if (npc.ai[3] > 0f)
									{
										npc.ai[3] += 1f;
										if (npc.ai[3] >= 64f)
										{
											npc.ai[3] = 0f;
										}
									}
									if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[3] == 0f)
									{
										npc.localAI[1] += 1f;
										if (npc.localAI[1] > 120f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && !Main.player[npc.target].npcTypeNoAggro[npc.type])
										{
											npc.localAI[1] = 0f;
											npc.ai[3] = 1f;
											npc.netUpdate = true;
										}
									}
								int num;
								for (int num316 = num289; num316 < num289 + num290; num316 = num + 1)
								{
									if (Main.tile[num288, num316] == null)
									{
										Main.tile[num288, num316] = new Tile();
									}
									if ((Main.tile[num288, num316].nactive() && Main.tileSolid[(int)Main.tile[num288, num316].type]) || Main.tile[num288, num316].liquid > 0)
									{
										if (num316 <= num289 + 1)
										{
											flag24 = true;
										}
										//flag23 = false;
										break;
									}
									num = num316;
								}
								if (Main.player[npc.target].npcTypeNoAggro[npc.type])
								{
									bool flag25 = false;
									for (int num317 = num289; num317 < num289 + num290 - 2; num317 = num + 1)
									{
										if (Main.tile[num288, num317] == null)
										{
											Main.tile[num288, num317] = new Tile();
										}
										if ((Main.tile[num288, num317].nactive() && Main.tileSolid[(int)Main.tile[num288, num317].type]) || Main.tile[num288, num317].liquid > 0)
										{
											flag25 = true;
											break;
										}
										num = num317;
									}
									npc.directionY = (!flag25).ToDirectionInt();
								}
								if (flag19)
								{
									flag24 = false;
									//flag23 = true;
										npc.velocity.Y = npc.velocity.Y + 2f;
								}
								//if (flag23)
								//{
									npc.velocity.Y = npc.velocity.Y + 0.2f;
									if (npc.velocity.Y > 2f)
									{
										npc.velocity.Y = 2f;
									}
								//}
								else
								{
									if ((npc.directionY < 0 && npc.velocity.Y > 0f) | flag24)
									{
										npc.velocity.Y = npc.velocity.Y - 0.075f;
									}
									if (npc.velocity.Y < -0.75f)
									{
										npc.velocity.Y = -0.75f;
									}
									if (npc.velocity.Y < -4f)
									{
										npc.velocity.Y = -4f;
									}
								}
								if (npc.collideX)
								{
									npc.velocity.X = npc.oldVelocity.X * -0.4f;
									if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
									{
										npc.velocity.X = 1f;
									}
									if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
									{
										npc.velocity.X = -1f;
									}
								}
								if (npc.collideY)
								{
									npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
									if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
									{
										npc.velocity.Y = 1f;
									}
									if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
									{
										npc.velocity.Y = -1f;
									}
								}
								float num319 = 4f;
								if (npc.direction == -1 && npc.velocity.X > -num319)
								{
									npc.velocity.X = npc.velocity.X - 0.1f;
									if (npc.velocity.X > num319)
									{
										npc.velocity.X = npc.velocity.X - 0.1f;
									}
									else if (npc.velocity.X > 0f)
									{
										npc.velocity.X = npc.velocity.X + 0.05f;
									}
									if (npc.velocity.X < -num319)
									{
										npc.velocity.X = -num319;
									}
								}
								else if (npc.direction == 1 && npc.velocity.X < num319)
								{
									npc.velocity.X = npc.velocity.X + 0.1f;
									if (npc.velocity.X < -num319)
									{
										npc.velocity.X = npc.velocity.X + 0.1f;
									}
									else if (npc.velocity.X < 0f)
									{
										npc.velocity.X = npc.velocity.X - 0.05f;
									}
									if (npc.velocity.X > num319)
									{
										npc.velocity.X = num319;
									}
								}
									num319 = 1.5f;
								if (npc.directionY == -1 && npc.velocity.Y > -num319)
								{
									npc.velocity.Y = npc.velocity.Y - 0.04f;
									if (npc.velocity.Y > num319)
									{
										npc.velocity.Y = npc.velocity.Y - 0.05f;
									}
									else if (npc.velocity.Y > 0f)
									{
										npc.velocity.Y = npc.velocity.Y + 0.03f;
									}
									if (npc.velocity.Y < -num319)
									{
										npc.velocity.Y = -num319;
									}
								}
								else if (npc.directionY == 1 && npc.velocity.Y < num319)
								{
									npc.velocity.Y = npc.velocity.Y + 0.04f;
									if (npc.velocity.Y < -num319)
									{
										npc.velocity.Y = npc.velocity.Y + 0.05f;
									}
									else if (npc.velocity.Y < 0f)
									{
										npc.velocity.Y = npc.velocity.Y - 0.03f;
									}
									if (npc.velocity.Y > num319)
									{
										npc.velocity.Y = num319;
									}
								}
							}
			}
			if (attackDone == true) {
				//int attackMax = 4;
				//if (Main.expertMode) attackMax = 5;
				attack = Main.rand.Next(1, 6);
				attackDone = false;
				attackTimer = 0;
				//npc.velocity = new Vector2(0, 0);
				movement = true;
				summonNum = 0;
				npc.noTileCollide = true;
				npc.noGravity = true;
				npc.dontTakeDamage = false;
			}
			if (attack == 1 || attack == 2) {
				if (attackTimer == 0) {
					if (phase == 1 && !AzercadmiumWorld.devastation)
						Projectile.NewProjectile(npc.Center, Vector2.Normalize((target.position - new Vector2(0, -10)) - npc.Center) * 12, mod.ProjectileType("DirtGlobuleHostile"), 8, 0f, Main.myPlayer, 0f, 0f);
					if (phase == 2 || AzercadmiumWorld.devastation)
						Projectile.NewProjectile(npc.Center, Vector2.Normalize((target.position - new Vector2(0, -10)) - npc.Center) * 12, mod.ProjectileType("DirtGlobuleLaserHostile"), 10, 0f, Main.myPlayer, 0f, 0f);
				}
				attackTimer++;
				if (attackTimer >= 300 - difficultyBonus)
					attackDone = true;
			}
			if (attack == 3) {
				attackTimer++;
				int minionCount = 1;
				if (Main.expertMode) minionCount += Main.rand.Next(0, 2);
				if (AzercadmiumWorld.devastation) minionCount += Main.rand.Next(0, 2);
				if (phase == 2) minionCount += Main.rand.Next(0, 2);
				if (attackTimer % 10 == 0 && attackTimer <= minionCount * 10) {
					if (Main.expertMode)
						NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-60, 61), (int)npc.Center.Y + Main.rand.Next(-60, 61), mod.NPCType("DirtBlock"));
					summonNum += 1;
					NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-60, 61), (int)npc.Center.Y + Main.rand.Next(-60, 61), mod.NPCType("SecurityDiscus"));
				}	
				if (attackTimer >= (minionCount * 10) + 90 - difficultyBonus)
					attackDone = true;
			}
			if (attack == 4 || attack == 5) {
				attackTimer++;
				movement = true;
				//npc.noTileCollide = false;
				//npc.noGravity = false;
				npc.dontTakeDamage = true;
				if (phase == 1)
					npc.frame.Y = 14 * 164;
				else if (phase == 2)
					npc.frame.Y = 15 * 164;
				if (attackTimer < 80)
					npc.velocity /= 4;
				else if (attackTimer < 90)
					npc.velocity /= 3;
				else if (attackTimer < 100)
					npc.velocity /= 2;
				else if (attackTimer < 110)
					npc.velocity /= 1.5f;
				else
					npc.velocity /= 1.25f;
				if (attackTimer % 5 == 0)
					Projectile.NewProjectile(npc.Center, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-14, -6)), mod.ProjectileType("DirtSphereHostile"), 10, 0f, Main.myPlayer, 0f, 0f);
				if (attackTimer >= 120)
					attackDone = true;
			}
			if ((Vector2.Distance(npc.Center, target.Center) > 700 || dashDone == false) && attack != 4 && Timer > 300) {
				movement = false;
				dashTimer++;
				dashDone = false;
				if (dashTimer == 1) {
					float num320 = 9f;
					Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					num321 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
					num322 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
					float num323 = (float)Math.Sqrt((double)(num321 * num321 + num322 * num322));
					num323 = num320 / num323;
					num321 *= num323;
					num322 *= num323;
					npc.velocity.X = num321 * 1.5f;
					npc.velocity.Y = num322 * 1.5f; //4
				}
				if (dashTimer < 60) {
					npc.velocity.X = num321 * 1.5f; //4
					npc.velocity.Y = num322 * 1.5f; //4
				}
				else
				movement = true;
				if (dashTimer > 150 - difficultyBonus || Vector2.Distance(npc.Center, target.Center) < 100) {
					dashDone = true;
					dashTimer = 0;
				}
					
			}
			if (AzercadmiumWorld.devastation) {
				if (Timer % 1800 == 0)
				{
					for (int pos = -800; pos < 800; pos += 160) {
						Projectile.NewProjectile(npc.Center.X - 1600, npc.Center.Y - pos, 10, 0, mod.ProjectileType("DirtGlobHostile"), 14, 0f, Main.myPlayer, 0f, 0f);
						Projectile.NewProjectile(npc.Center.X + 1600, npc.Center.Y - pos - 80, -10, 0, mod.ProjectileType("DirtGlobHostile"), 14, 0f, Main.myPlayer, 0f, 0f);
					}
				}
				if (Timer % 1800 > 1200 && Timer % 1800 < 1500 && Timer % 10 == 0) {
					Projectile.NewProjectile(target.Center.X + Main.rand.Next(-400, 400), target.Center.Y - 600, Main.rand.NextFloat(-6, 7), Main.rand.Next(4, 7), mod.ProjectileType("DirtGlobHostile"), 14, 0f, Main.myPlayer, 0f, 0f);
				}
			}
		}
		public override void BossLoot(ref string name, ref int potionType) {
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), mod.ItemType("DirtballBag"));
		    else {
				switch (Main.rand.Next(1, 7)) {
					case 1: Item.NewItem(npc.getRect(), mod.ItemType("MuddyGreatsword"));
						break;
					case 2: Item.NewItem(npc.getRect(), mod.ItemType("DirtyBeholder"));
						break;
					case 3: Item.NewItem(npc.getRect(), mod.ItemType("Dirty3String"));
						break;
					case 4: Item.NewItem(npc.getRect(), mod.ItemType("PaydirtPistol"));
						break;
					case 5: Item.NewItem(npc.getRect(), mod.ItemType("DirtyBlowpipe"));
						break;
					case 6: Item.NewItem(npc.getRect(), mod.ItemType("DirtballsScepter"));
						break;
				}
				switch (Main.rand.Next(1, 4)) {
					case 1: Item.NewItem(npc.getRect(), mod.ItemType("EarthmightVisor"));
						break;
					case 2: Item.NewItem(npc.getRect(), mod.ItemType("EarthmightBreastplate"));
						break;
					case 3: Item.NewItem(npc.getRect(), mod.ItemType("EarthmightLeggings"));
						break;
				}
				switch (Main.rand.Next(1, 4)) {
					case 1: Item.NewItem(npc.getRect(), mod.ItemType("OvergrownHilt"));
						break;
					case 2: Item.NewItem(npc.getRect(), mod.ItemType("OvergrownHandgunFragment"));
						break;
					case 3: Item.NewItem(npc.getRect(), mod.ItemType("OvergrownElectricalComponent"));
						break;
				}
				Item.NewItem(npc.getRect(), ItemID.CopperBar, 1 + Main.rand.Next(5));
				Item.NewItem(npc.getRect(), ItemID.DirtBlock, 1 + Main.rand.Next(5));
				Item.NewItem(npc.getRect(), ItemID.MudBlock, 1 + Main.rand.Next(5));
				Item.NewItem(npc.getRect(), ItemID.Gel, 1 + Main.rand.Next(5));
				Item.NewItem(npc.getRect(), ItemID.Lens, 1 + Main.rand.Next(1));
				if (Main.rand.NextFloat() < .5f)
				Item.NewItem(npc.getRect(), mod.ItemType("DirtyMedal"));
				if (Main.rand.NextFloat() < .25f)
				Item.NewItem(npc.getRect(), ItemID.DirtRod);
				if (Main.rand.NextFloat() < .12f)
				Item.NewItem(npc.getRect(), mod.ItemType("CreepyBlob"));
			}
			AzercadmiumWorld.downedDirtball = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			bool canSpawn = false;
			int playerCount;
			for (playerCount = 0; playerCount < 255; playerCount++) {
				if (Main.player[playerCount].statLifeMax2 > 100) {
					canSpawn = true;
				}
			}
			if (!AzercadmiumWorld.downedDirtball && Main.dayTime && canSpawn)
			    return 0.000025f; //0.00005
			return 0f;
        }
	}
}