using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Potions
{
    public class Psychic : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Psychic");
            Description.SetDefault("You are focused on your psychic ability");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.statLifeMax2 *= .95;
            player.manaRegen += 5;
        }
    }
}