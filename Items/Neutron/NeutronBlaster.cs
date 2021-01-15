using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Neutron
{
	public class NeutronBlaster : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Neutron Blaster");
			Tooltip.SetDefault("Shoots multiple short ranged Neutron Blasts that chase your enemies");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 6;
			item.useTime = 6;
			item.damage = 68;
			item.width = 58;
			item.height = 28;
			item.knockBack = 0.4f;
			item.shoot = mod.ProjectileType("NeutronBlast");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.UseSound = SoundID.Item93;
			item.autoReuse = true;
			item.rare = ItemRarityID.Red;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NeutronFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}