using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class MuddyGreatsword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts a dirt ball");
		}
		public override void SetDefaults() {
			item.damage = 15;
			item.melee = true;
			item.width = 36;
			item.height = 44;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.2f;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DirtSphere");
			item.shootSpeed = 12f;
		}
	}
}