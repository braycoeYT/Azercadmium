using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Slime
{
	public class Slimeblade : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Melee strikes will make enemies slimy");
		}
		public override void SetDefaults() {
			item.damage = 12;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.6f;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(3, 6) * 60, false);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SlimyCore"), 3);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}