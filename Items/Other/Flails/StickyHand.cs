using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Flails
{
	public class StickyHand : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sticky Hand");
			Tooltip.SetDefault("Does not get dirty after 20 minutes of use, somehow\nSticks to enemies, dealing loads of extra damage");
		}
		public override void SetDefaults() {
			item.width = 60;
			item.height = 64;
			item.value = Item.sellPrice(0, 6);
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 45;
			item.useTime = 45;
			item.knockBack = 0f;
			item.damage = 69;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Other.Flails.StickyHand>();
			item.shootSpeed = 12f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}
	}
}