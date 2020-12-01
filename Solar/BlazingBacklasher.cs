using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Solar
{
	public class BlazingBacklasher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Leaves an explosive trail behind itself\nRight click for a shorter range attack");
		}
		public override void SetDefaults() {
			item.damage = 243;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 8f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("BlazingBacklasher");
			item.shootSpeed = 14f;
			item.noUseGraphic = true;
		}
		public override bool AltFunctionUse(Player player) {
            return true;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (player.altFunctionUse == 2) {
				Projectile.NewProjectile(player.position, player.DirectionTo(Main.MouseWorld) * 7f, mod.ProjectileType("BlazingBacklasher"), item.damage, item.knockBack, Main.myPlayer);
				return false;
			}
			else
			return true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}