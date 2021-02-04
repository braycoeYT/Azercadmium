using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Developer.HBDeus
{
	public class HBDeusGreatsword : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("HBDeus's Greatsword");
			Tooltip.SetDefault("Developer Item\nRains Shattered Swords near the cursor from above and below");
		}
		public override void SetDefaults() {
			item.damage = 1534;
			item.melee = true;
			item.width = 112;
			item.height = 112;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.8f;
			item.value = Item.sellPrice(2, 0, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ShatteredSword");
			item.shootSpeed = 14f;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(116, 179, 237);
                }
            }
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-3, 3), 20);
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(Main.MouseWorld.X, position.Y - Main.rand.Next(500, 701), perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.75f), (int)(knockBack * 0.5f), player.whoAmI);
			}
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-3, 3), -20);
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(Main.MouseWorld.X, position.Y + Main.rand.Next(500, 701), perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.75f), (int)(knockBack * 0.5f), player.whoAmI);
			}
			return false;
		}
	}
}