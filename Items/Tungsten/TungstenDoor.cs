using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Tungsten
{
    public class TungstenDoor : ModItem
    {
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), 5);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.TungstenBar, TileID.Anvils);
    }
}