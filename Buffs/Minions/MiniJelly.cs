using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions
{
	public class MiniJelly : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Mini Jelly");
			Description.SetDefault("The Mini Jelly will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Jelly.MiniJelly>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}