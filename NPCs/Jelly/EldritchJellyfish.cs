using Azercadmium.Items.Jelly;
using Azercadmium.Projectiles.Jelly;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Jelly
{
	[AutoloadBossHead]
	public class EldritchJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eldritch Jellyfish");
			Main.npcFrameCount[npc.type] = 7;
		}
        public override void SetDefaults() {
			npc.width = 200;
			npc.height = 220;
			npc.damage = 40;
			npc.lifeMax = 7000;
			npc.defense = 20;
			npc.HitSound = SoundID.NPCHit25;
			npc.DeathSound = SoundID.NPCDeath28;
			npc.value = Item.buyPrice(0, 4, 0, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss5;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.lavaImmune = true;
			Mod azercadmiumMusic = ModLoader.GetMod("AzercadmiumMusic");
			if (azercadmiumMusic != null) 
				music = azercadmiumMusic.GetSoundSlot(SoundType.Music, "Sounds/Music/JellyTheme");
			else 
				music = MusicID.Boss3;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 10000 + (numPlayers * 1000);
            npc.damage = 80;
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 4; i++) {
				int dustType = ModContent.DustType<Dusts.Jelly.JellyDust>();
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				dust.noGravity = false;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor) {
			//if (movement && movementTimer > 14)
			//DrawingHelper.NPCAfterImageEffect(npc, null);
            return true;
        }
		Player target;
		int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		int dashCount;
		int dashType;
		int attackBoost;
		int rand;
		int attackMode;
		int movementTimer;
		int guessAttack;
		int prevAttack;
		int attackRand;
		int attackMax;
		float attackFloat;
		Vector2 look;
		public override void AI() {
			Timer++;
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
			if (Timer % 5 == 0)
				animationTimer++;
			if (animationTimer > 6)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 272;

			attackBoost = 0;
			if (npc.life < npc.lifeMax * 0.75f) attackBoost = 1;
			if (npc.life < npc.lifeMax * 0.5f) attackBoost = 2;
			if (npc.life < npc.lifeMax * 0.33f) attackBoost = 3;
			if (npc.life < npc.lifeMax * 0.2f) attackBoost = 4;
			if (npc.life < npc.lifeMax * 0.08f) attackBoost = 5;
			npc.damage = npc.defDamage + (attackBoost * 4);
			npc.dontTakeDamage = target.ZoneBeach ? false : true;
			if (movement) {
				movementTimer++;
				npc.localAI[2] = 1f;
							npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
							float num263 = 3f;
							if (dashType == 0) num263 = 3f;
							if (dashType == 1) num263 = 1f;
							if (dashType == 2) num263 = 5f;
							num263 += attackBoost / 2;
							if (dashType == 0) npc.velocity *= 0.99f;
							if (dashType == 1) npc.velocity *= 0.94f;
							if (dashType == 2) npc.velocity *= 0.993f;
							if (npc.velocity.X > -num263 && npc.velocity.X < num263 && npc.velocity.Y > -num263 && npc.velocity.Y < num263)
							{
								if (dashCount == 0)
									dashType = Main.rand.Next(3);
								dashCount++;
								npc.TargetClosest(true);
								float num264 = 12f;
								if (dashType == 0) num264 = 12f;
								if (dashType == 1) num264 = 20f;
								if (dashType == 2) num264 = 16f;
								num264 += attackBoost / 2;
								Vector2 vector31 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
								float num265 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector31.X;
								float num266 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector31.Y;
								float num267 = (float)Math.Sqrt((double)(num265 * num265 + num266 * num266));
								num267 = num264 / num267;
								num265 *= num267;
								num266 *= num267;
								npc.velocity.X = num265;
								npc.velocity.Y = num266;
							}
							if (Main.rand.NextBool())
				{
					int dustType = ModContent.DustType<Dusts.WaterDust>();
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = npc.velocity.X * -0.5f;
				dust.velocity.Y = npc.velocity.Y * -0.5f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
							if (Timer % 120 == 0 && Main.expertMode)
					NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-40, 41), (int)npc.Center.Y + Main.rand.Next(-40, 41), ModContent.NPCType<DetonatingBubble>());
			}
			if (dashCount > 5) {
				dashCount = 0;
				movement = false;
				attack = 0;
				attackTimer = 0;
				attackDone = false;
				attackMode = 0;
				movementTimer = 0;
			}
			if (attack == 0 && attackDone == false) {
				if (attackMode == 0) {
					npc.velocity /= 2;
					npc.alpha += 5;
					if (npc.alpha > 200)
						npc.friendly = true;
					if (npc.alpha > 254)
						attackMode = 1;
				}
				else if (attackMode == 1) {
					npc.velocity = new Vector2();
					Vector2 newPos;
					rand = Main.rand.Next(2);
					if (rand == 0) rand = -1;
					newPos.X = rand*Main.rand.Next(250, 501);
					rand = Main.rand.Next(2);
					if (rand == 0) rand = -1;
					newPos.Y = rand*Main.rand.Next(250, 501);
					npc.position = target.Center + newPos;
					attackMode = 2;
					attackMax = 7;
					//if (npc.life < npc.lifeMax*0.75f)
					//	attackMax = 6;
					while (guessAttack == prevAttack) {
						guessAttack = Main.rand.Next(1, attackMax);
						//guessAttack = 6;
					}
				}
				else if (attackMode == 2) {
					npc.alpha -= 5;
					if (npc.alpha < 201)
						npc.friendly = false;
					else
						npc.position.Y -= 1;
					if (npc.alpha < 1)
						attackMode = 3;
					if (guessAttack == 1 || guessAttack == 3 || guessAttack == 4)
						LookToPlayer();
					else if (guessAttack == 2 || guessAttack == 5 || guessAttack == 6)
						npc.rotation = 0f;
					if (guessAttack == 4)
						npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * 1.5f;
				}
				else if (attackMode == 3) {
					attack = guessAttack;
					attackRand = Main.rand.Next(100);
					attackFloat = 0f;
				}
			}
			if (attack == 1 && attackDone == false) {
				attackTimer++;
				if (attackTimer < 180)
				LookToPlayer();
				else {
					if (attackTimer % 5 == 0) {
						Main.PlaySound(SoundID.NPCHit13, npc.Center);
						Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + Main.rand.NextFloat(-0.4f - (attackBoost*0.02f), 0.4f + (attackBoost*0.02f))), ModContent.ProjectileType<JellyLaser>(), 20 + attackBoost, 0f, Main.myPlayer);
					}
				}
				if (attackTimer > 299) {
					attackDone = true;
					movement = true;
					prevAttack = 1;
				}
			}
			if (attack == 2 && attackDone == false) {
				attackTimer++;
				if (attackTimer % 10 - attackBoost == 0 && attackTimer < 300)
					Projectile.NewProjectile(target.Center + new Vector2(Main.rand.Next(-600, 601), -600), new Vector2(0, 0), ModContent.ProjectileType<JellyBit>(), 20 + attackBoost, 0f, Main.myPlayer);
				if (attackTimer > 499) {
					attackDone = true;
					movement = true;
					prevAttack = 2;
				}
			}
			if (attack == 3 && attackDone == false) {
				attackTimer++;
				LookToPlayer();
				if (attackTimer % 90 - (attackBoost*6) == 59) {
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<ExplosiveEerieJellyfish>(), 0, attackBoost);
				}
				if (attackTimer > 499) {
					attackDone = true;
					movement = true;
					prevAttack = 3;
				}
			}
			if (attack == 4 && attackDone == false) {
				attackTimer++;
				int startType;
				if (attackRand < 50) startType = 1;
				else startType = -1;
				if (attackTimer % 180 < 90) //(attackRand < 50)
					npc.rotation += MathHelper.ToRadians(4*startType);
				else
					npc.rotation -= MathHelper.ToRadians(4*startType);
				if (attackTimer < 350)
					npc.velocity = (20f + (attackBoost*2)) * new Vector2((float)Math.Cos(npc.rotation), (float)Math.Sin(npc.rotation)).RotatedBy(MathHelper.ToRadians(270));
				else
					npc.velocity /= 2;
				if (attackTimer >= 360) {
					attackDone = true;
					movement = true;
					prevAttack = 4;
				}
				int dustType = ModContent.DustType<Dusts.WaterDust>();
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = npc.velocity.X * -0.5f;
				dust.velocity.Y = npc.velocity.Y * -0.5f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				if (attackTimer % 10 - attackBoost == 0) {
					Projectile.NewProjectile(npc.Center, npc.velocity * -0.2f, ModContent.ProjectileType<JellyLaser>(), 20 + attackBoost, 0f, Main.myPlayer);
				}
			}
			if (attack == 5 && attackDone == false) {
				attackTimer++;
				if (attackTimer < 90) attackFloat += 0.01f + (attackBoost*0.0012f);
				else if (attackTimer < 180) attackFloat -= 0.01f + (attackBoost*0.0012f);
				npc.rotation += attackFloat; //if (attackTimer < 180) 
				if (((attackTimer % 3 == 0 && npc.life > npc.lifeMax / 2) || (attackTimer % 2 == 0 && npc.life <= npc.lifeMax / 2)) && attackTimer <= 180)
					Projectile.NewProjectile(npc.Center, new Vector2(0, 0.3f).RotatedBy(npc.rotation), ModContent.ProjectileType<JellyLaserFast>(), 20 + attackBoost, 0f, Main.myPlayer);
				if (attackTimer >= 360) {
					attackDone = true;
					movement = true;
					prevAttack = 5;
				}
			}
			if (attack == 6 && attackDone == false) {
				attackTimer++;
				if (attackTimer == 1) {
					NPC.NewNPC((int)target.Center.X, (int)target.Center.Y - 360, ModContent.NPCType<BeamEerieJellyfish>(), 0, attackBoost, 0f);
				}
				if (attackTimer == 91) {
					NPC.NewNPC((int)target.Center.X - 540, (int)target.Center.Y, ModContent.NPCType<BeamEerieJellyfish>(), 0, attackBoost, 1f);
				}
				if (attackTimer > 640) {
					attackDone = true;
					movement = true;
					prevAttack = 6;
				}
					
			}
		}
		private void LookToPlayer() {
			Vector2 look = Main.player[npc.target].Center - npc.Center;
			LookInDirection(look);
		}

		private void LookInDirection(Vector2 look) {
			float angle = 0.5f * (float)Math.PI;
			if (look.X != 0f) {
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f) {
				angle += (float)Math.PI;
			}
			if (look.X < 0f) {
				angle += (float)Math.PI;
			}
			npc.rotation = angle + MathHelper.ToRadians(270);
		}
		public override void BossLoot(ref string name, ref int potionType) {
			AzercadmiumWorld.downedJelly = true;
			potionType = ItemID.HealingPotion;
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), ModContent.ItemType<JellyBag>());
			else {
				Item.NewItem(npc.getRect(), ModContent.ItemType<EerieBell>(), Main.rand.Next(30, 46));
				Item.NewItem(npc.getRect(), ModContent.ItemType<OtherworldlyFang>(), Main.rand.Next(35, 51));
			}
		}
	}
}