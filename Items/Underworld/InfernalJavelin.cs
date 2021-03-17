using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Underworld
{
	public class InfernalJavelin : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Sets hit enemies aflame\nRight click to use the javelin as a spear (melee damage), shooting a fireball from its tip");
		}
		public override void SetDefaults() {
			item.width = 60;
			item.height = 60;
			item.damage = 42;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 38;
			item.useTime = 38;
			item.knockBack = 5.4f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(0, 0, 54);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Underworld.InfernalJavelin>();
			item.shootSpeed = 11f;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == ModContent.ProjectileType<Projectiles.Underworld.InfernalSpear>()) {
                    return false;
                }
            }
            return true;
        }
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (player.altFunctionUse == 2) {
				speedX /= 6f;
				speedY /= 6f;
				type = ModContent.ProjectileType<Projectiles.Underworld.InfernalSpear>();
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}