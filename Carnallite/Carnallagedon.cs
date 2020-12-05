using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class Carnallagedon : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("True melee hits inflict venom, and shoots a tile bouncing wave");
		}
		public override void SetDefaults() {
			item.damage = 91;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.7f;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("RedCarnalliteWave");
			item.shootSpeed = 10f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(3, 6) * 60, false);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(3, 6) * 60, false);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Carnallage"));
			recipe.AddIngredient(mod.ItemType("RedCarnalliteBar"), 10);
			recipe.AddTile(TileID.Mythril);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}