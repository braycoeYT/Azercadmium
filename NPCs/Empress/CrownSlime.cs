using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Empress
{
	public class CrownSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 30;
			npc.height = 38;
			npc.damage = 90;
			npc.defense = 20;
			npc.lifeMax = 252;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = new Terraria.Audio.LegacySoundStyle(SoundID.Shatter, 0);
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 504;
            npc.damage = 180;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 756;
				npc.damage = 270;
			}
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				Main.PlaySound(SoundID.Shatter);
				float rotationInc = 40;
				if (Main.expertMode) rotationInc = 30;
				if (AzercadmiumWorld.devastation) rotationInc = 20;
				for (float rotation = 0; rotation < 360;)
				{
					rotation += rotationInc;
					Projectile.NewProjectile(npc.Center, new Vector2(0, 5).RotatedBy((Math.PI / 180) * rotation, default), mod.ProjectileType("CrownSlimeShard"), 34, 0f, Main.myPlayer);
				}
			}
		}
	}
}