using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Kinoite
{
	public class Galeolectron : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Minishark and Megashark's long lost big brother\nShoots a homing energy bit with every third shot\nEvery eighth shot is converted to an explosive electric bolt");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 96;
			item.width = 26;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 18f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Purple;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-20, -4);
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		int shootNum;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootNum++;
			if (shootNum % 8 == 0) {
				type = ModContent.ProjectileType<Projectiles.Kinoite.KinoiteBolt>();
				damage = (int)(damage * 1.5f);
				Main.PlaySound(new LegacySoundStyle(2, 96, Terraria.Audio.SoundType.Sound), player.position);
			}
			if (shootNum % 3 == 0)
				Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.Kinoite.KinoiteEnergy>(), (int)(item.damage * 0.75f), item.knockBack / 2, Main.myPlayer);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Megashark);
			recipe.AddIngredient(ModContent.ItemType<KinoiteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}