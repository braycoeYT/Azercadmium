using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dungeon
{
	public class SpectreScythe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots two scythes, one higher velocity than the other\nTrue melee hits restore mana");
		}
		public override void SetDefaults() {
			item.damage = 74;
			item.melee = true;
			item.width = 60;
			item.height = 58;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.8f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Dungeon.SpectreScythe>();
			item.shootSpeed = 20f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			player.statMana += 1;
			player.ManaEffect(1);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			player.statMana += 1;
			player.ManaEffect(1);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Projectile.NewProjectile(player.position, new Vector2((int)(speedX / 1.5f), (int)(speedY / 1.5f)), ModContent.ProjectileType<Projectiles.Dungeon.SpectreScythe>(), item.damage, item.knockBack / 2, Main.myPlayer);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DeathSickle);
			recipe.AddIngredient(ItemID.SpectreBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}