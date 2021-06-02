using Azercadmium.Helpers;
using Azercadmium.Projectiles.Titan;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Titan
{
	[AutoloadBossHead]
	public class TitanClone : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Tankorb Clone");
		}
        public override void SetDefaults() {
			npc.width = 80;
			npc.height = 80;
			npc.damage = 65;
			npc.lifeMax = 1;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			npc.dontTakeDamage = true;
			//npc.boss = true;
			npc.netAlways = true;
			npc.lavaImmune = true;
			music = MusicID.Boss2;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 96;
			if (AzercadmiumWorld.devastation) {
				npc.damage = 144;
			}
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = 27;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 27;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor) {
			if (npc.alpha == 0)
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
		int dashTimer = 0;
		float passiveAttackTimer;
		int attackInt;
		float moveSpeed = 5;
		bool spawnPortals;
		public override void AI() {
			if (AzercadmiumWorld.devastation) difficultyBonus = 60;
			else if (Main.expertMode) difficultyBonus = 30;
			else difficultyBonus = 0;
			Timer++;
			npc.TargetClosest(true);
			target = Main.player[npc.target];
			//if (npc.alpha == 0)
			//	Lighting.AddLight(npc.Center, new Vector3(9, 0, 23)); it stopped working and its just white so...
			bool one = (Timer % 2400 < 600);
			bool two = (Timer % 2400 > 600 && Timer % 2400 < 1200);
			bool three = (Timer % 2400 > 1200 && Timer % 2400 < 1800);
			bool four = (Timer % 2400 > 1800);
			bool five = Main.npc[AzercadmiumGlobalNPC.titanBoss].life < Main.npc[AzercadmiumGlobalNPC.titanBoss].lifeMax * 0.25f;
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

			npc.rotation = npc.velocity.X * 0.05f;

			if (npc.alpha > 0 && Math.Abs(npc.Center.X - target.Center.X) > 960) {
				if (npc.Center.X - target.Center.X > 0)
					npc.position.X -= 10;
				else
					npc.position.X += 10;
			}
			if (npc.alpha > 0 && Math.Abs(npc.Center.Y - target.Center.Y) > 960) {
				if (npc.Center.Y - target.Center.Y > 0)
					npc.position.Y -= 10;
				else
					npc.position.Y += 10;
			}
			if (Main.npc[AzercadmiumGlobalNPC.titanBoss].active == false) {
					for (int i = 0; i < 75; i++) {
					int dustType = 27;
					int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
					npc.active = false;
				}
			}
			if (npc.ai[0] == 0) {
				if ((!one && !five) || (!(one || two) && five)) {
					if (npc.alpha < 150)
					npc.alpha += 3;
					npc.damage = 0;
					npc.velocity *= 0.75f;
					npc.aiStyle = 0;
					return;
				}
				else {
					if (npc.alpha > 0)
					npc.alpha -= 5;
					npc.damage = npc.defDamage;
				}

				npc.aiStyle = 22;
				aiType = NPCID.Reaper;
				float num291 = 10f; //7f
									Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
									float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
									float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
									float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
									num294 = num291 / num294;
									num292 *= num294;
									num293 *= num294;
				if (Timer % 400 == 120)
					Projectile.NewProjectile(vector33.X, vector33.Y, 0, -10, ModContent.ProjectileType<TitanBlast>(), 35, 0f, Main.myPlayer, 0f, 0f);
									if (Timer % 300 == 200 || Timer % 300 == 220 || Timer % 300 == 240 || Timer % 300 == 260 || Timer % 300 == 280) {
										Main.PlaySound(SoundID.Item12);
										Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, ModContent.ProjectileType<TitanBolt>(), 32, 0f, Main.myPlayer, 0f, 0f);
									}
				if (npc.Center.Y < target.Center.Y && Timer % 5 == 0)
					npc.velocity.Y += 1;
				if (npc.Center.Y > target.Center.Y && Timer % 5 == 0)
					npc.velocity.Y -= 1;
				if (npc.velocity.Y < -12)
					npc.velocity.Y = -12;
				if (npc.velocity.Y > 12)
					npc.velocity.Y = 12;
			}
			else if (npc.ai[0] == 1) {
				if ((!two && !five) || (!(two || three) && five)) {
					if (npc.alpha < 150)
					npc.alpha += 3;
					npc.damage = 0;
					npc.velocity *= 0.75f;
					return;
				}
				else {
					if (npc.alpha > 0)
					npc.alpha -= 5;
					npc.damage = npc.defDamage;
				}

				if (AzercadmiumWorld.devastation) npc.damage = 196;
				else if (Main.expertMode) npc.damage = 124;
				else npc.damage = 96;
				if (npc.Center.X < target.Center.X && Timer % 4 == 0)
					npc.velocity.X += 1;
				if (npc.Center.X > target.Center.X && Timer % 4 == 0)
					npc.velocity.X -= 1;
				if (npc.velocity.X < -20)
					npc.velocity.X = -20;
				if (npc.velocity.X > 20)
					npc.velocity.X = 20;

				if (npc.Center.Y < target.Center.Y && Timer % 4 == 0)
					npc.velocity.Y += 1;
				if (npc.Center.Y > target.Center.Y && Timer % 4 == 0)
					npc.velocity.Y -= 1;
				if (npc.velocity.Y < -20)
					npc.velocity.Y = -20;
				if (npc.velocity.Y > 20)
					npc.velocity.Y = 20;
			}
			else if (npc.ai[0] == 2) {
				if ((!three && !five) || (!(three || four) && five)) {
					if (npc.alpha < 150)
					npc.alpha += 3;
					npc.damage = 0;
					npc.velocity *= 0.75f;
					return;
				}
				else {
					if (npc.alpha > 0)
					npc.alpha -= 5;
					npc.damage = npc.defDamage;
				}

				if (Timer % 60 == 0)
					Projectile.NewProjectile(npc.Center, new Vector2(0, 0), ModContent.ProjectileType<TitanMine>(), 40, 0f, Main.myPlayer);
				if (npc.Center.X < target.Center.X && Timer % 5 == 0)
					npc.velocity.X += 1;
				if (npc.Center.X > target.Center.X && Timer % 5 == 0)
					npc.velocity.X -= 1;
				if (npc.velocity.X < -10)
					npc.velocity.X = -10;
				if (npc.velocity.X > 10)
					npc.velocity.X = 10;

				if (npc.Center.Y < target.Center.Y && Timer % 6 == 0)
					npc.velocity.Y += 1;
				if (npc.Center.Y > target.Center.Y && Timer % 6 == 0)
					npc.velocity.Y -= 1;
				if (npc.velocity.Y < -7)
					npc.velocity.Y = -7;
				if (npc.velocity.Y > 7)
					npc.velocity.Y = 7;
			}
			else if (npc.ai[0] == 3) {
				if ((!four && !five) || (!(four || one) && five)) {
					if (npc.alpha < 150)
					npc.alpha += 3;
					npc.damage = 0;
					npc.velocity *= 0.75f;
					return;
				}
				else {
					if (npc.alpha > 0)
					npc.alpha -= 5;
					npc.damage = npc.defDamage;
				}

				npc.TargetClosest(true);
												Vector2 vector102 = new Vector2(npc.Center.X, npc.Center.Y);
												float num818 = Main.player[npc.target].Center.X - vector102.X;
												float num819 = Main.player[npc.target].Center.Y - vector102.Y;
												float num820 = (float)Math.Sqrt((double)(num818 * num818 + num819 * num819));
												float num821 = 12f;
												num820 = num821 / num820;
												num818 *= num820;
												num819 *= num820;
												npc.velocity.X = (npc.velocity.X * 100f + num818) / 101f;
												npc.velocity.Y = (npc.velocity.Y * 100f + num819) / 101f;
			}
		}
	}
}