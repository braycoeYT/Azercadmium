using Azercadmium.Aaa;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs
{
    public class Charred : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Charred");
            Description.SetDefault("You are being burned by ultra-hot fire!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GNPC().charred = true;
        }

        public override void Update(Player player, ref int buffIndex) => player.ModPlayer().charred = true;
    }
}