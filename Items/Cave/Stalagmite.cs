using Azercadmium.Buffs.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class Stalagmite : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("On striking enemies, gives the player a temporary defense boost.");
		}
		public override void SetDefaults() {
			item.damage = 32;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 4.5f;
			item.value = 25000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			player.AddBuff(ModContent.BuffType<Hardened>(), 180);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			player.AddBuff(ModContent.BuffType<Hardened>(), 180);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.GraniteBlock, 24);
			recipe.AddRecipeGroup("Azercadmium:AnyPHBar", 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}