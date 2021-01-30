using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Dirtball
{
	public class SecurityDiscus : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Security Drone");
			Main.npcFrameCount[npc.type] = 6;
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 56;
			npc.height = 18;
			npc.damage = 10;
			npc.defense = 0;
			npc.lifeMax = 16;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 32;
            npc.damage = 20;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 48;
				npc.damage = 30;
			}
        }
		int Timer;
		int animationTimer;
		public override void AI() {
			if (Timer % 5 == 0)
				animationTimer++;
			if (animationTimer > 5)
				animationTimer = 0;
				npc.frame.Y = animationTimer * 46;
		}
	}
}