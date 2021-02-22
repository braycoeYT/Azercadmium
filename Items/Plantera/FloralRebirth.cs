using Azercadmium.Items.Elemental;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Plantera
{
	public class FloralRebirth : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots an explosive seed and several petals\nTrue melee hits restore health");
		}
		public override void SetDefaults() {
			item.damage = 71;
			item.melee = true;
			item.width = 72;
			item.height = 72;
			item.useTime = 43;
			item.useAnimation = 43;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7.8f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.SeedlerNut;
			item.shootSpeed = 18f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			int rand = Main.rand.Next(1, 4);
			player.statLife += rand;
			player.HealEffect(rand, true);
			target.AddBuff(BuffID.Venom, Main.rand.Next(4, 8));
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit)
		{
			int rand = Main.rand.Next(1, 4);
			player.statLife += rand;
			player.HealEffect(rand, true);
			target.AddBuff(BuffID.Venom, Main.rand.Next(4, 8));
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 5 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				float rand = Main.rand.NextFloat(0.2f, 0.6f);
				Vector2 perturbedSpeed = new Vector2(speedX * rand, speedY * rand).RotatedByRandom(MathHelper.ToRadians(25));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.FlowerPowPetal, (int)(damage * 0.75f), knockBack / 4f, player.whoAmI);
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seedler);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ModContent.ItemType<PlanteraTooth>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ElementalGoop>(), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}