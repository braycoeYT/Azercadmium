using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions.Ores
{
	public class FloatingCobaltOre : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Floating Cobalt Ore");
			Description.SetDefault("The Floating Cobalt Ore will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Cobalt.FloatingCobaltOre>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}