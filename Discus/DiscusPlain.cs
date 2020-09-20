using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class DiscusPlain : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Discus");
		}
        public override void SetDefaults() {
			npc.width = 42;
			npc.height = 48;
			npc.damage = 17;
			npc.defense = 4;
			npc.lifeMax = 29;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 50f;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
			banner = npc.type;
			bannerItem = ItemType<Items.Banners.Discus.DiscusPlainBanner>();
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 68;
            npc.damage = 31;
			npc.knockBackResist = 0.2f;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneOverworldHeight && GetInstance<AzercadmiumConfig>().plainDiscus)
				return 0.025f;
			return 0f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(2));
        }
	}
}