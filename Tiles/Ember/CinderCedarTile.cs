using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Helpers;
using Azercadmium.Items.Ember;

namespace Azercadmium.Tiles.Ember
{
    public class CinderCedarTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(255, 120, 50));
            dustType = DustID.Fire;
            drop = ModContent.ItemType<CinderCedar>();
        }

        public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
        {
            if (WorldGen.genRand.NextBool(24))
            {
                dustType = DustID.FlameBurst;
            }
        }

        public override bool HasWalkDust() => true;

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (WorldGen.genRand.NextBool(2400))
            {
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Fire);
            }
        }
    }
}