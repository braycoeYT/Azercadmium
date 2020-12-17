using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Hallow
{
	public class PearlwoodBat : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to shoot a baseball with a 20 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 12;
			item.melee = true;
			item.width = 36;
			item.height = 38;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.1f;
			item.value = Item.sellPrice(0, 0, 0, 20);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
			if (GetInstance<AzercadmiumConfig>().pearlwoodBuff)
				item.damage = 55;
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 1200);
				
				if (GetInstance<AzercadmiumConfig>().pearlwoodBuff)
					Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.Center) * 11, mod.ProjectileType("Baseball"), item.damage, item.knockBack / 2, Main.myPlayer);
				else
					Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.Center) * 8, mod.ProjectileType("Baseball"), item.damage, item.knockBack / 2, Main.myPlayer);
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pearlwood, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}