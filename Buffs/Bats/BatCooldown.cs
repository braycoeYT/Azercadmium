using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Bats
{
    public class BatCooldown : ModBuff
    {
        public override void SetDefaults() 
        {
            DisplayName.SetDefault("Bat Cooldown");
            Description.SetDefault("All of your baseball bats are on a cooldown");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
    }
}