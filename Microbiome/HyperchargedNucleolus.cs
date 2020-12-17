using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Microbiome
{
	public class HyperchargedNucleolus : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Constantly rains down navycell debris on enemies\nIncreased life regen after striking an enemy");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 100000;
			item.rare = ItemRarityID.Orange;
			item.expert = true;
		}
		int playerTimer;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.hyperCell = true;
			playerTimer++;
			if (playerTimer % 300 == 0)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 601), player.Center.Y - 600, Main.rand.Next(-3, 4), 5, mod.ProjectileType("GoodND"), 34, 1f, player.whoAmI);
			}
			if (playerTimer % 300 == 100)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 601), player.Center.Y - 600, Main.rand.Next(-3, 4), 5, mod.ProjectileType("GoodND2"), 31, 1f, player.whoAmI);
			}
			if (playerTimer % 300 == 200)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 601), player.Center.Y - 600, Main.rand.Next(-3, 4), 5, mod.ProjectileType("GoodND3"), 28, 1f, player.whoAmI);
			}
		}
	}
}