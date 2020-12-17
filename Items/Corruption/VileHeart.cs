using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Corruption
{
	public class VileHeart : ModItem
	{
		public override void SetDefaults() {
			item.rare = ItemRarityID.Green;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(666, 0, 0, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 15;
		}
		int Timer;
		public override void Update(ref float gravity, ref float maxFallSpeed) {
			Timer++;
			if (Timer >= 3600)
				item.active = false;
		}
		public override bool OnPickup(Player player) {
			player.statLife -= 10;
			player.HealEffect(-10, true);
			if (player.statLife <= 0) {
				player.statLife = 0;
				player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " was corrupted."), 10, 0, false);
			}
			return false;
		}
	}
}