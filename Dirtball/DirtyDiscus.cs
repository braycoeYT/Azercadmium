using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DirtyDiscus : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Feeling it makes you feel dirty...\nRapidly throw discuses");
		}
		public override void SetDefaults() {
			item.damage = 12;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 1.5f;
			item.value = 2000;
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("DirtyDiscus");
			item.shootSpeed = 12f;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
	}
}