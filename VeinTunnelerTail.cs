using Terraria;
using Terraria.ID;

namespace Azercadmium.NPCs.Crimson
{
	internal class VeinTunnelerTail : VeinTunneler
	{
		public override string Texture { get { return "Azercadmium/NPCs/Crimson/VeinTunnelerTail"; } }
		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.damage = 11;
			npc.defense = 12;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.damage = 23;
		}
		public override void Init() {
			base.Init();
			tail = true;
		}
	}
}