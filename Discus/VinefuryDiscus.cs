using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class VinefuryDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Vinefury Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 30;
			npc.defense = 8;
			npc.lifeMax = 69;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 17);
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 139;
            npc.damage = 60;
			npc.defense = 16;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (AzercadmiumWorld.downedDiscus && spawnInfo.player.ZoneJungle && GetInstance<AzercadmiumConfig>().elemDiscus)
				return 0.075f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
			if (Main.rand.NextFloat() < .6f)
	        Item.NewItem(npc.getRect(), ItemID.Stinger);
		    if (Main.rand.NextFloat() < .2f)
	        Item.NewItem(npc.getRect(), ItemID.JungleSpores);
			if (Main.rand.NextFloat() < .1f)
	        Item.NewItem(npc.getRect(), ItemID.Vine);
        }
	}
}