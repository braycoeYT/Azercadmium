using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Underworld
{
	public class HungeringJavelin : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Striking an enemy causes a life-sucking hungry to be shot in the opposite direction");
		}
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 61;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 16;
			item.useTime = 16;
			item.knockBack = 3.5f;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 3);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Underworld.HungeringJavelin>();
			item.shootSpeed = 12f;
		}
	}
}