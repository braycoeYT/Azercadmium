using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class RedTintedDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Red Tinted Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 29;
			npc.defense = 2;
			npc.lifeMax = 102;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 25);
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 201;
            npc.damage = 49;
			npc.defense = 3;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneCrimson && GetInstance<AzercadmiumConfig>().elemDiscus)
				return 0.1f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
			if (Main.rand.NextFloat() < .6f)
	        Item.NewItem(npc.getRect(), ItemID.Vertebrae);
		    if (Main.rand.NextFloat() < .2f)
	        Item.NewItem(npc.getRect(), ItemID.ViciousPowder);
        }
	}
}