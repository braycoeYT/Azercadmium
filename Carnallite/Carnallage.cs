using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class Carnallage : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("True melee hits inflict poison, and shoots a tile bouncing wave");
		}
		public override void SetDefaults() {
			item.damage = 19;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.1f;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GreenCarnalliteWave");
			item.shootSpeed = 10f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(BuffID.Poisoned, Main.rand.Next(3, 6) * 60, false);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Poisoned, Main.rand.Next(3, 6) * 60, false);
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