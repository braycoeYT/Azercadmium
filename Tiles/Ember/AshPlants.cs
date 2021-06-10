using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Tiles.Ember
{
    public class AshPlants : Plants
    {
        public override int[] TileAnchors => new int[] { TileID.Ash, ModContent.TileType<EmberGrass>(), };
        public override Color MapColor => new Color(128, 105, 93);
        public override bool WaterDeath => true;
        public override bool LavaDeath => false;
        public override LiquidPlacement WaterPlacement => LiquidPlacement.NotAllowed;
        public override LiquidPlacement LavaPlacement => LiquidPlacement.Allowed;
        public override int StyleRange => Azercadmium.ashGrassMaxStyles;
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 24);
            }
            num = 0;
            return;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Rectangle growRange = new Rectangle(i - 1, j - 1, 3, 3);
            if (WorldGen.genRand.NextBool(20))
            {
                for (int k = growRange.X; k < growRange.X + growRange.Width; k++)
                {
                    for (int l = growRange.Y; l < growRange.Y + growRange.Height; l++)
                    {
                        if (!Framing.GetTileSafely(k, l).active() && Framing.GetTileSafely(k, l + 1).active())
                        {
                            for (int m = 0; m < TileAnchors.Length; m++)
                            {
                                if (Framing.GetTileSafely(k, l + 1).type == TileAnchors[m])
                                {
                                    Tile tile2 = Framing.GetTileSafely(k, l);
                                    tile2.ClearTile();
                                    tile2.active(active: true);
                                    tile2.color(color: Framing.GetTileSafely(k, l + 1).color());
                                    tile2.type = Type;
                                    tile2.frameY = tile.frameY;
                                    int stylesMax = 1;
                                    if (tile2.frameY == 0)
                                    {
                                        stylesMax = 11;
                                    }
                                    if (tile2.frameY == 20)
                                    {
                                        stylesMax = 7;
                                    }
                                    if (stylesMax > 0)
                                    {
                                        tile2.frameX = (short)(WorldGen.genRand.Next(stylesMax) * 18);
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}