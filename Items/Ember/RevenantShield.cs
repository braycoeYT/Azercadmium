using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    [AutoloadEquip(EquipType.Shield)]
    public class RevenantShield : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Revenant Shield");
            Tooltip.SetDefault("Prevents On Fire");
        }
        public override void SetDefaults() {
            item.width = 40;
            item.height = 40;
            item.accessory = true;
            item.defense = 2;
            item.SetShopValues(7, Item.sellPrice(gold: 20));
        }
        public override void UpdateEquip(Player player) {
            player.buffImmune[BuffID.OnFire] = true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CinderCedar>(), 30);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ModContent.ItemType<BurntStinger>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SparkingBatFoot>(), 3);
            recipe.AddIngredient(ModContent.ItemType<FlareSerpentScale>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}