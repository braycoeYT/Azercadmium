using System;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs
{
    public class WornOut : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Worn Out");
            Description.SetDefault("You are exhausted and cannot use weapons");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.noItems = true;
		}
    }
}