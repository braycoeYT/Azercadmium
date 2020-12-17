using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DirtyBlowpipe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Uses seeds as ammo");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 17; //9, mod 14
			item.knockBack = 4.2f; //3.5
			item.shootSpeed = 13f; //11
			item.useTime = 51; //45
			item.useAnimation = 51; //45
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = -1;
			item.autoReuse = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -5);
		}
	}
}