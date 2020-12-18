using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs.Devastation
{
    public class Scared : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Scared");
            Description.SetDefault("Don't hug me...");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.blind = true;
            if (Main.hardMode)
            {
                player.statDefense *= 0.8;
                player.statDefense -= 20;
            }
            else
            {
                player.statDefense *= 0.8;
                player.statDefense -= 5;
            }
            player.moveSpeed *= 0.8f;
		}
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.AzercadmiumGlobalNPC>().slimyOoze = true;
            if (npc.boss != false)
            npc.velocity *= 0.8f;
		}
    }
}