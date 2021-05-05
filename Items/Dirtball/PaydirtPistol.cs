using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class PaydirtPistol : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a high speed bullet");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 28, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 32;
			item.useTime = 32;
			item.damage = 27;
			item.width = 36;
			item.height = 28;
			item.knockBack = 3.4f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 20f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = 1;
		}
	}
}