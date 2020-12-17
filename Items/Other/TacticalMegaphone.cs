using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other
{
	public class TacticalMegaphone : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Unethically tactical, for your pleasure.");
		}
		public override void SetDefaults() {
			item.damage = 51;
			item.magic = true;
			item.width = 30;
			item.height = 36;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3.4f;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Megawave");
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.mana = 11;
			item.UseSound = SoundID.Item47;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(8, -4);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Megaphone);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}