using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Titan
{
	public class TitansGatlibow : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan's Gatlibow");
			Tooltip.SetDefault("The bow and gatling combination you didn't know you needed until now!\nShoots arrows at ludicrous speed at the cost of accuracy");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 5, 45, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 7;
			item.useTime = 7;
			item.damage = 21;
			item.width = 24;
			item.height = 40;
			item.knockBack = 3.2f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 24f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.LightRed;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}