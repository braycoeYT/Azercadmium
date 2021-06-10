using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.ID;

namespace Azercadmium.Items.Tin
{
    public class TinDoor : ModItem
    {
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), DoorID.TinDoorStyle);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.TinBar, TileID.Anvils);
    }
}