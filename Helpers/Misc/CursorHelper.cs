using Microsoft.Xna.Framework;
using Terraria;

namespace Azercadmium.Helpers.Misc
{
    public static class CursorHelper
	{
		public static bool IsSmartCursorHovering(int i, int j, out bool isSelected)
        {
			isSelected = Main.SmartInteractTileCoordsSelected.Contains(new Microsoft.Xna.Framework.Point(i, j));
            return Main.hideUI
                ? false
                : Collision.InTileBounds(i, j, Main.TileInteractionLX, Main.TileInteractionLY, Main.TileInteractionHX, Main.TileInteractionHY)
                ? Main.SmartInteractTileCoords.Contains(new Microsoft.Xna.Framework.Point(i, j))
                : false;
        }

        public static Point MouseTileWorld => Main.MouseWorld.ToTileCoordinates();
    }
}