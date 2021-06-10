using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Tiles.Ember
{
    public class EmberGrass : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Ash;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[Type][TileID.Ash] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlendAll[Type] = true;
            AddMapEntry(new Color(255, 120, 50));
            dustType = DustID.Fire;
            drop = ItemID.AshBlock;
        }

        public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
        {
            if (WorldGen.genRand.NextBool(8))
            {
                dustType = DustID.FlameBurst;
            }
        }

        public override bool HasWalkDust() => true;

        public override bool CanPlace(int i, int j) => false;

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            Framing.GetTileSafely(i, j).ResetToType(TileID.Ash);
            WorldGen.TileFrame(i, j);
            return false;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Vector3 orange = Color.Orange.ToVector3() * 0.5f;
            r = orange.X;
            g = orange.Y;
            b = orange.Z;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (WorldGen.genRand.NextBool(120) && !Framing.GetTileSafely(i, j - 1).active())
            {
                Dust.NewDust(new Vector2(i * 16, j * 16 - 8), 16, 4, 270, WorldGen.genRand.Next(-1, 1));
                if (WorldGen.genRand.NextBool(20))
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16 - 8), 16, 4, 270, WorldGen.genRand.Next(-1, 1));
                }
            }
            if (WorldGen.genRand.NextBool(80))
            {
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Fire);
            }
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile bottomTile = Framing.GetTileSafely(i, j + 1);
            if (!bottomTile.active())
            {
                if (WorldGen.genRand.NextBool(10))
                {
                    if (WorldGen.genRand.NextBool())
                    {
                        WorldGen.PlaceTile(i, j + 1, ModContent.TileType<AshVines>(), true);
                    }
                    else
                    {
                        WorldGen.PlaceTile(i, j + 1, ModContent.TileType<EmberVines>(), true);
                    }
                }
            }
        }
    }
}