using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class CinderCedarDoor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cinder Cedar Door");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodenDoor);
            item.createTile = ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>();
            item.placeStyle = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CinderCedar>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}