using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Iron
{
	public class IronYoyo : ModItem
	{
		public override void SetStaticDefaults() {
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
			item.knockBack = 2.8f;
			item.damage = 10;
			item.rare = ItemRarityID.White;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 0, 3, 60);
			item.shoot = ProjectileType<Projectiles.Iron.IronYoyo>();
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}