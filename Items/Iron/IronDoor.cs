using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.ID;

namespace Azercadmium.Items.Iron
{
    public class IronDoor : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Alternate Iron Door");
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), DoorID.IronDoorStyle);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.IronBar, TileID.Anvils);
    }
}