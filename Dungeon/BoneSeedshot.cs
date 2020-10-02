using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Dungeon
{
	public class BoneSeedshot : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nHas a lot of knockback");
        }
		public override void SetDefaults() {
			item.damage = 8; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 3.5f; //0
			item.value = Item.sellPrice(0, 0, 0, 2);
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.BoneSeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}