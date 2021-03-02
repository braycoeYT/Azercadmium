using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Snow
{
	public class LivingMarshmellow : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Living Marshmellow");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.width = 26;
			npc.height = 26;
			npc.damage = 14;
			npc.defense = 4;
			npc.lifeMax = 41;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 0, 75);
			npc.aiStyle = 1;
			npc.knockBackResist = 1f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 82;
            npc.damage = 28;
			npc.knockBackResist = 0.9f;
        }
		public override void AI() {
			if (npc.HasBuff(BuffID.OnFire) || npc.HasBuff(BuffID.CursedInferno) || npc.HasBuff(BuffID.Frostburn) || npc.HasBuff(BuffID.ShadowFlame) || npc.HasBuff(BuffID.Daybreak))
				npc.Transform(mod.NPCType("RoastedLivingMarshmellow"));
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.player.ZoneSnow)
				return 0.1f;
			return 0f;
        }
	    public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 3));
            if (Main.rand.NextFloat() < .75f)
				Item.NewItem(npc.getRect(), ItemID.Marshmallow);
			else if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("GrahamCracker"));
			else
				Item.NewItem(npc.getRect(), mod.ItemType("CocoaBeans"));
        }
	}
}