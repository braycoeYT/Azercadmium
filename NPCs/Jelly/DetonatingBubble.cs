using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Jelly
{
	public class DetonatingBubble : ModNPC
	{
        public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DetonatingBubble);
			npc.damage = 60;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.damage = 90;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			for (int i = 0; i < 10; i++) {
				int dustType = ModContent.DustType<Dusts.WaterDust>();;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = npc.velocity.X * -0.5f;
				dust.velocity.Y = npc.velocity.Y * -0.5f;
				dust.scale *= 0.33f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < (int)(10*npc.scale); i++) {
				int dustType = ModContent.DustType<Dusts.WaterDust>();;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity = new Microsoft.Xna.Framework.Vector2();
				dust.noGravity = false;
				dust.scale *= 0.33f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}