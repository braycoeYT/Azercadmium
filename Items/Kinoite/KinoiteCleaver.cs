using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteCleaver : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Every three swings:\nFirst swing: Shoots a spread of Ghastly Cleavers\nSecond swing: Shoots several energy bits that will chase enemies\nThird swing: Doubled true melee damage");
		}
		public override void SetDefaults() {
			item.damage = 359;
			item.melee = true;
			item.width = 68;
			item.height = 78;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.5f;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item18;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Kinoite.KinoiteCleaverBlade>();
			item.shootSpeed = 18f;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3))
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.Kinoite.KinoiteDust>());
		}
		public override void GetWeaponDamage(Player player, ref int damage) {
			if (swingCount % 3 == 2)
				damage = (int)(624 * player.meleeDamage);
		}
		int swingCount = 0;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (swingCount % 3 == 0) {
				float numberProjectiles = 5;
				float rotation = MathHelper.ToRadians(15);
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
			}
			if (swingCount % 3 == 1) {
				int numberProjectiles = 6 + Main.rand.Next(4);
				for (int i = 0; i < numberProjectiles; i++) {
					float rand = Main.rand.NextFloat(0.1f, 0.6f);
					Vector2 perturbedSpeed = new Vector2(speedX * rand, speedY * rand).RotatedByRandom(MathHelper.ToRadians(20));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Projectiles.Kinoite.KinoiteEnergy>(), (int)(damage * 0.8f), knockBack / 4f, player.whoAmI);
				}
			}
			swingCount++;
			return false;
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