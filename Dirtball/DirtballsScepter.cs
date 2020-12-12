using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DirtballsScepter : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtball's Scepter");
			Tooltip.SetDefault("Rains dirt on your enemies");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 18;
			item.magic = true;
			item.width = 50;
			item.height = 58;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 5.1f;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = ItemRarityID.Gray;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DirtSphere");
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.mana = 6;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.NextFloat(-1, 2);
			speedY = 15;
			return true;
		}
	}
}