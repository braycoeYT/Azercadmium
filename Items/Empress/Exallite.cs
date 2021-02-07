using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class Exallite : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a sticky cluster towards the cursor on swing");
		}
		public override void SetDefaults() {
			item.damage = 78;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.9f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Empress.ExalliteCluster>();
			item.shootSpeed = 12f;
		}
	}
}