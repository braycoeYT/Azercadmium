using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Azercadmium.Helpers;
using Terraria;

namespace Azercadmium.Tiles.Ember
{
    public class EmberVines : Vines
    {
        public override bool DieFromLava() => false;
        public override Color MapColor() => new Color(128, 105, 93);

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            DrawingHelper.TileDraw(Azercadmium.extraTexture[4], i, j, new Rectangle(tile.frameX, tile.frameY, 16, 16), ColorHelper.EmberGladesColor2);
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile bottomTile = Framing.GetTileSafely(i, j + 1);
            if (!bottomTile.active())
            {
                if (WorldGen.genRand.NextBool(10))
                {
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<EmberVines>(), true);
                    bottomTile.color(color: tile.color());
                    WorldGen.TileFrame(i, j, true);
                }
            }
        }
    }
}
