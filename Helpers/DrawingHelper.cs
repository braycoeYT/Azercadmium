using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Helpers
{
    public static class DrawingHelper
    {
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
        }
    }
}