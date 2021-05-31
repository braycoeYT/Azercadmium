using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Titan
{
	public class TitansEnergizer : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan's Energizer");
			Tooltip.SetDefault("'Somehow does not horribly disfigure worms!'\nDrags nearby non-boss creatures towards the cursor");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 1;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0f;
			item.value = Item.sellPrice(0, 5, 45, 0);
			item.rare = ItemRarityID.Orange;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Titan.TitansEnergizer>();
			item.shootSpeed = 0f;
			item.noMelee = true;
			item.mana = 1;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
	}
}