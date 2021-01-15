using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Other.Yoyos
{
	public class TripleStriker : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Nice shot!");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 6.5f;
			item.damage = 128;
			item.rare = ItemRarityID.Yellow;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 13, 0, 0);
			item.shoot = ProjectileType<Projectiles.Other.Yoyos.TripleStriker>();
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk, 12);
			recipe.AddIngredient(ItemID.Ectoplasm, 8);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}