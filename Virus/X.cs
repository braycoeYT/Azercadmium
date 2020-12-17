using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Virus
{
	public class X : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("X");
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 30;
			npc.height = 30;
			npc.damage = 45;
			npc.defense = 18;
			npc.lifeMax = 175;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0f;
			npc.aiStyle = 5;
			npc.noGravity = true;
			npc.noTileCollide = true;
			aiType = NPCID.Probe;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 275;
            npc.damage = 70;
        }
	}
}