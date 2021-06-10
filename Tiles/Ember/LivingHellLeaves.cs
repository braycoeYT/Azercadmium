using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Systems;
using Azercadmium.Aaa;

namespace Azercadmium.Tiles.Ember
{
    public class LivingHellLeaves : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(200, 75, 100));
            dustType = DustID.Fire;
            soundType = SoundID.Grass;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Framing.GetTileSafely(i, j + 1).collisionType <= 0)
            {
                int offset = Main.LocalPlayer.ModPlayer().ZoneEmberGlades ? 75 : 0;
                if (WorldGen.genRand.NextBool(250 - offset))
                {
                    Gore.NewGore(new Vector2(i * 16 + WorldGen.genRand.Next(16), j * 16 + 20), Utils.RandomVector2(WorldGen.genRand, 2, 5), mod.GetGoreSlot("Gores/HellLeaf"));
                }
            }
        }

        /*public override void RandomUpdate(int i, int j)
        {
            Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Fire);
            Tile belowTile = Framing.GetTileSafely(i, j + 1);
            if (!belowTile.active())
            {
                if (WorldGen.genRand.NextBool(75) && Azercadmium.DownedAllMechBosses)
                {
                    Vector2 worldPos = new Vector2(i * 16, (j + 1) * 16);
                    for (int k = 0; k < 30; k++)
                    {
                        Dust.NewDust(worldPos, 16, 16, DustID.Fire);
                    }
                    for (int k = 0; k < 5; k++)
                    {
                        Dust.NewDust(worldPos, 16, 16, DustID.FlameBurst);
                    }
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<BruiseAppleTile>(), true, false);
                    Main.PlaySound(SoundID.Grass, worldPos);
                }
            }
        }*/
    }
}
