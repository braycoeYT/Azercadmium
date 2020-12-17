using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items
{
	public class PetriDish : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Very Suspicious and Retro Looking Petri Dish");
			Tooltip.SetDefault("Contains 1.2 hectograms of slime food.\nThis dish is very mobile.\nSummons Braycoe's favorite slime");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Pets.BraycoeSlime>();
			item.buffType = BuffType<Buffs.Pets.BraycoeSlimeBuff>();
			item.mana = 0;
			item.damage = 0;
			item.value = 40000;
			item.rare = ItemRarityID.Lime;
			item.width = 56;
			item.height = 28;
		}
		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 600, true);
			}
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ElementalGel"), 100);
			recipe.AddIngredient(mod.ItemType("BraycoeSludge"), 30);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"), 10);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}