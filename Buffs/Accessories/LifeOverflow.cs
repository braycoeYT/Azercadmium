using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Accessories
{
    public class LifeOverflow : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Life Overflow");
            Description.SetDefault("Your life has extended past the max!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.statLifeMax2 += player.buffTime[buffIndex]/12;
            if (player.buffTime[buffIndex] > 600)
                player.buffTime[buffIndex] = 600;
        }
    }
}