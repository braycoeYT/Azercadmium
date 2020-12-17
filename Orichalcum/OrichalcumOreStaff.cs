using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Orichalcum
{
	public class OrichalcumOreStaff : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Orichalcum Ore Staff");
			Tooltip.SetDefault("Summons a floating orichalcum ore to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 27;
			item.knockBack = 4.55f;
			item.mana = 10;
			item.width = 50;
			item.height = 50;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 1, 65, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<Buffs.Minions.Ores.FloatingOrichalcumOre>();
			item.shoot = ProjectileType<Projectiles.Orichalcum.FloatingOrichalcumOre>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}