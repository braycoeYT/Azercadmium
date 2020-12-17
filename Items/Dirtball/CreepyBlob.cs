using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Dirtball
{
	public class CreepyBlob : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a friendly dirtboi to follow you");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Dirtball.Dirtboi>();
			item.buffType = BuffType<Buffs.Pets.DirtboiBuff>();
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = -1;
			item.width = 24;
			item.height = 24;
		}
		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 600, true);
			}
		}
	}
}