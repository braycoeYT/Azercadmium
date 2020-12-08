using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Vortex
{
	public class VortexBlowpipe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("66% chance to not consume ammo\nFires a multitude of seeds and a vortex rocket that chases enemies\nUses seeds as ammo");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 50;
			item.knockBack = 3.1f;
			item.shootSpeed = 16f;
			item.useTime = 18;
			item.useAnimation = 18;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.shootSpeed = 22f;
			item.rare = ItemRarityID.Red;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 3 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); //30
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Projectile.NewProjectile(player.Center, new Vector2(speedX * 0.2f, speedY * 0.2f), ProjectileID.VortexBeaterRocket, damage, knockBack, Main.myPlayer);
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return false;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .66f) return false;
			else return true;
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}