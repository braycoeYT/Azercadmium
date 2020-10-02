using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Mushroom
{
	public class ShroomTome : ModItem
	{
		public override void SetDefaults()  {
			item.value = Item.sellPrice(0, 0, 36, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 19;
			item.useTime = 19;
			item.damage = 10;
			item.width = 38;
			item.height = 36;
			item.knockBack = 4.1f;
			item.shoot = mod.ProjectileType("MushroomBolt");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Blue;
			item.mana = 3;
			item.UseSound = SoundID.Item43;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 19);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}