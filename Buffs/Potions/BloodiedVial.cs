using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Potions
{
    public class BloodiedVial : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Bloodied Vial");
            Description.SetDefault("8% chance of any attack to leech health from enemies");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
            p.bloodVial = true;
        }
    }
}