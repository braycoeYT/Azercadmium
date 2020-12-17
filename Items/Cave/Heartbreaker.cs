using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class Heartbreaker : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Heartbreaker");
			Tooltip.SetDefault("All true melee attacks leech life\nShoots life crystals");
		}
		public override void SetDefaults() {
			item.damage = 24;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.8f;
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("HeartbreakerProjectile");
			item.shootSpeed = 12f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (target.type != NPCID.TargetDummy) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			player.statLife += 1;
			player.HealEffect(1, true);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBroadsword);
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBroadsword);
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}