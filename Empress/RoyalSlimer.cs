using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Empress
{
	public class RoyalSlimer : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Royal Slimer");
			Main.npcFrameCount[npc.type] = 9;
		}
        public override void SetDefaults() {
			npc.width = 67;
			npc.height = 30;
			npc.damage = 74;
			npc.defense = 12;
			npc.lifeMax = 108;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0f;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 216;
            npc.damage = 144;
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("RoyalMotherSlime"));
		}
		int Timer;
		int animationTimer;
		public override void AI() {
			Timer++;
			if (Timer % 3 == 0)
				animationTimer++;
			if (animationTimer > 8)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 56;
		}
		public override void OnHitPlayer(Player player, int damage, bool crit) {
			if (Main.rand.NextBool(4))
				player.AddBuff(BuffID.Venom, 300, true);
		}
	}
}