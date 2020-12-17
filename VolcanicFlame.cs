using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Underworld
{
	public class VolcanicFlame : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts down a psychokinetic flame wall");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 34;
			item.useTime = 34;
			item.damage = 19;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.1f;
			item.shoot = mod.ProjectileType("PKFire1");
			item.shootSpeed = 16f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Orange;
			item.mana = 14;
			item.UseSound = SoundID.Item116;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}