using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Empress
{
	public class GoopyScepter : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("INVALID ITEM");
			Tooltip.SetDefault("Summons a royal mother slime to fight for you\nHey you! Yeah, you! The one reading this! This item doesn't work!");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 42;
			item.knockBack = 3.5f;
			item.mana = 10;
			item.width = 56;
			item.height = 56;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<Buffs.Minions.RoyalMotherSlime>();
			item.shoot = ProjectileType<Projectiles.Empress.RoyalMotherSlime>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}