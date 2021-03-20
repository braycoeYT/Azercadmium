using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Weapons
{
    public class Hardened : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Hardened");
            Description.SetDefault("Increased defense slightly");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 5;
        }
    }
}