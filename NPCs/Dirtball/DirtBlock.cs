using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Dirtball
{
	public class DirtBlock : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirt Block");
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 16;
			npc.height = 16;
			npc.damage = 10;
			npc.defense = 256;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontCountMe = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 20;
			if (AzercadmiumWorld.devastation) {
				npc.damage = 30;
			}
        }
		public override void AI() {
			if (AzercadmiumGlobalNPC.dirtballBoss < 0)
											{
												npc.active = false;
												npc.netUpdate = true;
												return;
											}
											if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) > 0)
											{
												Vector2 vector100 = new Vector2(npc.Center.X, npc.Center.Y);
												float num812 = Main.npc[AzercadmiumGlobalNPC.dirtballBoss].Center.X - vector100.X;
												float num813 = Main.npc[AzercadmiumGlobalNPC.dirtballBoss].Center.Y - vector100.Y;
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
				npc.velocity.Y = 10;
			}
		}
		public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.DirtBlock);
		}
	}
}