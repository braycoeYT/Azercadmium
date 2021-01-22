using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Accessories
{
    public class Inhaler : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Inhaler");
            Tooltip.SetDefault("Grants immunity to Out of Breath");
        }
        public override void SetDefaults() {
            item.width = 34;
            item.height = 34;
            item.rare = 4;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) 
            => player.buffImmune[mod.BuffType("OutOfBreath")] = true;
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.SoulofFlight, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}