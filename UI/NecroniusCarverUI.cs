using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace Azercadmium.UI
{
    public class NecroniusCarverUI
    {
        const float maxWidth = 128 + widthPadding * framePieces * 2;

        public const int max = 50000;

        public const int screenXPadding = 8;

        public const int screenYPadding = 72;

        public const int widthPadding = -2;

        public const int width = 16;

        public const int framePieces = 4;

        public const int fillingFramePieces = 3;

        public int critDamage;

        public bool active;

        public float CritPercentage => critDamage / (float)max;

        public Texture2D texture;

        public void SetDefaults() => texture = ModContent.GetTexture("TestAzercadmium/UI/NecroniusCarverUI");

        public void Update()
        {
        }

        public void Draw()
        {
            if (!active || !Azercadmium.GameWorldRunning || Main.playerInventory)
            {
                return;
            }
            if (critDamage > max)
            {
                critDamage = max;
            }
            for (int i = 0; i < framePieces; i++)
            {
                Main.spriteBatch.Draw(texture, new Vector2(screenXPadding + (width + widthPadding) * i, screenYPadding), new Rectangle(width * 2 * i, 0, width, 32), Color.White);
            }
            for (int i = 0; i < framePieces; i++)
            {
                Main.spriteBatch.Draw(texture, new Vector2(screenXPadding + (width + widthPadding) * (i + framePieces), screenYPadding), new Rectangle(width * 2 * (framePieces - i - 1), 0, width, 32), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
            }
            const float length = maxWidth - 12;
            float pos = length * CritPercentage;
            Main.spriteBatch.Draw(texture, new Vector2(screenXPadding + pos - 2, screenYPadding), new Rectangle(40, 32, 16, 32), new Color(200, 200, 200, 0));
            ChatManager.DrawColorCodedString(Main.spriteBatch, Main.fontMouseText, "Crit Meter [" + critDamage + "/" + max + "]", new Vector2(screenXPadding + (width + widthPadding), screenYPadding + 36), Color.White, 0f, Vector2.Zero, Vector2.One);
        }
    }
}