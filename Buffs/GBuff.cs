using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Helpers;
using Azercadmium.Aaa;

namespace Azercadmium.Buffs
{
    public class GBuff : GlobalBuff
    {
        public override bool ReApply(int type, Player player, int time, int buffIndex)
        {
            TAZPlayer bPlayer = player.ModPlayer();
            if (type == BuffID.OnFire)
            {
                if (bPlayer.burningSkin)
                {
                    player.buffTime[buffIndex] = (int)(time * 1.5f);
                }
            }
            return false;
        }
    }
}