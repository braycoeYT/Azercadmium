using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Azercadmium.Items.Braycoe
{
	public class CheckeredFlag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Checkered Flag");
			Tooltip.SetDefault("This signals the end of a level\nSummons a pet marble");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Pets.MarblePet>();
			item.buffType = BuffType<Buffs.Pets.MarbleBuff>();
			item.mana = 0;
			item.damage = 0;
			item.value = Item.sellPrice(0, 10, 0, 0);
		}
		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
				player.AddBuff(item.buffType, 600, true);
		}
	}
}