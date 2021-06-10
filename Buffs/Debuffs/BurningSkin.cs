using Azercadmium.Aaa;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs
{
    public class BurningSkin : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Burning Skin");
            Description.SetDefault("Your skin is being burnt to a crisp!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ModPlayer().burningSkin = true;
            if (!player.lavaWet || !player.ModPlayer().ZoneEmberGlades)
            {
                player.ClearBuff(Type);
                return;
            }
            for (int i = 0; i < Player.MaxBuffs; i++)
            {
                if (player.buffType[i] == BuffID.ObsidianSkin && player.buffTime[i] > 0)
                {
                    player.buffTime[i] -= 19;
                    break;
                }
            }
        }
    }
}