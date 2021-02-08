using Microsoft.Xna.Framework;
using System;
using System.Data.SqlTypes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Empress
{
	//[AutoloadBossHead]
	public class AngeryCrown : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Crown");
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 94;
			npc.height = 70;
			npc.damage = 60;
			npc.defense = 12;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.netAlways = true;
			npc.boss = true;
			npc.dontTakeDamageFromHostiles = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 120;
			if (AzercadmiumWorld.devastation) {
				npc.damage = 180;
			}
        }
		int Timer;
		int attack;
		int attackTimer;
		int attackBonus;
		bool attackDone;
		public override void AI() {
			npc.TargetClosest(true);
			Timer++;
			if (NPC.CountNPCS(ModContent.NPCType<EmpressSlime>()) < 1) {
				npc.boss = false;
				npc.active = false;
			}
						if (npc.ai[0] == 0f && Main.netMode != 1)
						{
							npc.TargetClosest(true);
							npc.ai[0] = 1f;
						}
						if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 2000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
						{
							npc.TargetClosest(true);
							if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 2000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
							{
								npc.ai[1] = 3f;
							}
						}
						int num156 = 0;
						if (npc.ai[1] == 0f)
						{
							npc.damage = npc.defDamage;
							npc.ai[2] += 1f;
							if (npc.ai[2] >= 800f)
							{
								npc.ai[2] = 0f;
								//npc.ai[1] = 1f;
								npc.TargetClosest(true);
								npc.netUpdate = true;
							}
							npc.rotation = npc.velocity.X / 15f;
							float num169 = 0.02f;
							float num170 = 2f;
							float num171 = 0.05f;
							float num172 = 8f;
							if (Main.expertMode)
							{
								num169 = 0.03f;
								num170 = 4f;
								num171 = 0.07f;
								num172 = 9.5f;
							}
							if (npc.position.Y > Main.player[npc.target].position.Y - 250f)
							{
								if (npc.velocity.Y > 0f)
								{
									npc.velocity.Y = npc.velocity.Y * 0.98f;
								}
								npc.velocity.Y = npc.velocity.Y - num169;
								if (npc.velocity.Y > num170)
								{
									npc.velocity.Y = num170;
								}
							}
							else if (npc.position.Y < Main.player[npc.target].position.Y - 250f)
							{
								if (npc.velocity.Y < 0f)
								{
									npc.velocity.Y = npc.velocity.Y * 0.98f;
								}
								npc.velocity.Y = npc.velocity.Y + num169;
								if (npc.velocity.Y < -num170)
								{
									npc.velocity.Y = -num170;
								}
							}
							if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
							{
								if (npc.velocity.X > 0f)
								{
									npc.velocity.X = npc.velocity.X * 0.98f;
								}
								npc.velocity.X = npc.velocity.X - num171;
								if (npc.velocity.X > num172)
								{
									npc.velocity.X = num172;
								}
							}
							if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
							{
								if (npc.velocity.X < 0f)
								{
									npc.velocity.X = npc.velocity.X * 0.98f;
								}
								npc.velocity.X = npc.velocity.X + num171;
								if (npc.velocity.X < -num172)
								{
									npc.velocity.X = -num172;
								}
							}
						}
						/*else if (npc.ai[1] == 1f)
						{
							npc.defense -= 10;
							npc.ai[2] += 1f;
							if (npc.ai[2] == 2f)
							{
								Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
							}
							if (npc.ai[2] >= 400f)
							{
								npc.ai[2] = 0f;
								npc.ai[1] = 0f;
							}
							npc.rotation += (float)npc.direction * 0.3f;
							Vector2 vector20 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
							float num173 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector20.X;
							float num174 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector20.Y;
							float num175 = (float)Math.Sqrt((double)(num173 * num173 + num174 * num174));
							float num176 = 1.5f;
							if (Main.expertMode)
							{
								npc.damage = (int)((double)npc.defDamage * 1.3);
								num176 = 4f;
								if (num175 > 150f)
								{
									num176 *= 1.05f;
								}
								if (num175 > 200f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 250f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 300f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 350f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 400f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 450f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 500f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 550f)
								{
									num176 *= 1.1f;
								}
								if (num175 > 600f)
								{
									num176 *= 1.1f;
								}
								if (num156 == 0)
								{
									num176 *= 1.2f;
								}
								else if (num156 == 1)
								{
									num176 *= 1.1f;
								}
							}
							num175 = num176 / num175;
							npc.velocity.X = num173 * num175;
							npc.velocity.Y = num174 * num175;
						}*/
						else if (npc.ai[1] == 3f)
						{
							npc.velocity.Y = npc.velocity.Y + 0.1f;
							if (npc.velocity.Y < 0f)
							{
								npc.velocity.Y = npc.velocity.Y * 0.95f;
							}
							npc.velocity.X = npc.velocity.X * 0.95f;
						}
			/*if (npc.position.Y > Main.player[npc.target].position.Y + 1200)
				npc.velocity.Y -= 1;
			if (npc.position.Y < Main.player[npc.target].position.Y - 1200)
				npc.velocity.Y += 1;
			if (npc.position.X > Main.player[npc.target].position.X + 1200)
				npc.velocity.X -= 1;
			if (npc.position.X < Main.player[npc.target].position.X - 1200)
				npc.velocity.X += 1;
			if (npc.velocity.X > 20)
				npc.velocity.X = 20;
			if (npc.velocity.X < -20)
				npc.velocity.X = -20;
			if (npc.velocity.Y > 20)
				npc.velocity.Y = 20;
			if (npc.velocity.Y < -20)
				npc.velocity.Y = -20;*/
			npc.rotation = 0f;
			attackBonus = 0;
			if (Main.expertMode) attackBonus = 30;
			if (AzercadmiumWorld.devastation) attackBonus = 60;
			if (attackDone) {
				attack = Main.rand.Next(2);
				attackDone = false;
				attackTimer = 0;
				if (attack == 0 && Timer < 600)
					attack = Main.rand.Next(1) + 1;
			}
			switch (attack) {
				case 0:
					attackTimer++;
					if (attackTimer >= 180)
					{
						npc.velocity = Vector2.Zero;
						npc.rotation = 0f;
						if (attackTimer % 5 == 0) {
							Projectile.NewProjectile(npc.Center + new Vector2(-14, 0), new Vector2(0, -4), ModContent.ProjectileType<Projectiles.Empress.CrownBeam>(), 50, 0f, Main.myPlayer);
							Projectile.NewProjectile(npc.Center + new Vector2(-14, 0), new Vector2(0, 4), ModContent.ProjectileType<Projectiles.Empress.CrownBeam>(), 50, 0f, Main.myPlayer);
						}
						if (attackTimer >= 480) 
							attackDone = true;
					}
					break;
				case 1:
					attackTimer++;
					if (attackTimer >= 180)
					{
						if (attackTimer % 30 == 0)
							NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<CrownSlime>());
						if (attackTimer >= 300)
							attackDone = true;
					}
					break;
			}
		}
	}
}