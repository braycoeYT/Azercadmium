using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Dungeon
{
	public class BoneSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bone Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 38;
			npc.height = 18;
			npc.damage = 41;
			npc.defense = 9;
			npc.lifeMax = 91;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 75);
			npc.aiStyle = 1;
			npc.knockBackResist = 1f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 189;
            npc.damage = 71;
        }
		public override void AI() {
			npc.spriteDirection = npc.direction;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Dungeon.Chance * 0.1f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(4));
			Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 4));
            if (Main.rand.NextFloat() < .053f)
	        Item.NewItem(npc.getRect(), ItemID.GoldenKey);
        }
	}
}