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
			item.damage = 20;
			item.melee = true;
			item.width = 36;
			item.height = 44;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 28, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DirtSphere");
			item.shootSpeed = 12f;
		}
	}
}