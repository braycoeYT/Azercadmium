using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Pets
{
	public class CytocellBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Cytocell");
			Description.SetDefault("\"A little cell is following you.\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<AzercadmiumPlayer>().cytocellPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Microbiome.Cytocell>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Microbiome.Cytocell>(), 0, 0f, player.whoAmI, 0f, 0f);;
			}
		}
	}
}