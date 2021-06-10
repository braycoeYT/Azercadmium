using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace Azercadmium.Aaa
{
    public static class TAZUtils
    {
        public static void TileDraw(Texture2D texture, int i, int j, Rectangle? frame, Color color, float rotation = 0f, Vector2 origin = default(Vector2), float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Vector2 offset = default(Vector2))
        {
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero + offset, frame, color, rotation, origin, scale, effects, layerDepth);
        }

        public static void BeginShaderDrawing(this SpriteBatch spriteBatch, int type = 0)
        {
            switch (type)
            {
                case 0:
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);
                break;
                case 1:
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                break;
            }
        }

        public static void EndShaderDrawing(this SpriteBatch spriteBatch, int type = 0)
        {
            switch (type)
            {
                case 0:
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);
                break;
                case 1:
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
                break;
            }
        }

        public static void Sync(this Projectile projectile)
        {
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, projectile.whoAmI);
        }

        public static Projectile[] FindProjectiles(int type)
        {
            List<Projectile> list = new List<Projectile>();
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile1 = Main.projectile[i];
                if (projectile1.active && projectile1.type == type)
                {
                    list.Add(projectile1);
                }
            }
            return list.ToArray();
        }

        public static void ClearProjectiles(int type = -1)
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active)
                {
                    if (type == -1)
                    {
                        projectile.Kill();
                    }
                    else if (projectile.type == type)
                    {
                        projectile.Kill();
                    }
                }
            }
        }

        public static void LimitOwnedProjectiles(int type, int owner, int amount)
        {
            int count = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.type == type && projectile.owner == owner)
                {
                    count++;
                }
                if (count > amount)
                {
                    projectile.Kill();
                }
            }
        }
        public static void Split(this Projectile projectile, int amount, float maxRot, float damageMult)
        {
            if (amount % 2 != 0)
            {
                amount--;
            }
            Projectile split;

            double spread = maxRot / amount;
            for (int i = 0; i < amount / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = (j == 0) ? 1 : -1;
                    split = Main.projectile[Projectile.NewProjectile(projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, (int)(projectile.damage * damageMult), projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1])];

                    if (split != null)
                    {
                        split.friendly = projectile.friendly;
                        split.hostile = projectile.hostile;
                        split.timeLeft = projectile.timeLeft;
                    }
                }
            }
        }

        public static void ExpandHitbox(this Projectile projectile, int width, int height)
        {
            projectile.position = projectile.Center;
            projectile.width = width;
            projectile.height = height;
            projectile.position -= projectile.Size * 0.5f;
        }

        public static void ClampDistance(ref Vector2 start, ref Vector2 end, float maxDistance)
        {
            if (Vector2.Distance(end, start) > maxDistance)
            {
                end = start + Vector2.Normalize(end - start) * maxDistance;
            }
        }

        public static Color LerpColors(Color[] colors, float f)
        {
            int index = (int)(f * colors.Length % colors.Length);
            return Color.Lerp(colors[index], colors[(index + 1) % (colors.Length - 1)], f * colors.Length % 1f);
        }

        public static Vector2 GetScaleTo(this Texture2D texture, Texture2D texture2)
        {
            float xScale = texture2.Width / texture.Width;
            float yScale = texture2.Height / texture.Height;
            return new Vector2(xScale, yScale);
        }

        public static Vector2 GetScaleTo(this Texture2D texture, int width, int height)
        {
            float xScale = width / texture.Width;
            float yScale = height / texture.Height;
            return new Vector2(xScale, yScale);
        }

        public const float OneOver18 = 0.055555555f;

        public const float OneOver255 = 0.003921568f;

        /// <summary>
        /// Creates a circle of dust
        /// </summary>
        /// <param name="position">The center of the circle</param>
        /// <param name="type">The type of dust to create</param>
        /// <param name="amount">The amount of dust to create</param>
        /// <param name="velocity">the amount it spins in order to create the circle. Set to higher values depending on the amount of dust emited in order to create more of a circle</param>
        public static void DustCircle(Vector2 position, int type, int amount, float velocity)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector2 speed = Vector2.UnitY * velocity;
                speed = speed.RotatedBy(MathHelper.Pi * 2 / amount * i);
                Dust.NewDust(position, 0, 0, type, speed.X, speed.Y, 0, Color.White, 1);
            }
        }

        public static void FixMinionPos(this Projectile projectile, float force = 0.05f)
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile proj = Main.projectile[i];
                if (!proj.active || proj.owner != projectile.owner || !proj.minion || i == projectile.whoAmI || proj.type != projectile.type)
                    // checks if its not active, or owner isnt same, or isnt a minion, or its me, or its not same as me
                    continue;
                float num2 = Math.Abs(projectile.position.X - proj.position.X) + Math.Abs(projectile.position.Y - proj.position.Y);
                // distance between the 2?
                if (num2 < projectile.width) // if it collides/is close
                {
                    if (projectile.position.X < proj.position.X)
                        projectile.velocity.X -= force;
                    else
                    {
                        projectile.velocity.X += force;
                    }
                    if (projectile.position.Y < proj.position.Y)
                        projectile.velocity.Y -= force;
                    else
                    {
                        projectile.velocity.Y += force;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="maxDistance"></param>
        public static void ClampTo(this Vector2 start, Vector2 end, float maxDistance)
		{
			if (Vector2.Distance(end, start) > maxDistance)
			{
				end = start + Vector2.Normalize(end - start) * maxDistance;
			}
		}

        public static void MoveTowards(this Projectile projectile, Vector2 position, Vector2 speed, float maxSpeed)
        {
            if (projectile.Center.X > position.X)
                projectile.velocity.X -= speed.X;
            else
            {
                projectile.velocity.X += speed.X;
            }
            if (projectile.Center.Y < position.Y)
                projectile.velocity.Y += speed.Y;
            else
            {
                projectile.velocity.Y -= speed.Y;
            }
            if (projectile.velocity.Length() > maxSpeed)
                projectile.velocity = Vector2.Normalize(projectile.velocity) * maxSpeed;
        }

        public static void RotateTowards(this Projectile projectile, Vector2 pos, float speed, bool velocity = false)
        {
            if (!velocity)
                projectile.rotation = projectile.rotation.AngleTowards((projectile.Center - pos).ToRotation(), speed);
            else
            {
                projectile.velocity = projectile.velocity.ToRotation().AngleTowards((projectile.Center - pos).ToRotation(), speed).ToRotationVector2() * projectile.velocity.Length();
            }
        }

        public static Color LerpAll(Color[] colors, float value)
        {
            int length = colors.Length;
            float increase = 1f / length;
            int index = (int)(value / increase);
            return index != length
                ? Color.Lerp(colors[index], colors[index + 1], value * length)
                : Color.Lerp(colors[index], colors[0], value * length);
        }

        public static void DrawChain(this SpriteBatch spriteBatch, Vector2 pos1, Vector2 pos2, Texture2D texture)
        {
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float height = texture.Height;
            Vector2 vector1 = pos1 - pos2;
            float rotation = (float)Math.Atan2(vector1.Y, vector1.X) - 1.57f;
            bool draw = true;
            if (float.IsNaN(pos2.X) && float.IsNaN(pos2.Y))
                draw = false;
            if (float.IsNaN(vector1.X) && float.IsNaN(vector1.Y))
                draw = false;
            while (draw)
                if (vector1.Length() < height + 1.0)
                    draw = false;
                else
                {
                    Vector2 vector2 = vector1;
                    vector2.Normalize();
                    pos2 += vector2 * height;
                    vector1 = pos1 - pos2;
                    Main.spriteBatch.Draw(texture, pos2 - Main.screenPosition, sourceRectangle, Color.White, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
        }

        public static Vector2 RaycastNear(this Vector2 pos)
        {
            Tile tile = Framing.GetTileSafely(pos);
            Tile under = Framing.GetTileSafely((pos + Vector2.UnitY).ToTileCoordinates());
            Tile over = Framing.GetTileSafely((pos - Vector2.UnitY).ToTileCoordinates());
            Vector2 near1 = pos;
            Vector2 near2 = pos;
            while (!over.active() || tile.active())
            {
                near1.Y -= 1;
                over = Framing.GetTileSafely(near1.ToTileCoordinates());
            }
            while (!under.active() || tile.active()) // while under tile inactive or down tile active
            {
                near2.Y += 1;
                under = Framing.GetTileSafely(near2.ToTileCoordinates());
            }
            float dist1 = Vector2.Distance(pos, near1);
            float dist2 = Vector2.Distance(pos, near2);
            if (dist1 > dist2)
                return near2;
            return near1;
        }

    }
}