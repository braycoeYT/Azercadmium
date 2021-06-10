using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Projectiles.Ember
{
    public class EmberGlobberProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Ember Globber");

        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 15;
            projectile.friendly = true;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            projectile.velocity.Y += 0.06f + MathHelper.Clamp(projectile.velocity.X * 0.01f, 0, 0.1f);
            projectile.rotation += projectile.velocity.X * 0.0314f + projectile.velocity.Y * 0.0314f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.NPCHit13, projectile.position);
            Point tilePosition = projectile.Center.ToTileCoordinates();
            const int size = 5;
            const int difference = 5 / 2;
            Rectangle effectRectangle = new Rectangle(tilePosition.X - difference, tilePosition.Y - difference, size * 16, size * 16);
            for (int k = 0; k < 40; k++)
            {
                Dust.NewDust(new Vector2(effectRectangle.X * 16, effectRectangle.Y * 16), size * 16, size * 16, DustID.Fire);
            }
            for (int k = 0; k < 20; k++)
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Fire);
            }
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.FlameBurst);
            }
            for (int i = effectRectangle.X; i < effectRectangle.X + size; i++)
            {
                for (int j = effectRectangle.Y; j < effectRectangle.Y + size; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    int oldType = tile.type;
                    bool changed = false;
                    ushort emberGrassTile = (ushort)ModContent.TileType<EmberGrass>();
                    ushort[] toEmberGrass =
                    {
                        TileID.Grass,
                        TileID.CorruptGrass,
                        TileID.FleshGrass,
                        TileID.JungleGrass,
                        TileID.HallowedGrass,
                        TileID.MushroomGrass,
                    };
                    for (int k = 0; k < toEmberGrass.Length; k++)
                    {
                        if (tile.active() && tile.type == toEmberGrass[k])
                        {
                            tile.ResetToType(emberGrassTile);
                            WorldGen.TileFrame(i, j);
                            changed = true;
                        }
                    }
                    if (!changed)
                    {
                        ushort[] toAsh =
                        {
                            TileID.Dirt,
                            TileID.ClayBlock,
                            TileID.Sand,
                            TileID.Ebonsand,
                            TileID.Crimsand,
                            TileID.Pearlsand,
                        };
                        for (int k = 0; k < toAsh.Length; k++)
                        {
                            if (tile.active() && tile.type == toAsh[k])
                            {
                                tile.ResetToType(TileID.Ash);
                                WorldGen.TileFrame(i, j);
                                changed = true;
                            }
                        }
                    }
                    if (!changed)
                    {
                        ushort[] toHellstone =
                        {
                            TileID.Stone,
                            TileID.Ebonstone,
                            TileID.Crimstone,
                            TileID.Pearlstone,
                            TileID.Copper,
                            TileID.Tin,
                            TileID.Iron,
                            TileID.Lead,
                        };
                        for (int k = 0; k < toHellstone.Length; k++)
                        {
                            if (tile.active() && tile.type == toHellstone[k])
                            {
                                tile.ResetToType(TileID.Hellstone);
                                WorldGen.TileFrame(i, j);
                                changed = true;
                            }
                        }
                    }
                    if (changed && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, i, j, 0f, 0, 0, 0);
                    }
                    Tile aboveTile = Framing.GetTileSafely(i, j - 1);
                    if (aboveTile.active())
                    {
                        if (aboveTile.type == TileID.Trees)
                        {
                            WorldGen.CheckTree(i, j - 1);
                        }
                    }
                    if (tile.active())
                    {
                        WorldGen.TileFrame(i, j, true);
                    }
                }
            }
            projectile.active = false;
            return false;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;
    }
}