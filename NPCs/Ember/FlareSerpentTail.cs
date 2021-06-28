using Terraria;
using Terraria.ID;

namespace Azercadmium.NPCs.Ember
{
	internal class FlareSerpentTail : FlareSerpent
	{
		public override string Texture { get { return "Azercadmium/NPCs/Ember/FlareSerpentTail"; } }
		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.damage = 13;
			npc.defense = 9;
			npc.width = 20;
			npc.height = 40;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.damage = 26;
		}
		public override void Init() {
			base.Init();
			tail = true;
		}
	}
}