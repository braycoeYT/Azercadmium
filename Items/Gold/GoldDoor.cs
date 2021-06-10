using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Gold
{
    public class GoldDoor : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Alternate Gold Door");
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), 6);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.GoldBar, TileID.Anvils);
    }
}