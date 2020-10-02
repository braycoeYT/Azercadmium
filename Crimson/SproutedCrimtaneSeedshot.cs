using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Crimson
{
	public class SproutedCrimtaneSeedshot : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nEach seed grows crimson deathweed on contact\nWhile in the crimson, each deathweed shoots crimson heart shards in the air");
        }
		public override void SetDefaults() {
			item.damage = 7; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = Item.sellPrice(0, 0, 0, 2); //0
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Crimson.SproutedCrimtaneSeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void UpdateInventory(Player player) {
			if (player.ZoneCorrupt)
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Crimson.SproutedCrimtaneSeedshotGood>();
			else
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Crimson.SproutedCrimtaneSeedshot>();
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CrimtaneSeedshot"), 200);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.DeathweedSeeds);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 200);
			recipe.AddRecipe();
		}
	}
}