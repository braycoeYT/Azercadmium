using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Potions
{
    public class Penetration : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Penetration");
            Description.SetDefault("Increases javelin max penetration by 2");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
            p.javelinPenetration += 2;
        }
    }
}