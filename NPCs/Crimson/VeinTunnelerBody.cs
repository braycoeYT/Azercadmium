using Terraria;
using Terraria.ID;

namespace Azercadmium.NPCs.Crimson
{
	internal class VeinTunnelerBody : VeinTunneler
	{
		public override string Texture { get { return "Azercadmium/NPCs/Crimson/VeinTunnelerBody"; } }
		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.damage = 17;
			npc.defense = 8;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.damage = 31;
		}
	}
}