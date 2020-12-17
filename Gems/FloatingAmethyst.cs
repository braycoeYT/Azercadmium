using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions.Gems
{
	public class FloatingAmethyst : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Floating Amethyst");
			Description.SetDefault("The Floating Amethyst will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Amethyst.FloatingAmethyst>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}