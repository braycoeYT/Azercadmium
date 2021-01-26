using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Sky
{
	public class Starfrenzy : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Causes stars to rain from the sky\nForged from the fury of shortsword heaven");
		}
		public override void SetDefaults() {
			item.damage = 16;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 5.5f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
			item.shoot = ProjectileID.Starfury;
			item.shootSpeed = 20f;
			item.alpha = 100;
			item.color = new Color(150, 150, 150, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = 0;
			speedY = 20;
			return true;
		}
	}
}