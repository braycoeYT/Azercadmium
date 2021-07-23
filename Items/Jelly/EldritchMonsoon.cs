using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
	public class EldritchMonsoon : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons three jellyfish to dash at enemies");
		}
		public override void SetDefaults() {
			item.damage = 21;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 46;
			item.useAnimation = 46;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3.6f;
			item.value = Item.sellPrice(0, 4);
			item.rare = ItemRarityID.Orange;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Jelly.MonsoonProj>();
			item.shootSpeed = 0f;
			item.noMelee = true;
			item.mana = 14;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			for (int i = 0; i < 3; i++) {
				Projectile.NewProjectile(player.position + new Vector2(Main.rand.Next(-160, 161), Main.rand.Next(-160, 161)), new Vector2(), ModContent.ProjectileType<Projectiles.Jelly.MonsoonProj>(), item.damage, item.knockBack, Main.myPlayer);
			}
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}