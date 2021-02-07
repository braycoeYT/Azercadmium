using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class RoyalSlimeGun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots gel\nUses gel as ammo");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 37;
			item.useTime = 37;
			item.damage = 91;
			item.width = 58;
			item.height = 38;
			item.knockBack = 4.2f;
			item.shoot = ModContent.ProjectileType<Projectiles.Slime.GelShot>();
			item.shootSpeed = 22f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Gel;
			item.UseSound = SoundID.Item63;
			item.autoReuse = true;
			item.rare = ItemRarityID.Lime;
		}
	}
}