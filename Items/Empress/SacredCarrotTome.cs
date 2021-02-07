using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class SacredCarrotTome : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots carrots which make enemies drop more money on hit");
		}
		public override void SetDefaults() {
			item.damage = 79;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2.8f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("CarrotPassive");
			item.shootSpeed = 11f;
			item.noMelee = true;
			item.mana = 9;
			item.maxStack = 1;
			item.UseSound = SoundID.Item1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}