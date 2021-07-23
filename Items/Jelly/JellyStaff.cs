using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Jelly
{
	public class JellyStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a Mini Jelly to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 29;
			item.knockBack = 4.2f;
			item.mana = 10;
			item.width = 30;
			item.height = 30;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 4);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<Buffs.Minions.MiniJelly>();
			item.shoot = ProjectileType<Projectiles.Jelly.MiniJelly>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
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