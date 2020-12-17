using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class CorruptDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Corrupt Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 41;
			npc.defense = 2;
			npc.lifeMax = 83;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 25);
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
			banner = npc.type;
			bannerItem = ItemType<Items.Discus.Banners.CorruptDiscusBanner>();
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 162;
            npc.damage = 79;
			npc.defense = 3;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneBeach && GetInstance<AzercadmiumConfig>().elemDiscus)
				return 0.1f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
			if (Main.rand.NextFloat() < .6f)
	        Item.NewItem(npc.getRect(), ItemID.RottenChunk);
		    if (Main.rand.NextFloat() < .2f)
	        Item.NewItem(npc.getRect(), ItemID.VilePowder);
        }
	}
}