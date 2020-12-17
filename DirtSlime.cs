using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Slimes
{
	public class DirtSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirt Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 30;
			npc.height = 24;
			npc.damage = 8;
			npc.defense = 3;
			npc.lifeMax = 16;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.sellPrice(0, 0, 0, 10);
			npc.aiStyle = 1;
			npc.knockBackResist = 0.2f;
			animationType = 1;
			//npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 32;
            npc.damage = 16;
			npc.knockBackResist = 0.4f;
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldDaySlime.Chance * 0.05f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 4));
			Item.NewItem(npc.getRect(), ItemID.DirtBlock, Main.rand.Next(1, 4));
            if (Main.rand.NextFloat() < .5f) Item.NewItem(npc.getRect(), ItemID.MudBlock, Main.rand.Next(1, 3));
        }
	}
}