using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.ID;

namespace Azercadmium.Items.Copper
{
    public class CopperDoor : ModItem
    {
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), DoorID.CopperDoorStyle);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.CopperBar, TileID.Anvils);
    }
}