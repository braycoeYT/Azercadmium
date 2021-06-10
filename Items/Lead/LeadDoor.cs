using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.ID;

namespace Azercadmium.Items.Lead
{
    public class LeadDoor : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Alternate Lead Door");
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), DoorID.LeadDoorStyle);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.LeadBar, TileID.Anvils);
    }
}