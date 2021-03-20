using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Desert
{
    public class DesertRose : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Rose");
			Tooltip.SetDefault("Rains Desert Sigils down from the sky");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 50;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.8f;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Desert.DesertSigil>();
			item.shootSpeed = 15f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Main.PlaySound(SoundID.Item30);
			int amount = 2 + Main.rand.Next(3);
            float speed = new Vector2(speedX, speedY).Length();
			Vector2 position2 = new Vector2(Main.MouseWorld.X, position.Y - 600);
			Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, position.Y - 600), new Vector2(0, speed), type, (int)(damage * 0.5f), (int)(knockBack * 0.25f), player.whoAmI);
			for (int i = 0; i < amount; i++) {
				for (int j = 0; j < amount / 2; j++) {
					Dust.NewDust(new Vector2(position2.X - 2.5f, position2.Y), 5, 2, ModContent.DustType<Dusts.DesertRoseDust>());
				}
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-1f, 1f), speed);
				Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, position.Y - 600), perturbedSpeed, type, (int)(damage * 0.5f), (int)(knockBack * 0.25f), player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 6);
			recipe.AddIngredient(ItemID.PinkPricklyPear);
			recipe.AddIngredient(ItemID.SandBlock, 30);
			recipe.AddIngredient(ItemID.HardenedSand, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}