using Terraria;
using Terraria.ID;

namespace Azercadmium.NPCs.Ember
{
	internal class FlareSerpentBody : FlareSerpent
	{
		public override string Texture { get { return "Azercadmium/NPCs/Ember/FlareSerpentBody"; } }
		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.damage = 20;
			npc.defense = 6;
			npc.width = 20;
			npc.height = 36;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.damage = 40;
		}
	}
}