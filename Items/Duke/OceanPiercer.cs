using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Duke
{
	public class OceanPiercer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires homing bubbles at the cursor");
		}
		public override void SetDefaults() {
			item.damage = 69;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 10;
			item.useTime = 30;
			item.shootSpeed = 5.5f;
			item.knockBack = 5.4f;
			item.width = 44;
			item.height = 44;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Duke.OceanPiercer>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
}