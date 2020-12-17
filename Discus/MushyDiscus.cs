using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class MushyDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mushy Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 38;
			npc.defense = 0;
			npc.lifeMax = 56;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 18);
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 111;
            npc.damage = 83;
			npc.defense = 0;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneGlowshroom && GetInstance<AzercadmiumConfig>().elemDiscus)
				return 0.1f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
		    if (Main.rand.NextFloat() < .5f)
	        Item.NewItem(npc.getRect(), ItemID.GlowingMushroom);
        }
	}
}