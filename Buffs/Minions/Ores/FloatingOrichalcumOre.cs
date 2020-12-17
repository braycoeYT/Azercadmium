using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions.Ores
{
	public class FloatingOrichalcumOre : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Floating Orichalcum Ore");
			Description.SetDefault("The Floating Orichalcum Ore will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.Ores.FloatingOrichalcumOre>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}