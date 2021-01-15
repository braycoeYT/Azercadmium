using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Aquite
{
	public class AquiteThrow : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 4.9f;
			item.damage = 124;
			item.rare = ItemRarityID.Cyan;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.shoot = ProjectileType<Projectiles.Aquite.AquiteThrow>();
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("AquiteBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}