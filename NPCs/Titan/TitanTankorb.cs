using Azercadmium.Helpers;
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
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults() {
			npc.width = 80;
			npc.height = 80;
			npc.damage = 55;
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
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.ShadowFlame] = true;
			npc.lavaImmune = true;
			//animationType = NPCID.Drippler;
			//npc.takenDamageMultiplier = 0f;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 30000 + (numPlayers * 3000);
            npc.damage = 83;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 45000 + (numPlayers * 4500);
				npc.damage = 124;
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
			if (attack == 5)
				DrawingHelper.NPCAfterImageEffect(npc, null);
            return true;
        }
		int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		Player target;
		int difficultyBonus;
		float num321;
		float num322;
		bool dashDone = true;
		bool summonedTitaniumOre = Main.expertMode;
		int dashTimer = 0;
		float passiveAttackTimer;
		int attackInt;
		public override void AI() {
			AzercadmiumGlobalNPC.titanBoss = npc.whoAmI;
			//npc.takenDamageMultiplier = 1 - shieldValue;
			if (AzercadmiumWorld.devastation) difficultyBonus = 60;
			else if (Main.expertMode) difficultyBonus = 30;
			else difficultyBonus = 0;
			Timer++;
			if (summonedTitaniumOre) {
				int titaniumOreCount = 75;
				if (AzercadmiumWorld.devastation) titaniumOreCount = 90;
				for (int i = 0; i < titaniumOreCount; i++) {
					NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-60, 61), (int)npc.Center.Y + Main.rand.Next(-60, 61), mod.NPCType("FloatingTitaniumOre"));
					summonedTitaniumOre = false;
				}
			}
			npc.TargetClosest(true);
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)(-3.75f + npc.scale);
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
			float hpFlag = 0.8f;
			if (Main.expertMode)
				hpFlag = 0.85f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.9f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 2;

			hpFlag = 0.6f;
			if (Main.expertMode)
				hpFlag = 0.65f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.7f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 3;

			hpFlag = 0.4f;
			if (Main.expertMode)
				hpFlag = 0.45f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.5f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 4;

			hpFlag = 0.2f;
			if (Main.expertMode)
				hpFlag = 0.25f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.3f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 5;

			hpFlag = 0.1f;
			if (Main.expertMode)
				hpFlag = 0.15f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.2f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 6;

			if (Timer % 6 == 0)
				animationTimer++;
			if (animationTimer > 3)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 78;

			if (movement)
			{
				float num291 = 10f; //7f
									Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
									float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
									float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
									float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
									num294 = num291 / num294;
									num292 *= num294;
									num293 *= num294;
									float passiveAttackRate = 30;
									for (int i = 0; i < npc.life; i += npc.lifeMax / 20) {
										passiveAttackRate += 2;
									}
									if (passiveAttackTimer == passiveAttackRate) {
										Main.PlaySound(SoundID.Item12);
										Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 25, 0f, Main.myPlayer, 0f, 0f);
									}
									if (passiveAttackTimer >= 0f)
									{
										passiveAttackTimer += 1f;
										if (passiveAttackTimer >= passiveAttackRate * 2)
										{
											passiveAttackTimer = 0f;
										}
									}
																	if (npc.ai[0] == 0f)
																	{
																		npc.TargetClosest(true);
																		if (Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
																		{
																			npc.ai[0] = 1f;
																		}
																		else
																		{
																			Vector2 value29 = Main.player[npc.target].Center - npc.Center;
																			value29.Y -= (float)(Main.player[npc.target].height / 4);
																			float num1310 = value29.Length();
																			if (num1310 > 800f)
																			{
																				npc.ai[0] = 2f;
																			}
																			else
																			{
																				Vector2 center26 = npc.Center;
																				center26.X = Main.player[npc.target].Center.X;
																				Vector2 vector230 = center26 - npc.Center;
																				if (vector230.Length() > 8f && Collision.CanHit(npc.Center, 1, 1, center26, 1, 1))
																				{
																					npc.ai[0] = 3f;
																					npc.ai[1] = center26.X;
																					npc.ai[2] = center26.Y;
																					Vector2 center27 = npc.Center;
																					center27.Y = Main.player[npc.target].Center.Y;
																					if (vector230.Length() > 8f && Collision.CanHit(npc.Center, 1, 1, center27, 1, 1) && Collision.CanHit(center27, 1, 1, Main.player[npc.target].position, 1, 1))
																					{
																						npc.ai[0] = 3f;
																						npc.ai[1] = center27.X;
																						npc.ai[2] = center27.Y;
																					}
																				}
																				else
																				{
																					center26 = npc.Center;
																					center26.Y = Main.player[npc.target].Center.Y;
																					if ((center26 - npc.Center).Length() > 8f && Collision.CanHit(npc.Center, 1, 1, center26, 1, 1))
																					{
																						npc.ai[0] = 3f;
																						npc.ai[1] = center26.X;
																						npc.ai[2] = center26.Y;
																					}
																				}
																				if (npc.ai[0] == 0f)
																				{
																					npc.localAI[0] = 0f;
																					value29.Normalize();
																					value29 *= 0.5f;
																					npc.velocity += value29;
																					npc.ai[0] = 4f;
																					npc.ai[1] = 0f;
																				}
																			}
																		}
																	}
																	else if (npc.ai[0] == 1f)
																	{
																		//npc.rotation += (float)npc.direction * 0.3f;
																		Vector2 value30 = Main.player[npc.target].Center - npc.Center;
																		if (npc.type == 421)
																		{
																			value30 = Main.player[npc.target].Top - npc.Center;
																		}
																		float num1311 = value30.Length();
																		float num1312 = 5.5f;
																		num1312 += num1311 / 100f;
																		int num1313 = 50;
																		value30.Normalize();
																		value30 *= num1312;
																		npc.velocity = (npc.velocity * (float)(num1313 - 1) + value30) / (float)num1313;
																		if (!Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
																		{
																			npc.ai[0] = 0f;
																			npc.ai[1] = 0f;
																		}
																		if (npc.type == 421 && num1311 < 40f && Main.player[npc.target].active && !Main.player[npc.target].dead)
																		{
																			bool flag94 = true;
																			int num;
																			for (int num1314 = 0; num1314 < 200; num1314 = num + 1)
																			{
																				NPC nPC8 = Main.npc[num1314];
																				if (nPC8.active && nPC8.type == npc.type && nPC8.ai[0] == 5f && nPC8.target == npc.target)
																				{
																					flag94 = false;
																					break;
																				}
																				num = num1314;
																			}
																			if (flag94)
																			{
																				npc.Center = Main.player[npc.target].Top;
																				npc.velocity = Vector2.Zero;
																				npc.ai[0] = 5f;
																				npc.ai[1] = 0f;
																				npc.netUpdate = true;
																			}
																		}
																	}
																	else if (npc.ai[0] == 2f)
																	{
																		npc.rotation = npc.velocity.X * 0.1f;
																		npc.noTileCollide = true;
																		Vector2 value31 = Main.player[npc.target].Center - npc.Center;
																		float num1315 = value31.Length();
																		float scaleFactor11 = 3f;
																		int num1316 = 3;
																		value31.Normalize();
																		value31 *= scaleFactor11;
																		npc.velocity = (npc.velocity * (float)(num1316 - 1) + value31) / (float)num1316;
																		if (num1315 < 600f && !Collision.SolidCollision(npc.position, npc.width, npc.height))
																		{
																			npc.ai[0] = 0f;
																		}
																	}
																	else if (npc.ai[0] == 3f)
																	{
																		npc.rotation = npc.velocity.X * 0.1f;
																		Vector2 value32 = new Vector2(npc.ai[1], npc.ai[2]);
																		Vector2 value33 = value32 - npc.Center;
																		float num1317 = value33.Length();
																		float num1318 = 2f;
																		float num1319 = 3f;
																		value33.Normalize();
																		value33 *= num1318;
																		npc.velocity = (npc.velocity * (num1319 - 1f) + value33) / num1319;
																		if (npc.collideX || npc.collideY)
																		{
																			npc.ai[0] = 4f;
																			npc.ai[1] = 0f;
																		}
																		if (num1317 < num1318 || num1317 > 800f || Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
																		{
																			npc.ai[0] = 0f;
																		}
																	}
																	else if (npc.ai[0] == 4f)
																	{
																		npc.rotation = npc.velocity.X * 0.1f;
																		if (npc.collideX)
																		{
																			npc.velocity.X = npc.velocity.X * -0.8f;
																		}
																		if (npc.collideY)
																		{
																			npc.velocity.Y = npc.velocity.Y * -0.8f;
																		}
																		Vector2 value34;
																		if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
																		{
																			value34 = Main.player[npc.target].Center - npc.Center;
																			value34.Y -= (float)(Main.player[npc.target].height / 4);
																			value34.Normalize();
																			npc.velocity = value34 * 0.1f;
																		}
																		float scaleFactor12 = 2f;
																		float num1320 = 20f;
																		value34 = npc.velocity;
																		value34.Normalize();
																		value34 *= scaleFactor12;
																		npc.velocity = (npc.velocity * (num1320 - 1f) + value34) / num1320;
																		npc.ai[1] += 1f;
																		if (npc.ai[1] > 180f)
																		{
																			npc.ai[0] = 0f;
																			npc.ai[1] = 0f;
																		}
																		if (Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
																		{
																			npc.ai[0] = 0f;
																		}
																		npc.localAI[0] += 1f;
																		if (npc.localAI[0] >= 5f && !Collision.SolidCollision(npc.position - new Vector2(10f, 10f), npc.width + 20, npc.height + 20))
																		{
																			npc.localAI[0] = 0f;
																			Vector2 center28 = npc.Center;
																			center28.X = Main.player[npc.target].Center.X;
																			if (Collision.CanHit(npc.Center, 1, 1, center28, 1, 1) && Collision.CanHit(npc.Center, 1, 1, center28, 1, 1) && Collision.CanHit(Main.player[npc.target].Center, 1, 1, center28, 1, 1))
																			{
																				npc.ai[0] = 3f;
																				npc.ai[1] = center28.X;
																				npc.ai[2] = center28.Y;
																			}
																			else
																			{
																				center28 = npc.Center;
																				center28.Y = Main.player[npc.target].Center.Y;
																				if (Collision.CanHit(npc.Center, 1, 1, center28, 1, 1) && Collision.CanHit(Main.player[npc.target].Center, 1, 1, center28, 1, 1))
																				{
																					npc.ai[0] = 3f;
																					npc.ai[1] = center28.X;
																					npc.ai[2] = center28.Y;
																				}
																			}
																		}
																	}
																	else if (npc.ai[0] == 5f)
																	{
																		Player player7 = Main.player[npc.target];
																		if (!player7.active || player7.dead)
																		{
																			npc.ai[0] = 0f;
																			npc.ai[1] = 0f;
																			npc.netUpdate = true;
																		}
																		else
																		{
																			npc.Center = ((player7.gravDir == 1f) ? player7.Top : player7.Bottom) + new Vector2((float)(player7.direction * 4), 0f);
																			npc.gfxOffY = player7.gfxOffY;
																			npc.velocity = Vector2.Zero;
																			player7.AddBuff(163, 59, true);
																		}
																	}
																	if (npc.type == 405)
																	{
																		npc.rotation = 0f;
																		int num;
																		for (int num1321 = 0; num1321 < 200; num1321 = num + 1)
																		{
																			if (num1321 != npc.whoAmI && Main.npc[num1321].active && Main.npc[num1321].type == npc.type && Math.Abs(npc.position.X - Main.npc[num1321].position.X) + Math.Abs(npc.position.Y - Main.npc[num1321].position.Y) < (float)npc.width)
																			{
																				if (npc.position.X < Main.npc[num1321].position.X)
																				{
																					npc.velocity.X = npc.velocity.X - 0.05f;
																				}
																				else
																				{
																					npc.velocity.X = npc.velocity.X + 0.05f;
																				}
																				if (npc.position.Y < Main.npc[num1321].position.Y)
																				{
																					npc.velocity.Y = npc.velocity.Y - 0.05f;
																				}
																				else
																				{
																					npc.velocity.Y = npc.velocity.Y + 0.05f;
																				}
																			}
																			num = num1321;
																		}
																		return;
																	}
																	if (npc.type == 421)
																	{
																		npc.hide = (npc.ai[0] == 5f);
																		npc.rotation = npc.velocity.X * 0.1f;
																		int num;
																		for (int num1322 = 0; num1322 < 200; num1322 = num + 1)
																		{
																			if (num1322 != npc.whoAmI && Main.npc[num1322].active && Main.npc[num1322].type == npc.type && Math.Abs(npc.position.X - Main.npc[num1322].position.X) + Math.Abs(npc.position.Y - Main.npc[num1322].position.Y) < (float)npc.width)
																			{
																				if (npc.position.X < Main.npc[num1322].position.X)
																				{
																					npc.velocity.X = npc.velocity.X - 0.05f;
																				}
																				else
																				{
																					npc.velocity.X = npc.velocity.X + 0.05f;
																				}
																				if (npc.position.Y < Main.npc[num1322].position.Y)
																				{
																					npc.velocity.Y = npc.velocity.Y - 0.05f;
																				}
																				else
																				{
																					npc.velocity.Y = npc.velocity.Y + 0.05f;
																				}
																			}
																			num = num1322;
																		}
																		return;
																	}
			}
			if (attackDone == true) {
				int attackMax = 4;
				if ((double)(npc.life) < (double)(npc.lifeMax * 0.66f)) attackMax = 5;
				if ((double)(npc.life) < (double)(npc.lifeMax * 0.33f)) attackMax = 6;
				attack = Main.rand.Next(1, attackMax);
				attackDone = false;
				attackTimer = 0;
				//npc.velocity = new Vector2(0, 0);
				movement = true;
				npc.noTileCollide = true;
				npc.noGravity = true;
				npc.dontTakeDamage = false;
				attackInt = 0;
			}
			if (attack == 1) {
				if (attackTimer == 0) {
					Projectile.NewProjectile(new Vector2(npc.Center.X - 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X + 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
				}
				if (attackTimer == 90) {
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y - 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y + 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
				}
				if (attackTimer == 180) {
					Projectile.NewProjectile(new Vector2(npc.Center.X - 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X + 200, npc.Center.Y), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y - 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y + 200), new Vector2(0, 0), mod.ProjectileType("TitaniumSwordHostile"), 19 + phase, 0f, Main.myPlayer, 0f, 0f);
				}
				attackTimer++;
				if (attackTimer >= 300 - difficultyBonus)
					attackDone = true;
			}
			if (attack == 2) {
				if (attackTimer == 0)
					Projectile.NewProjectile(npc.Center, Vector2.Normalize((target.position - new Vector2(0, -10)) - npc.Center) * 12, mod.ProjectileType("TitaniumBarExplode"), 16 + phase, 0f, Main.myPlayer, phase, 0f);
				attackTimer++;
				if (attackTimer >= 120 - difficultyBonus)
					attackDone = true;
			}
			if (attack == 3) {
				float num291 = 10f; //7f
				Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
				float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
				float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
				num294 = num291 / num294;
				num292 *= num294;
				num293 *= num294;
				if (attackTimer == 0) {
					Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 22 + phase, 0f, Main.myPlayer, 0f, 0f);
					Main.PlaySound(SoundID.Item12);
				}
				if (attackTimer == 30) {
					Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 22 + phase, 0f, Main.myPlayer, 0f, 0f);
					Main.PlaySound(SoundID.Item12);
				}
				if (attackTimer == 60) {
					Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 22 + phase, 0f, Main.myPlayer, 0f, 0f);
					Main.PlaySound(SoundID.Item12);
				}
				if (attackTimer == 90 && phase > 2) {
					Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 22 + phase, 0f, Main.myPlayer, 0f, 0f);
					Main.PlaySound(SoundID.Item12);
				}
				if (attackTimer == 120 && phase > 4) {
					Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 22 + phase, 0f, Main.myPlayer, 0f, 0f);
					Main.PlaySound(SoundID.Item12);
				}
				attackTimer++;
				if (attackTimer >= 120 + phase * 10)
					attackDone = true;
			}
			if (attack == 4) {
				npc.velocity = new Vector2(0, 0);
				npc.dontTakeDamage = true;
				if (attackTimer % 5 == 0 && attackTimer < 120 + difficultyBonus)
					Projectile.NewProjectile(npc.Center, new Vector2(0, 10).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("TitaniumShardHostile"), 22 + phase, 0, Main.myPlayer);
				attackTimer++;
				if (attackTimer >= 180)
					attackDone = true;
			}
			if (attack == 5) {
				attackTimer++;
				if (attackInt == 2) {
					movement = false;
					Projectile.NewProjectile(npc.Center, new Vector2(0, -12), mod.ProjectileType("TitanWave"), 32 + phase, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center, new Vector2(0, 12), mod.ProjectileType("TitanWave"), 32 + phase, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center, new Vector2(12, 0), mod.ProjectileType("TitanWave"), 32 + phase, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center, new Vector2(-12, 0), mod.ProjectileType("TitanWave"), 32 + phase, 0, Main.myPlayer);
					for (int i = 0; i < 4; i++) { 
						Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("TitanWave"), 29 + phase, 0, Main.myPlayer);
					}
					for (int i = 0; i < 4; i++) { 
						Projectile.NewProjectile(npc.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("TitanWave"), 26 + phase, 0, Main.myPlayer);
					}
					attackDone = true;
				}
				else if (attackInt == 1) {
					movement = false;
					if (attackTimer <= 20)
						npc.velocity.Y = (attackTimer) / 2;
					else
						npc.velocity.Y = 10;
					if (npc.Center.Y >= target.Center.Y) {
						attackTimer = 0;
						attackInt = 2;
					}
				}
				else {
					if (Math.Abs(attackTimer / 5) < 10)
						npc.velocity.Y = -1 * Math.Abs(attackTimer / 5);
					else
						npc.velocity.Y = -10;
					if (npc.Center.Y + 400 <= target.Center.Y) {
						attackTimer = 0;
						attackInt = 1;
					}
				}
			}
			/*if (attack == 3) {
				attackTimer++;
				int minionCount = 1;
				if (Main.expertMode) minionCount += Main.rand.Next(0, 2);
				if (AzercadmiumWorld.devastation) minionCount += Main.rand.Next(0, 2);
				if (phase == 2) minionCount += Main.rand.Next(0, 2);
				if (attackTimer % 10 == 0 && attackTimer <= minionCount * 10) {
					if (Main.expertMode)
						NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-60, 61), (int)npc.Center.Y + Main.rand.Next(-60, 61), mod.NPCType("DirtBlock"));
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
					Projectile.NewProjectile(npc.Center, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-14, -6)), mod.ProjectileType("DirtSphereHostile"), 12, 0f, Main.myPlayer, 0f, 0f);
				if (attackTimer >= 120)
					attackDone = true;
			}*/
			/*if ((Vector2.Distance(npc.Center, target.Center) > 1000 || dashDone == false) && Timer > 600) {
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
					
			}*/
		}
		public override void BossLoot(ref string name, ref int potionType) {
			potionType = ItemID.GreaterHealingPotion;
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), mod.ItemType("TitanBag"));
		    else {
				Item.NewItem(npc.getRect(), ItemID.AdamantiteBar, Main.rand.Next(8, 17));
				Item.NewItem(npc.getRect(), ItemID.TitaniumBar, Main.rand.Next(8, 17));
				Item.NewItem(npc.getRect(), ItemID.SoulofLight, Main.rand.Next(5, 11));
				Item.NewItem(npc.getRect(), ItemID.SoulofNight, Main.rand.Next(5, 11));
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Titan.TitanicEnergy>(), Main.rand.Next(50, 101));
			}
			AzercadmiumWorld.downedTitan = true;
		}
	}
}