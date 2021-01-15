using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Discus
{
	public class DesertDiscus : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Discus");
		}
        public override void SetDefaults() {
			npc.width = 40;
			npc.height = 46;
			npc.damage = 12;
			npc.defense = 6;
			npc.lifeMax = 33;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 14);
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
			banner = npc.type;
			bannerItem = ItemType<Items.Discus.Banners.DesertDiscusBanner>();
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 76;
            npc.damage = 25;
			npc.knockBackResist = 0.1f;
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = 216;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldDayDesert.Chance * 3f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(2));
		    if (Main.rand.NextFloat() < .1f)
	        Item.NewItem(npc.getRect(), ItemID.Amber);
        }
	}
}