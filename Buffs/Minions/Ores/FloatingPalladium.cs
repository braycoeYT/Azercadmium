using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions.Ores
{
	public class FloatingPalladiumOre : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Floating Palladium Ore");
			Description.SetDefault("The Floating Palladium Ore will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.Ores.FloatingPalladiumOre>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}