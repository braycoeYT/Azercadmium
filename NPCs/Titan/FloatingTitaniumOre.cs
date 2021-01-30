using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Titan
{
	public class FloatingTitaniumOre : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Floating Titanium Ore");
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 16;
			npc.height = 16;
			npc.damage = 50;
			npc.defense = 2048;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontCountMe = true;
			npc.rotation = (float)((Math.PI / 180) * Main.rand.NextFloat(90));
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.ShadowFlame] = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 75;
			if (AzercadmiumWorld.devastation) {
				npc.damage = 113;
			}
        }
		int Timer = Main.rand.Next(0, 1200);
		public override void AI() {
			Timer++;
			if (AzercadmiumWorld.devastation && Timer % 1200 == 0) {
				float num291 = 10f; //7f
				Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
									float num292 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
									float num293 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
									float num294 = (float)Math.Sqrt((double)(num292 * num292 + num293 * num293));
									num294 = num291 / num294;
									num292 *= num294;
									num293 *= num294;
				Main.PlaySound(SoundID.Item12);
										Projectile.NewProjectile(vector33.X, vector33.Y, num292 * 2, num293 * 2, mod.ProjectileType("TitanBolt"), 25, 0f, Main.myPlayer, 0f, 0f);
			}
			npc.rotation += (float)(Math.PI / 180 * 3);
			if (AzercadmiumGlobalNPC.titanBoss < 0)
											{
												npc.active = false;
												npc.netUpdate = true;
												return;
											}
											if (NPC.CountNPCS(ModContent.NPCType<TitanTankorb>()) > 0)
											{
												Vector2 vector100 = new Vector2(npc.Center.X, npc.Center.Y);
												float num812 = Main.npc[AzercadmiumGlobalNPC.titanBoss].Center.X - vector100.X;
												float num813 = Main.npc[AzercadmiumGlobalNPC.titanBoss].Center.Y - vector100.Y;
												float num814 = (float)Math.Sqrt((double)(num812 * num812 + num813 * num813));
												if (num814 > 90f)
												{
													num814 = 8f / num814;
													num812 *= num814;
													num813 *= num814;
													npc.velocity.X = (npc.velocity.X * 15f + num812) / 16f;
													npc.velocity.Y = (npc.velocity.Y * 15f + num813) / 16f;
													return;
												}
												if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < 8f)
												{
													npc.velocity.Y = npc.velocity.Y * 1.05f;
													npc.velocity.X = npc.velocity.X * 1.05f;
												}
												if (Main.netMode != 1 && ((Main.expertMode && Main.rand.Next(100) == 0) || Main.rand.Next(200) == 0))
												{
													npc.TargetClosest(true);
													vector100 = new Vector2(npc.Center.X, npc.Center.Y);
													num812 = Main.player[npc.target].Center.X - vector100.X;
													num813 = Main.player[npc.target].Center.Y - vector100.Y;
													num814 = (float)Math.Sqrt((double)(num812 * num812 + num813 * num813));
													num814 = 8f / num814;
													npc.velocity.X = num812 * num814;
													npc.velocity.Y = num813 * num814;
													npc.ai[0] = 1f;
													npc.netUpdate = true;
													return;
												}
											}
											/*else
											{
												if (Main.expertMode)
												{
													Vector2 value2 = Main.player[npc.target].Center - npc.Center;
													value2.Normalize();
													value2 *= 9f;
													npc.velocity = (npc.velocity * 99f + value2) / 100f;
												}
												Vector2 vector101 = new Vector2(npc.Center.X, npc.Center.Y);
												float num815 = Main.npc[AzercadmiumGlobalNPC.titanBoss].Center.X - vector101.X;
												float num816 = Main.npc[AzercadmiumGlobalNPC.titanBoss].Center.Y - vector101.Y;
												float num817 = (float)Math.Sqrt((double)(num815 * num815 + num816 * num816));
												if (num817 > 700f || npc.justHit)
												{
													npc.ai[0] = 0f;
													return;
												}
											}*/
			if (NPC.CountNPCS(ModContent.NPCType<TitanTankorb>()) < 1) {
				npc.velocity.Y = 10;
			}
		}
		public override void NPCLoot() {
			if (Main.rand.Next(50) == 0)
				Item.NewItem(npc.getRect(), ItemID.TitaniumOre);
		}
	}
}