using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Eclipse
{
	public class AncientMedievalJavelance : ModItem
	{
		public override void SetStaticDefaults()  {
			Tooltip.SetDefault("Not much use due to its age, but could be used for empowering other javelances\nStacks up to 5\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}
		public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 48;
			item.height = 54;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.3f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("AncientMedievalJavelance");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 5;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player) {
			item.useTime = 50 + (item.stack * 10) - 10;
			item.useAnimation = 50 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (p.redJavelance)
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			float numberProjectiles = item.stack;
			float rotation = MathHelper.ToRadians(18);
			if (numberProjectiles > 1) {
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return false;
			}
			return true;
		}
	}
}