using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Sky
{
	public class GlazingStar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots feathers at nearby enemies");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 30;
			item.height = 26;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3.6f;
			item.damage = 22;
			item.rare = ItemRarityID.Blue;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.shoot = ProjectileType<Projectiles.Sky.GlazingStar>();
		}
	}
}