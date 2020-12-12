using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Dirtball
{
	public class Dirtboi : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtboi");
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 38;
			npc.height = 36;
			npc.damage = 36;
			npc.defense = 25;
			npc.lifeMax = 550;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			if (!AzercadmiumWorld.devastation) {
				//npc.friendly = true;
				npc.dontTakeDamage = true;
			}
        }
		int Timer;
		int attack;
		int attackTimer;
		bool attackDone = true;
		public override void AI() {
			Player target = Main.player[npc.target];
			if (AzercadmiumGlobalNPC.dirtballBoss < 0)
											{
												npc.active = false;
												npc.netUpdate = true;
												return;
											}
											if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) > 0)
											{
												Vector2 vector100 = new Vector2(npc.Center.X, npc.Center.Y);
												float num812 = (Main.npc[AzercadmiumGlobalNPC.dirtballBoss].Center.X - Main.npc[AzercadmiumGlobalNPC.dirtballBoss].velocity.X * 20) - vector100.X;
												float num813 = (Main.npc[AzercadmiumGlobalNPC.dirtballBoss].Center.Y - Main.npc[AzercadmiumGlobalNPC.dirtballBoss].velocity.Y * 20) - vector100.Y;
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
												float num815 = Main.npc[AzercadmiumGlobalNPC.dirtballBoss].Center.X - vector101.X;
												float num816 = Main.npc[AzercadmiumGlobalNPC.dirtballBoss].Center.Y - vector101.Y;
												float num817 = (float)Math.Sqrt((double)(num815 * num815 + num816 * num816));
												if (num817 > 700f || npc.justHit)
												{
													npc.ai[0] = 0f;
													return;
												}
											}*/
			if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) < 1) {
				npc.velocity = new Vector2(0, 0);
				Timer++;
				if (Timer % 10 == 0 && GetInstance<AzercadmiumConfig>().dirtboiCries) {
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-30, 31), npc.Center.Y, 0, 10, mod.ProjectileType("DirtboiTears"), 0, 0f, Main.myPlayer, 0f, 0f);
				}
				if (Timer > 180 || !GetInstance<AzercadmiumConfig>().dirtboiCries)
					npc.velocity.Y = 10;
			}
			if (!AzercadmiumWorld.devastation) {
				attack = 99;
				attackDone = false;
			}
			if (attackDone) {
				attackTimer = 0;
				attackDone = false;
				attack = Main.rand.Next(0, 3);
			}
			if (attack == 0) {
				if (attackTimer == 0)
					Projectile.NewProjectile(npc.Center, Vector2.Normalize((target.position - new Vector2(0, -10)) - npc.Center) * 12, mod.ProjectileType("DirtGlobHostile"), 10, 0f, Main.myPlayer, 0f, 0f);
				attackTimer++;
				if (attackTimer % 60 == 0)
					attackDone = true;
			}
			if (attack == 1) {
				if (attackTimer == 0)
				for (int i = 0; i < 3; i++) {
					NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-60, 61), (int)npc.Center.Y + Main.rand.Next(-60, 61), mod.NPCType("DirtBlock"));
				}
				attackTimer++;
				if (attackTimer % 60 == 0)
					attackDone = true;
			}
			if (attack == 2) {
				if (attackTimer == 0)
				for (int i = 0; i < 3; i++) {
					Projectile.NewProjectile(npc.Center, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-14, -6)), mod.ProjectileType("DirtSphereHostile"), 12, 0f, Main.myPlayer, 0f, 0f);
				}
				attackTimer++;
				if (attackTimer % 60 == 0)
					attackDone = true;
			}
		}
	}
}