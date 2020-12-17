using System;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs.Devastation
{
    public class SlimyOoze : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Slimy Ooze");
            Description.SetDefault("Slimy digestive fluids are on you");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<AzercadmiumPlayer>().slimyOoze = true;
            if (player.velocity.Y == 0f && Math.Abs(player.velocity.X) > 1f)
				player.velocity.X = player.velocity.X / 1.5f;
		}
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.AzercadmiumGlobalNPC>().slimyOoze = true;
            if (npc.boss != false)
            npc.velocity *= 0.8f;
		}
    }
}