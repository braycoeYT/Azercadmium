using Azercadmium.Items.Titan;
using Azercadmium.Projectiles.Titan;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Titan
{
	[AutoloadBossHead]
	public class TitanTankorb : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Tankorb");
			Main.npcFrameCount[npc.type] = 8;
		}
        public override void SetDefaults() {
			npc.width = 80;
			npc.height = 80;
			npc.damage = 94;
			npc.lifeMax = 20000;
			npc.defense = 20;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss2;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 30000 + (numPlayers * 3000);
            npc.damage = 135;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 45000 + (numPlayers * 4500);
				npc.damage = 174;
			}
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor) {
			//if (Timer % 300 >= 240)
			//	DrawingHelper.NPCAfterImageEffect(npc, null);
            return true;
        }
		int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		int attackRand;
		Player target;
		int difficultyBonus;
		float num321;
		float num322;
		bool dashDone = true;
		int dashTimer = 0;
		float passiveAttackTimer;
		int attackInt;
		float moveSpeed = 5;
		int rotation;
		int oldAttack;
		bool spawnPortals = !Main.expertMode;
		bool canAttack = true;
		public override void AI() {
			AzercadmiumGlobalNPC.titanBoss = npc.whoAmI;
			if (AzercadmiumWorld.devastation) difficultyBonus = 60;
			else if (Main.expertMode) difficultyBonus = 30;
			else difficultyBonus = 0;
			Timer++;
			npc.TargetClosest(true);
			if (movement)
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * -moveSpeed;
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
			if (Timer % 6 == 0)
				animationTimer++;
			if (animationTimer > 3)
				animationTimer = 0;
			if (!spawnPortals && npc.life < npc.lifeMax * 0.5f) npc.frame.Y = animationTimer * 124 + 496;
			else npc.frame.Y = animationTimer * 124;

			npc.rotation = npc.velocity.X * 0.05f;

			if (!spawnPortals && npc.life < npc.lifeMax * 0.5f) {
				if (canAttack == true)
					attackTimer = 0;
				movement = false;
				attackDone = true;
				canAttack = false;
				npc.velocity /= 2;
				npc.dontTakeDamage = true;
				if (attackTimer == 0) {
					npc.defense = 40;
					CombatText.NewText(npc.getRect(), Color.LightGray, "Activating clones...");
				}
				attackTimer++;
				Lighting.AddLight(npc.Center, new Vector3(87, 0, 236));
				if (attackTimer == 120)
				for (int i = 0; i < 4; i++) {
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 40, ModContent.NPCType<TitanClone>(), 0, i);
				}
				if (attackTimer == 150) {
					movement = true;
					canAttack = true;
					attackDone = true;
					spawnPortals = true;
					npc.dontTakeDamage = false;
				}
			}

			if (attackDone && canAttack) {
				attackTimer = 0;
				attackDone = false;
				int attackMax = 5;
				if (npc.life < npc.lifeMax * 0.75f) attackMax = 6;
				if (npc.life < npc.lifeMax * 0.5f) attackMax = 8;
				if (npc.life < npc.lifeMax * 0.25f) attackMax = 9;
				while (attack == oldAttack)
					attack = Main.rand.Next(0, attackMax);
				if (attack == 5) attackRand = Main.rand.Next(2, 7);
				rotation = 0;
				oldAttack = attack;
			}
			if (attack == 0 && canAttack) {
				attackTimer++;
				if (attackTimer < 15) {
					npc.velocity /= 2;
					//movement = false;
				}
				//else if (attack > 29) movement = true;
				if (attackTimer == 15)
				if (npc.life < npc.lifeMax * 0.5f) for (int i = 0; i < 12; i++) {
					Projectile.NewProjectile(npc.Center, new Vector2(0, 6).RotatedBy(Math.PI*0.1666666*i), ModContent.ProjectileType<TitanBlast>(), 23, 0f, Main.myPlayer);
				}
				else for (int i = 0; i < 8; i++) {
					Projectile.NewProjectile(npc.Center, new Vector2(0, 6).RotatedBy(Math.PI*0.25*i), ModContent.ProjectileType<TitanBlast>(), 23, 0f, Main.myPlayer);
				}
				if (attackTimer == 150) //90
					attackDone = true;
			}
			if (attack == 1 && canAttack) {
				if (attackTimer == 0) {
					Projectile.NewProjectile(new Vector2(npc.Center.X - 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X + 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
				}
				if (attackTimer == 90) {
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y - 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y + 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
				}
				if (attackTimer == 180) {
					Projectile.NewProjectile(new Vector2(npc.Center.X - 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X + 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y - 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y + 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 37, 0f, Main.myPlayer, 0f, 0f);
				}
				attackTimer++;
				if (attackTimer >= 300) //240
					attackDone = true;
			}
			if (attack == 2 && canAttack) {
				movement = false;
				attackTimer++;
				if (attackTimer % 100 == 1) {
					float num320 = 9f;
					Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					num321 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
					num322 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
					float num323 = (float)Math.Sqrt((double)(num321 * num321 + num322 * num322));
					num323 = num320 / num323;
					num321 *= num323;
					num322 *= num323;
					npc.velocity.X = num321 * 1.75f;
					npc.velocity.Y = num322 * 1.75f; //4
				}
				if (attackTimer % 100 < 60) {
					npc.velocity.X = num321 * 1.75f; //4
					npc.velocity.Y = num322 * 1.75f; //4
				}
				else
				movement = true;
				if (attackTimer % 20 == 0)
					Projectile.NewProjectile(npc.Center, new Vector2(0, 0), ModContent.ProjectileType<TitanMine>(), 25, 0f, Main.myPlayer);
				if ((attackTimer >= 100 && npc.life > npc.lifeMax * 0.5f) || attackTimer >= 300) {
					movement = true;
					attackDone = true;
				}
			}
			if (attack == 3 && canAttack) {
				attackTimer++;
				if (attackTimer == 1 && !(NPC.CountNPCS(ModContent.NPCType<TitanTracker>()) > 15))
				for (int i = 0; i < 3; i++) {
					NPC.NewNPC((int)npc.Center.X + (i-1)*40, (int)npc.Center.Y + (i-1)*40, ModContent.NPCType<TitanTracker>());
				}
				if (attackTimer >= 120 || NPC.CountNPCS(ModContent.NPCType<TitanTracker>()) > 15) //60
					attackDone = true;
			}
			if (attack == 4 && canAttack) {
				attackTimer++;
				float num291 = 10f; //7f
				Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
				float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
				float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
				num294 = num291 / num294;
				num292 *= num294;
				num293 *= num294;
				Vector2 velocity = new Vector2(num292, num293);
				if (attackTimer == 1) {
					Main.PlaySound(SoundID.Item12);
					if (npc.life < npc.lifeMax * 0.5f) for (int i = -30; i <= 30; i += 5) {
						Vector2 velocity2 = velocity.RotatedBy(i*2/Math.PI);
						Projectile.NewProjectile(vector33.X, vector33.Y, velocity2.X, velocity2.Y, ModContent.ProjectileType<TitanEnergyBeam>(), 29, 0f, Main.myPlayer);
					}
					else for (int i = -20; i <= 20; i += 5) {
						Vector2 velocity2 = velocity.RotatedBy(i*2/Math.PI);
						Projectile.NewProjectile(vector33.X, vector33.Y, velocity2.X, velocity2.Y, ModContent.ProjectileType<TitanEnergyBeam>(), 29, 0f, Main.myPlayer);
					}
				}
				if (attackTimer > 120)
					attackDone = true;
			}
			if (attack == 5 && canAttack) {
				attackTimer++;
				int num = 5;
				if (npc.life < npc.lifeMax * 0.75f) num = 6;
				if (npc.life < npc.lifeMax * 0.5f) num = 8;
				if (npc.life < npc.lifeMax * 0.25f) num = 10;
				if (npc.life < npc.lifeMax * 0.125f) num = 12;
				if (Main.expertMode) num += 2;
				if (AzercadmiumWorld.devastation) num += 2;
				if (attackTimer % 60 == 1) for (int i = 0; i < num; i++) {
					Projectile.NewProjectile(npc.Center, new Vector2(0, 2).RotatedBy(Math.PI*Main.rand.NextFloat(0, 3)*i), ModContent.ProjectileType<TitanShard>(), 23, 0f, Main.myPlayer);
				}
				if (attackTimer == attackRand*60) attackDone = true;
			}
			if (attack == 6 && canAttack) {
				attackTimer++;
				float num291 = 10f; //7f
				Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
				float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
				float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
				num294 = num291 / num294;
				num292 *= num294;
				num293 *= num294;
				Vector2 velocity = new Vector2(num292, num293);
				int maxShots = 8;
				if (npc.life < npc.lifeMax * 0.5f) maxShots = 10;
				if (npc.life < npc.lifeMax * 0.25f) maxShots = 12;
				if (npc.life < npc.lifeMax * 0.125f) maxShots = 14;
				if (attackTimer == 1)
				if (npc.life < npc.lifeMax * 0.5f) for (int i = 0; i <= maxShots; i += 1) {
					Vector2 velocity2 = velocity.RotatedBy(Main.rand.Next(-30, 31)*Math.PI/180);
					Projectile.NewProjectile(vector33.X, vector33.Y, velocity2.X * 0.6f, velocity2.Y * 0.6f, ModContent.ProjectileType<TitanBlast>(), 29, 0f, Main.myPlayer);
				}
				if (attackTimer > 120)
					attackDone = true;
			}
			if (attack == 7 && canAttack) {
				attackTimer++;
				if (attackTimer < 15) {
					npc.velocity /= 2;
					movement = false;
				}
				if (attackTimer == 60) {
					Projectile.NewProjectile(new Vector2(npc.Center.X + 12, npc.Center.Y - 20), new Vector2(0, 3).RotatedBy(rotation*Math.PI/180), ModContent.ProjectileType<TitanShard>(), 36, 0f, Main.myPlayer);
					rotation += 20;
					attackTimer = 56;
					if (rotation == 380) {
						rotation = 10;
						attackTimer = 0;
					}
					if (rotation >= 380) {
						attackTimer = 61;
					}
				}
				if (attackTimer == 120) {
					attackDone = true;
					movement = true;
				}
			}
			if (attack == 8 && canAttack) {
				attackTimer++;
				if (attackTimer < 45) {
					npc.velocity /= 2;
					movement = false;
				}
				float num291 = 2f; //7f
				Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
				float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
				float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
				num294 = num291 / num294;
				num292 *= num294;
				num293 *= num294;
				Vector2 velocity = new Vector2(num292, num293);
				if (attackTimer % 5 == 0 && attackTimer <= 280)
					Projectile.NewProjectile(vector33.X, vector33.Y, velocity.X, velocity.Y, ModContent.ProjectileType<TitanShard>(), 32, 0f, Main.myPlayer);
				if (attackTimer == 300) {
					attackDone = true;
					movement = true;
				}
			}
		}
		public override void BossLoot(ref string name, ref int potionType) {
			potionType = ItemID.GreaterHealingPotion;
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), ModContent.ItemType<TitanBag>());
		    else {
				Item.NewItem(npc.getRect(), ItemID.AdamantiteBar, Main.rand.Next(8, 17));
				Item.NewItem(npc.getRect(), ItemID.TitaniumBar, Main.rand.Next(8, 17));
				Item.NewItem(npc.getRect(), ItemID.SoulofLight, Main.rand.Next(5, 11));
				Item.NewItem(npc.getRect(), ItemID.SoulofNight, Main.rand.Next(5, 11));
				Item.NewItem(npc.getRect(), ModContent.ItemType<TitanicEnergy>(), Main.rand.Next(50, 101));
				int rand = Main.rand.Next(3);
				switch (rand) {
					case 0: Item.NewItem(npc.getRect(), ModContent.ItemType<TitansExecutioner>());
						break;
					case 1: Item.NewItem(npc.getRect(), ModContent.ItemType<TitansGatlibow>());
						break;
					case 2: Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Titan.TitansEnergizer>());
						break;
				}
			}
			AzercadmiumWorld.downedTitan = true;
		}
	}
}