using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Terra
{
	public class TerraJavelance : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Javelances can bombard terra orbs, steal life, and very rarely gives the user the buff 'Archived', increasing damage reduction by 25%\nStacks up to 6\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}
		public override void SetDefaults() {
			item.damage = 91;
			item.ranged = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.9f;
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.rare = ItemRarityID.Yellow;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("TerraJavelance");
			item.shootSpeed = 17f;
			item.noMelee = true;
			item.maxStack = 6;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player) {
			item.useTime = 30 + (item.stack * 10) - 10;
			item.useAnimation = 30 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (p.redJavelance)
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			if (Main.rand.NextFloat() < .035f)
				player.AddBuff(mod.BuffType("Archived"), 60);
			float numberProjectiles = item.stack;
			float rotation = MathHelper.ToRadians(18);
			if (numberProjectiles > 1) {
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return false;
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TrueShadowdance"), 5);
			recipe.AddIngredient(mod.ItemType("TrueArchive"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 6);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TrueFleshleech"), 5);
			recipe.AddIngredient(mod.ItemType("TrueArchive"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 6);
			recipe.AddRecipe();
		}
	}
}