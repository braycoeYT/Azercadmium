using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Silver
{
    public class SilverDoor : ModItem
    {
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), 4);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.SilverBar, TileID.Anvils);
    }
}