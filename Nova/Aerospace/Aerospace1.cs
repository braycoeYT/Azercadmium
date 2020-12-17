using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Nova.Aerospace
{
	public class Aerospace1 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Aerospace I");
			Tooltip.SetDefault("Every second swing launches a small orb");
		}
		public override void SetDefaults() {
			item.damage = 22;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.8f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("AerospaceSparkSmall");
			item.shootSpeed = 10f;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, mod.DustType("AerospaceDust"));
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int shootCount;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootCount++;
            return shootCount % 2 == 0;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MysteriousNova"));
			recipe.AddIngredient(mod.ItemType("DriedEssence"));
			recipe.AddIngredient(mod.ItemType("GlazedLens"));
			recipe.AddIngredient(mod.ItemType("SlimyCore"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}