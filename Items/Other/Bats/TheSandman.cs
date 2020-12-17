using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Bats
{
	public class TheSandman : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to shoot a baseball which can temporarily stun non-boss enemies with a 15 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 25;
			item.melee = true;
			item.width = 36;
			item.height = 38;
			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.7f;
			item.value = Item.sellPrice(0, 0, 35, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 900);
				
				Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.position) * 10, mod.ProjectileType("StunningBaseball"), item.damage, item.knockBack / 2, Main.myPlayer);
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RookieBat"));
			recipe.AddIngredient(ItemID.Silk, 6);
			recipe.AddIngredient(ItemID.TatteredCloth, 3);
			recipe.AddRecipeGroup("Azercadmium:AnyShadowScale");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}