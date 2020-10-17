using Terraria;
using Terraria.ID;

namespace Azercadmium.NPCs.Crimson
{
	internal class ArteryCloggerBody : ArteryClogger
	{
		public override string Texture { get { return "Azercadmium/NPCs/Crimson/ArteryCloggerBody"; } }
		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.damage = 47;
			npc.defense = 32;
			npc.width = 30;
			npc.height = 24;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.damage = 94;
		}
	}
}