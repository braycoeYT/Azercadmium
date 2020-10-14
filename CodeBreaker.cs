using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.CVirus
{
	public class CodeBreaker : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Damaged enemies have a chance to glitch out");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8)); //first is speed, second is amount of frames
		}
		public override void SetDefaults() {
			item.damage = 71;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.2f;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item93;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(mod.BuffType("BrokenCode"), 60 * Main.rand.Next(4, 11), false);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("BrokenCode"), 60 * Main.rand.Next(4, 11), false);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(mod.ItemType("SoulofByte"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}