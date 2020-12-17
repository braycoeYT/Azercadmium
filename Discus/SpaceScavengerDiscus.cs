using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class SpaceScavengerDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Space Scavenger Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 25;
			npc.defense = 0;
			npc.lifeMax = 74;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 148;
            npc.damage = 50;
			npc.defense = 1;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneSkyHeight && GetInstance<AzercadmiumConfig>().elemDiscus)
				return 0.1f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
        }
	}
}