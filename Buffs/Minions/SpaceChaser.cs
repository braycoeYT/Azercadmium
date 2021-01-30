using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions
{
	public class SpaceChaser : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Space Chaser");
			Description.SetDefault("The Space Chaser will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Scavenger.SpaceChaser>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}