using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Christmas
{
	public class CandyCaneCrusher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to shoot a star anise with a 12 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 18;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.8f;
			item.value = Item.sellPrice(0, 0, 27, 0);
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
				player.AddBuff(mod.BuffType("BatCooldown"), 720);
				
				Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.Center) * 9, ProjectileID.StarAnise, item.damage, item.knockBack / 2, Main.myPlayer);
			}
			return true;
		}
		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PineTreeBlock, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}