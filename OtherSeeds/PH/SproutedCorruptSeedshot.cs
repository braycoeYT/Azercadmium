using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.OtherSeeds.PH
{
	public class SproutedCorruptSeedshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Corrupt Seedshot");
			Tooltip.SetDefault("For use with blowpipes\nEach seed grows corrupt deathweed on contact\nWhile in the corruption, each deathweed shoots corrupt orb shards in the air");
        }
		public override void SetDefaults()
		{
			item.damage = 7; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = 10; //0
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Corruption.SproutedCorruptSeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void UpdateInventory(Player player)
		{
			if (player.ZoneCorrupt)
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Corruption.SproutedCorruptSeedshotGood>();
			else
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Corruption.SproutedCorruptSeedshot>();
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CorruptSeedshot"), 200);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.DeathweedSeeds);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 200);
			recipe.AddRecipe();
		}
	}
}