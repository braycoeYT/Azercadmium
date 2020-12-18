using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Bats
{
    public class Stunned : ModBuff
    {
        public override void SetDefaults() 
        {
            DisplayName.SetDefault("Stunned");
            Description.SetDefault("Your movement has been greatly hindered");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) 
        {
            player.dazed = true;
        }
        public override void Update(NPC npc, ref int buffIndex) 
        {
            if (!npc.boss)
            npc.velocity *= 0.3f;
        }
    }
}