using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Underworld
{
	public class PhoenixDriver : ModItem
	{
		public override void SetDefaults() {
			item.damage = 29;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0.5f;
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.rare = ItemRarityID.Green;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = ProjectileID.ImpFireball;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 8;
			item.stack = 1;
			item.UseSound = SoundID.Item12;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}