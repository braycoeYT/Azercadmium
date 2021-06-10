using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Tiles.Ember
{
    public class AshVines : Vines
    {
        public override bool DieFromLava() => false;
        public override Color MapColor() => new Color(98, 84, 80);

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile bottomTile = Framing.GetTileSafely(i, j + 1);
            if (!bottomTile.active())
            {
                if (WorldGen.genRand.NextBool(10))
                {
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<AshVines>(), true);
                    bottomTile.color(color: tile.color());
                }
            }
        }
    }
}