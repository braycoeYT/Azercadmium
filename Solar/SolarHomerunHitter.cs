using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Solar
{
	public class SolarHomerunHitter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to shoot a big solar fragment that explodes into smaller fragments with a 10 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 178;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 49;
			item.useAnimation = 49;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7.1f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(BuffID.Daybreak, 120);
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 600);
				
				Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.position) * 10, mod.ProjectileType("GiantSolarFragment"), item.damage, item.knockBack / 2, Main.myPlayer);
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