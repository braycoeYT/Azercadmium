using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Aquite
{
	public class AquiteSaber : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a bubble towards the cursor on swing");
		}
		public override void SetDefaults() {
			item.damage = 131;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.9f;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.FlaironBubble;
			item.shootSpeed = 20f;
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