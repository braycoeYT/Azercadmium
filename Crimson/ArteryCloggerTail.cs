using Terraria;
using Terraria.ID;

namespace Azercadmium.NPCs.Crimson
{
	internal class ArteryCloggerTail : ArteryClogger
	{
		public override string Texture { get { return "Azercadmium/NPCs/Crimson/ArteryCloggerTail"; } }
		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.damage = 46;
			npc.defense = 37;
			npc.width = 52;
			npc.height = 48;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.damage = 92;
		}
		public override void Init() {
			base.Init();
			tail = true;
		}
	}
}