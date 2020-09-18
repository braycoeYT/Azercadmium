using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Potions
{
    public class Stealthy : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Stealthy");
            Description.SetDefault("Increased movement speed and you have a 4% chance to dodge attacks");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.maxRunSpeed += 0.1f;
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
            p.stealthPotion = true;
        }
    }
}