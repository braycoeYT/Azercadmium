using Azercadmium.Buffs.Debuffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
	public class CinderCedarSword : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cinder Cedar Sword");
			Tooltip.SetDefault(""); 
		}
		public override void SetDefaults() {
			item.damage = 62; 
			item.melee = true;
			item.width = 40; 
			item.height = 40; 
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 6; 
			item.value = Item.buyPrice(gold: 1);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true; 
			item.crit = 6;
			item.useStyle = ItemUseStyleID.SwingThrow; 
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(ModContent.BuffType<Charred>(), 200);
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ItemID.HallowedBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
			recipe.AddIngredient(ModContent.ItemType<Darkron.DarkronBar>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}