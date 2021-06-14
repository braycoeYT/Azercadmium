using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteAxe : ModItem
	{
		public override void SetDefaults() {
			item.damage = 76;
			item.melee = true;
			item.width = 52;
			item.height = 42;
			item.useTime = 7;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.5f;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.axe = 32;
			item.tileBoost = 4;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3))
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.Kinoite.KinoiteDust>());
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<KinoiteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}