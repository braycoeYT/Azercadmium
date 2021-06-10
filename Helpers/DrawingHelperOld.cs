/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Helpers
{
    public static class DrawingHelper
    {
        public static SpriteEffects DirectionToSpriteEffects(int direction) => direction < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        public static void WorldDraw(this SpriteBatch spriteBatch, string texture, Vector2 worldCoordinates, Rectangle? frame, Color color, float rotation = 0f, Vector2? origin = null, float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Point maxFrames = default(Point), Point frameNumber = default(Point)) => spriteBatch.WorldDraw(ModContent.GetTexture(texture), worldCoordinates, frame, color, rotation, origin, scale, effects, layerDepth, maxFrames, frameNumber);

        public static void WorldDraw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 worldCoordinates, Rectangle? frame, Color color, float rotation = 0f, Vector2? origin = null, float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Point maxFrames = default(Point), Point frameNumber = default(Point))
        {
            Point defaultPoint = default(Point);
            if (maxFrames.X == defaultPoint.X)
                maxFrames.X = 1;
            if (maxFrames.Y == defaultPoint.Y)
                maxFrames.Y = 1;
            if (frameNumber.X == defaultPoint.X)
                frameNumber.X = 1;
            if (frameNumber.Y == defaultPoint.Y)
                frameNumber.Y = 1;

            if (frame == null && maxFrames.X > 1 && maxFrames.Y > 1)
            {
                int frameWidth = texture.Width / maxFrames.X;
                int frameHeight = texture.Height / maxFrames.Y;

                frame = new Rectangle(frameWidth * frameNumber.X, frameWidth * frameNumber.Y, frameWidth, frameHeight);
                if (origin == null)
                    origin = ((Rectangle)frame).Size() * 0.5f;
            }
            else if (origin == null)
            {
                origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            }

            spriteBatch.Draw(texture, worldCoordinates - Main.screenPosition, frame, color, rotation, (Vector2)origin, scale, effects, layerDepth);
        }

        public static void TileDraw(Texture2D texture, int i, int j, Rectangle? frame, Color color, float rotation = 0f, Vector2 origin = default(Vector2), float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Vector2 offset = default(Vector2))
        { 
            Tile tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
            int height = tile.frameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero + offset, frame, color, rotation, origin, scale, effects, layerDepth);
        }

        public static void NPCAfterImageEffect(this NPC npc, Color? color = null, Rectangle? frame = null, float fadeMult = 0.9f)
        {
            color = color == null ? Lighting.GetColor(npc.Center.ToTileCoordinates().X, npc.Center.ToTileCoordinates().Y) : color;
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Rectangle _frame = frame == null ? npc.frame : (Rectangle)frame;
            Main.spriteBatch.Draw(Main.npcTexture[npc.type], npc.position + new Vector2(npc.width * 0.5f, npc.height * 0.5f + 2) - Main.screenPosition, _frame, (Color)color, npc.rotation, _frame.Size() * 0.5f, npc.scale, effects, 0f);
            for (int i = 0; i < npc.oldPos.Length; i++)
            {
                color *= fadeMult;
                Main.spriteBatch.Draw(Main.npcTexture[npc.type], npc.oldPos[i] + new Vector2(npc.width * 0.5f, npc.height * 0.5f + 2) - Main.screenPosition, _frame, (Color)color, npc.rotation, _frame.Size() * 0.5f, npc.scale, effects, 0f);
            }
            if (!Main.gameInactive && !Main.gameMenu && !Main.gamePaused)
                NPCHelper.UpdateOldPos(npc);
        }
    }
}*/