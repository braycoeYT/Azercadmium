using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Tiles
{
    public abstract class Vines : ModTile
    {
        public virtual bool DieFromLava() => true;
        public virtual Color MapColor() => new Color(255, 255, 255);

        public override void SetDefaults()
        {
            Main.tileCut[base.Type] = true;
            Main.tileFrameImportant[base.Type] = true;
            Main.tileNoAttach[base.Type] = true;
            Main.tileLavaDeath[base.Type] = DieFromLava();
            AddMapEntry(MapColor());
            disableSmartCursor = false;
            soundType = SoundID.Grass;
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile bottomTile = Framing.GetTileSafely(i, j + 1);
            if (!bottomTile.active())
            {
                if (bottomTile.type != Type)
                {
                    if (!resetFrame && bottomTile.frameY >= 60)
                    {
                        return false;
                    }
                    int type = WorldGen.genRand.Next(6);
                    if (type == 0)
                    {
                        tile.frameX = 0;
                        tile.frameY = 60;
                    }
                    if (type == 1)
                    {
                        tile.frameX = 18;
                        tile.frameY = 60;
                    }
                    if (type == 2)
                    {
                        tile.frameX = 0;
                        tile.frameY = 80;
                    }
                    if (type == 3)
                    {
                        tile.frameX = 18;
                        tile.frameY = 80;
                    }
                    if (type == 4)
                    {
                        tile.frameX = 0;
                        tile.frameY = 100;
                    }
                    if (type == 5)
                    {
                        tile.frameX = 18;
                        tile.frameY = 100;
                    }
                    return false;
                }
            }
            else
            {
                if (bottomTile.type == Type)
                {
                    if (resetFrame)
                    {
                        int type = WorldGen.genRand.Next(6);
                        if (type == 0)
                        {
                            tile.frameX = 0;
                            tile.frameY = 0;
                        }
                        if (type == 1)
                        {
                            tile.frameX = 18;
                            tile.frameY = 0;
                        }
                        if (type == 2)
                        {
                            tile.frameX = 0;
                            tile.frameY = 20;
                        }
                        if (type == 3)
                        {
                            tile.frameX = 18;
                            tile.frameY = 20;
                        }
                        if (type == 4)
                        {
                            tile.frameX = 0;
                            tile.frameY = 40;
                        }
                        if (type == 5)
                        {
                            tile.frameX = 18;
                            tile.frameY = 40;
                        }
                    }
                }
            }
            return false;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Framing.GetTileSafely(i, j + 1).type == Type)
            {
                WorldGen.KillTile(i, j + 1);
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            width = 16;
            offsetY = -2;
            height = 18;
        }
    }
}