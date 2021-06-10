using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Aaa;
using Azercadmium.Helpers;

namespace Azercadmium.Tiles.Ember
{
    public class EmberThornTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileCut[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(Color.Orange);
            dustType = DustID.Fire;
            soundType = SoundID.Grass;
        }

        public override void PostSetDefaults()
        {
            Azercadmium.ThornInfo.Add(new ThornInfo(35, Type, delegate (Player player, int i, int j, int damage)
            {
                if (player.GetModPlayer<TAZPlayer>().overwrathMask)
                {
                    return;
                }
                float mult = 1;
                if (!Framing.GetTileSafely(i, j).lava())
                {
                    WorldGen.KillTile(i, j);
                    if (Main.hardMode)
                    {
                        mult += 1;
                    }
                    if (NPC.downedMechBossAny)
                    {
                        mult += 0.125f;
                    }
                    if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                    {
                        mult += 0.125f;
                    }
                    if (Main.expertMode)
                    {
                        mult += 0.5f;
                    }
                }
                else
                {
                    mult += 2;
                }
                damage = (int)(damage * mult);
                player.Hurt(new PlayerDeathReason() { SourceCustomReason = player.name + " was poked to death" }, Azercadmium.DamageRange(damage), 0);
            }));
        }

        public override bool Dangersense(int i, int j, Player player) => true;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Vector3 orange = Color.Orange.ToVector3() * 0.2f;
            r = orange.X;
            g = orange.Y;
            b = orange.Z;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Azercadmium.DrawTile(Azercadmium.extraTexture[2], i, j, new Rectangle(tile.frameX, tile.frameY, 18, 18), Azercadmium.EmberGladesPulseColor);
        }

        public override void RandomUpdate(int i, int j)
        {
            Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Fire);
            TAZWorld.GrowThorn(i, j);
        }
    }
}