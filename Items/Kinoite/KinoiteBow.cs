using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Left click to shoot one arrow and several pulse bolts, and right click to shoot a barrage of weaker arrows\nEvery shot also casts kinoite energy");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 30);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 27;
			item.useTime = 27;
			item.damage = 284;
			item.width = 24;
			item.height = 40;
			item.knockBack = 3.4f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Purple;
			item.autoReuse = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		public override bool AltFunctionUse(Player player) {
            return true;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			float numberProjectiles;
			if (player.altFunctionUse == 2) {
				numberProjectiles = Main.rand.Next(10, 15);
				float rotation = MathHelper.ToRadians(15);
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.15f), (int)(knockBack * 0.15f), player.whoAmI);
				}
			}
			else {
				numberProjectiles = 5;
				float rotation = MathHelper.ToRadians(5);
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.PulseBolt, damage, knockBack, player.whoAmI);
				}
			}
			Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.Kinoite.KinoiteEnergy>(), (int)(item.damage * 0.75f), item.knockBack / 2, Main.myPlayer);
			return player.altFunctionUse != 2;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<KinoiteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}