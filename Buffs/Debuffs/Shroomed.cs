using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs
{
    public class Shroomed : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Shroomed");
            Description.SetDefault("You have been infected by bioluminescent fungi");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<AzercadmiumPlayer>().shroomed = true;
		}
        bool safe;
        Color safeColor;
  		public override void Update(NPC npc, ref int buffIndex) {
            if (safe) {
                safeColor = npc.color;
                safe = false;
            }
			npc.GetGlobalNPC<NPCs.AzercadmiumGlobalNPC>().shroomed = true;
            npc.color = Color.DarkBlue;
            if (npc.buffTime[buffIndex] < 5)
                npc.color = safeColor;
		}
    }
}