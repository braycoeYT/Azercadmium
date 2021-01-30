using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Blowpipes
{
    public class OutOfBreath : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Out of Breath");
            Description.SetDefault("You can't breathe!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            if (player.wet)
            player.breath -= 1;
            else
            if (Main.GameUpdateCount % 2 == 0)
            player.breath -= 3;
            else
            player.breath -= 4;
            if (player.breath <= 0) {
                player.breath = 0;
                player.GetModPlayer<AzercadmiumPlayer>().outofBreath = true;
            }
        }
    }
}