using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Xenic
{
    public class XenicAcid : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Xenic Acid");
            Description.SetDefault("Your blood runs green. That can't be good.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<AzercadmiumPlayer>().xenicAcid = true;
		}
  		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.AzercadmiumGlobalNPC>().xenicAcid = true;
		}
    }
}