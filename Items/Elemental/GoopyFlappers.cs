using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Elemental
{
	[AutoloadEquip(EquipType.Wings)]
	public class GoopyFlappers : ModItem
	{
		/*public override bool Autoload(ref string name)
		{
			return !ModContent.GetInstance<ExampleConfigServer>().DisableExampleWings;
		}*/
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Very very very very goopy, and somehow still can allow for flight and immunity to fall damage");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(0, 0, 8, 0);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 170;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.75f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.125f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 1f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ElementalGoop>(), 150);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}