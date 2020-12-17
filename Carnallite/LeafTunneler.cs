using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class LeafTunneler : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots poisonous leaves");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 15;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1.9f;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GreenCarnalliteLeaf");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 6;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GreenCarnalliteBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}