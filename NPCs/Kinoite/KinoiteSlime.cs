using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Kinoite
{
	public class KinoiteSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kinoite Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 26;
			npc.height = 26;
			npc.damage = 107;
			npc.defense = 32;
			npc.lifeMax = 3010;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 10, 0);
			npc.aiStyle = 1;
			npc.knockBackResist = 0.1f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 6020;
            npc.damage = 214;
			npc.knockBackResist = 0.05f;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (NPC.downedMoonlord && spawnInfo.player.ZoneDesert && (spawnInfo.player.ZoneDirtLayerHeight || spawnInfo.player.ZoneRockLayerHeight))
				return 0.2f;
			return 0f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 3));
            if (Main.rand.NextFloat() < .75f)
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Kinoite.KinoiteOre>(), Main.rand.Next(1, 3));
        }
	}
}