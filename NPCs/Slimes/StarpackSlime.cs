using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Slimes
{
	public class StarpackSlime : ModNPC
	{
		public override void SetStaticDefaults()  {
			DisplayName.SetDefault("Starpack Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 40;
			npc.height = 40;
			npc.damage = 17;
			npc.defense = 6;
			npc.lifeMax = 49;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 75);
			npc.aiStyle = 14;
			npc.knockBackResist = 1f;
			animationType = 1;
			npc.noGravity = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 98;
            npc.damage = 34;
			npc.knockBackResist = 0.2f;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Sky.Chance * 0.1f;
        }
	    public override void NPCLoot() {
            if (Main.rand.Next(100) == 0)
	            Item.NewItem(npc.getRect(), ItemID.Starfury);
			if (Main.rand.Next(100) == 0)
	            Item.NewItem(npc.getRect(), mod.ItemType("Starfrenzy"));
        }
	}
}