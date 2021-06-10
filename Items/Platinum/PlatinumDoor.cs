using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Platinum
{
    public class PlatinumDoor : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Platinum Door");
        public override void SetDefaults() => item.DefaultToFurnitureItem(ModContent.TileType<Tiles.Furniture.Doors.DoorClosed>(), 7);
        public override void AddRecipes() => this.AddDoorRecipe(mod, ItemID.PlatinumBar, TileID.Anvils);
    }
}