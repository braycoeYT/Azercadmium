using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class RainydayDiscus : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rainyday Discus");
		}
        public override void SetDefaults() {
			npc.width = 36;
			npc.height = 48;
			npc.damage = 21;
			npc.defense = 0;
			npc.lifeMax = 61;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 90f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 122;
            npc.damage = 49;
			npc.defense = 4;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneRain && GetInstance<AzercadmiumConfig>().elemDiscus)
				return 0.04f;
			return 0f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
        }
	}
}