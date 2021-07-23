using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Jelly
{
	public class BeamEerieJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 3;
		}
        public override void SetDefaults() {
			npc.width = 30;
			npc.height = 30;
			npc.damage = 35;
			npc.lifeMax = 1;
			npc.aiStyle = -1;
			npc.dontTakeDamage = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.alpha = 255;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 70;
        }
		int Timer;
		int attackCount;
		public override void AI() {
			if (Timer % 5 == 0)
				npc.frameCounter++;
			if (npc.frameCounter > 2)
				npc.frameCounter = 0;
			npc.frame.Y = (int)(npc.frameCounter * 72);

			if (npc.ai[1] == 1)
				npc.rotation = MathHelper.ToRadians(270);
			npc.TargetClosest();
			Timer++;
			if (Timer < 60)
				npc.color = Color.Transparent;
			else if (Timer % 5 == 0 && Timer < 120) {
				if (npc.color == Color.Blue)
					npc.color = Color.Transparent;
				else
					npc.color = Color.Blue;
			}
			else if (Timer > 119)
				npc.color = Color.Blue;
			else
				npc.velocity *= 0.98f;
			if (Timer == 120) {
				Main.PlaySound(SoundID.Item124);
				int beamDamage = (int)(25 + npc.ai[0]);
				if (Main.expertMode) beamDamage = (int)(35 + npc.ai[0]);
				if (npc.ai[1] == 0) Projectile.NewProjectile(npc.position - new Vector2(2, 8), new Vector2(), ModContent.ProjectileType<Projectiles.Jelly.JellyBeamBody>(), beamDamage, 0f, Main.myPlayer, 30, 2f);
				else Projectile.NewProjectile(npc.Center + new Vector2(-6, -32), new Vector2(), ModContent.ProjectileType<Projectiles.Jelly.JellyBeamBody>(), beamDamage, 0f, Main.myPlayer, 30, 1f);
				attackCount++;
			}
			if (Timer >= 120)
			if (Timer > 180) {
				Timer = 0;
			}
			if (attackCount < 2 && npc.alpha > 0)
				npc.alpha -= 17;
			if (attackCount > 2)
				npc.alpha += 17;
			if (npc.alpha >= 255)
				npc.life = 0;

			if (npc.ai[1] == 0) {
				if (Timer % 5 == 0)
				if (npc.Center.X < Main.player[npc.target].Center.X) npc.velocity.X += 1;
				else npc.velocity.X -= 1;
				if (npc.velocity.X > 16)
					npc.velocity.X = 16;
				if (npc.velocity.X < -16)
					npc.velocity.X = -16;
				if (Timer >= 120)
					npc.velocity.X = 0;
				else
					npc.position.Y = Main.player[npc.target].position.Y - 320;
			}
			else { 
				if (Timer % 5 == 0)
				if (npc.Center.Y < Main.player[npc.target].Center.Y) npc.velocity.Y += 1;
				else npc.velocity.Y -= 1;
				if (npc.velocity.Y > 16)
					npc.velocity.Y = 16;
				if (npc.velocity.Y < -16)
					npc.velocity.Y = -16;
				if (Timer >= 120)
					npc.velocity.Y = 0;
				else
					npc.position.X = Main.player[npc.target].position.X - 700;
			}
		}
	}
}