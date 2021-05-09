using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Lihzahrd
{
	public class LihzahrdLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots multiple high-speed lihzahrd beams");
		}
		public override void SetDefaults() {
			item.damage = 81;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 22;
			item.useTime = 29;
			item.shootSpeed = 5.5f;
			item.knockBack = 5.4f;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Lime;
			item.value = Item.sellPrice(0, 6, 50, 0);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Lihzahrd.LihzahrdLance>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
}