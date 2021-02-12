using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Blowpipes
{
	public class FamiliarFoamDartPistol : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It's this or nothing, they say...");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 14;
			item.useTime = 14;
			item.damage = 21;
			item.width = 36;
			item.height = 22;
			item.knockBack = 0.8f;
			item.shoot = ProjectileID.Seed;
			item.shootSpeed = 21f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Dart;
			item.UseSound = SoundID.Item17;
			item.autoReuse = true;
			item.rare = ItemRarityID.LightRed;
			item.crit = 6;
		}
	}
}