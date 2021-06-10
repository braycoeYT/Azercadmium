using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Tiles.Ember
{
    public class HellPlants : Plants
    {
        public override int[] TileAnchors => new int[] { TileID.Ash, ModContent.TileType<EmberGrass>(), TileID.Hellstone, TileID.Obsidian };
        public override Color MapColor => new Color(193, 43, 43);
        public override bool LavaDeath => true;
        public override bool WaterDeath => false;
        public override LiquidPlacement LavaPlacement => LiquidPlacement.Allowed;
        public override LiquidPlacement WaterPlacement => LiquidPlacement.NotAllowed;
        public override int StyleRange => 11;

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            for (int k = 0; k < num / 2; k++)
            {
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 24);
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Fire);
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

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Azercadmium.DrawTile(Azercadmium.extraTexture[21], i, j, new Rectangle(tile.frameX, tile.frameY, 16, 18), Azercadmium.EmberGladesPulseColor);
        }
    }
}