using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Jelly
{
	public class EerieJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 30;
			npc.height = 28;
			npc.damage = 35;
			npc.defense = 8;
			npc.lifeMax = 105;
			npc.HitSound = SoundID.NPCHit25;
			npc.DeathSound = SoundID.NPCDeath28;
			npc.value = Item.sellPrice(0, 0, 1);
			npc.aiStyle = 18;
			animationType = 1;
			npc.buffImmune[BuffID.Confused] = true;
			npc.noGravity = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 210;
            npc.damage = 70;
			npc.knockBackResist = 0.9f;
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 4; i++) {
				int dustType = ModContent.DustType<Dusts.Jelly.JellyDust>();
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int mode;
		int timer;
		public override void AI() {
			if (mode == 0) {
				if (npc.alpha < 255)
				npc.alpha += 3;
				else
				timer++;
				if (timer >= 60) {
					mode = 1;
					timer = 0;
				}
			}
			if (mode == 1) {
				if (npc.alpha > 0)
				npc.alpha -= 3;
				else
				timer++;
				if (timer >= 60) {
					mode = 0;
					timer = 0;
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (NPC.downedBoss3) return ((SpawnCondition.CaveJellyfish.Chance*2f) + SpawnCondition.OceanMonster.Chance) * 0.625f;
			else return 0f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.Glowstick, Main.rand.Next(1, 5));
			if (Main.rand.NextFloat() < .75f) Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Jelly.EerieBell>());
            if (Main.rand.NextFloat() < .01f) Item.NewItem(npc.getRect(), ItemID.JellyfishNecklace);
        }
	}
}