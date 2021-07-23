using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Jelly
{
	public class ExplosiveEerieJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 3;
		}
        public override void SetDefaults() {
			npc.width = 40;
			npc.height = 68;
			npc.damage = 35;
			npc.lifeMax = 1;
			npc.aiStyle = -1;
			npc.dontTakeDamage = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 70;
        }
		int Timer;
		public override void AI() {
			npc.TargetClosest();
			Timer++;

			if (Timer % 5 == 0) {
				if (npc.color == Color.Red)
					npc.color = Color.Transparent;
				else
					npc.color = Color.Red;
			}

			if (Timer == 1)
				npc.velocity = (npc.Center - Main.player[npc.target].Center) * (-0.025f);
			else
				npc.velocity *= 0.98f;
			if (Timer == 90) {
				npc.life = 0;
				Main.PlaySound(SoundID.Item62);
				int beamDamage = (int)(25 + npc.ai[0]);
				if (Main.expertMode) beamDamage = (int)(35 + npc.ai[0]);
					Projectile.NewProjectile(npc.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Jelly.JellyBeamCenter>(), beamDamage, 0f, Main.myPlayer, npc.ai[0] + 5);
			}
			npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + MathHelper.ToRadians(90);

			if (Timer % 5 == 0)
				npc.frameCounter++;
			if (npc.frameCounter > 2)
				npc.frameCounter = 0;
			npc.frame.Y = (int)(npc.frameCounter * 72);
		}
	}
}