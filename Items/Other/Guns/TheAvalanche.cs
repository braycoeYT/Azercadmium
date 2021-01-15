using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Guns
{
	public class TheAvalanche : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Left click to fire snowballs, and right click to fire sand\n33% chance to not consume ammo");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 11;
			item.useTime = 11;
			item.damage = 220;
			item.width = 54;
			item.height = 26;
			item.knockBack = 0f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 13f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Sand;
			item.UseSound = SoundID.Item11;
			item.rare = ItemRarityID.Red;
			item.autoReuse = true;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .33f) return false;
			else return true;
        }
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		int shootType;
		public override void UpdateInventory(Player player) {
			shootType = player.altFunctionUse;
			if (Main.mouseLeft) {
				item.ammo = AmmoID.Sand;
			} 
			else if (Main.mouseRight) { 
				item.ammo = AmmoID.Snowball;
			}
		}
		public override bool UseItem(Player player) {
			if (shootType == 2) return player.HasItem(ItemID.SandBlock);
			else return player.HasItem(ItemID.Snowball);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (Main.mouseLeft) type = ProjectileID.SandBallGun;
			else type = ProjectileID.SnowBallFriendly;
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			// If you want to randomize the speed to stagger the projectiles
			float scale = 1f - (Main.rand.NextFloat() * .3f);
			perturbedSpeed = perturbedSpeed * scale; 
			if (Main.mouseLeft) scale /= 2;
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}