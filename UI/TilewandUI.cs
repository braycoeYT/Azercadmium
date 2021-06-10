using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI.Chat;

namespace Azercadmium.UI
{
    public class TilewandUI
    {
        //public static int TileWand => ModContent.ItemType<NalydTilewand>();

        public const int maxModes = 11;

        public const int nonSpecialMaxModes = 10;

        public const int buttonWidth = 16;

        public const int buttonPositionPadding = 4;

        public const int buttonHeight = 16;

        public const int buttonCoordinateXPadding = 2;

        public const int buttonCoordinateYPadding = 2;

        public const int buttonXPadding = 4;

        public const int buttonYPadding = 70;

        public bool[] specialIcon;

        public bool active;

        public bool tempActive;

        public int mode;

        public bool noHoverGlow;

        public int hoverButton;

        public bool pressed;

        public Texture2D buttonTexture;

        public Texture2D buttonTextureHighlight;

        public string[] modeName;

        //public TileWandSaveInfo GetSave() => new TileWandSaveInfo(mode: modeName[mode], hoverGlow: noHoverGlow);

        public void Load(TagCompound tag)
        {
            mode = 0;
            noHoverGlow = false;
            string save;
            try
            {
                save = tag.GetString("tileWandInfo_Mode");
            }
            catch
            {
                save = null;
            }
            if (!string.IsNullOrEmpty(save))
            {
                for (int i = 0; i < maxModes; i++)
                {
                    if (modeName[i] == save)
                    {
                        mode = i;
                        break;
                    }
                }
            }
            noHoverGlow = tag.GetBool("tileWandInfo_HoverGlow");
        }

        public void SetDefaults()
        {
            active = false;
            hoverButton = -1;
            pressed = false;
            buttonTexture = ModContent.GetTexture("TestAzercadmium/UI/TilewandUI_Button");
            buttonTextureHighlight = ModContent.GetTexture("TestAzercadmium/UI/TilewandUI_Button_Highlight");
            modeName = new string[maxModes];
            specialIcon = new bool[maxModes];
            specialIcon[9] = true;
            modeName[0] = "None";
            modeName[1] = "Force Place Tile";
            modeName[2] = "Force Random Update";
            modeName[3] = "Shoot TileRunner";
            modeName[4] = "Chest Place Test";
            modeName[5] = "Grow Hell Tree";
            modeName[6] = "Grow Crystal Tree";
            modeName[7] = "Tile Frame";
            modeName[8] = "Tile Sprite Coordinates";
            modeName[9] = "Toggle Hover Glow";
            modeName[10] = "Grow Tree";
        }

        public void Update()
        {
            if (!active && !tempActive)
            {
                hoverButton = -1;
                pressed = false;
                return;
            }
            tempActive = false;
        }

        public void Draw()
        {
            if (!active && !tempActive || !Azercadmium.GameWorldRunning || Main.playerInventory)
            {
                return;
            }
            int specialnum = 0;
            int specialHoverButton = 0;
            int hoverDrawX = -1;
            bool hoveringOverButton = false;
            for (int i = 0; i < maxModes - 1; i++)
            {
                if (specialIcon[i + 1])
                {
                    Rectangle detect = new Rectangle(buttonXPadding + (buttonWidth + buttonPositionPadding) * (specialHoverButton), buttonYPadding + buttonHeight + buttonPositionPadding, buttonWidth, buttonHeight);
                    Main.spriteBatch.Draw(buttonTexture, detect, new Rectangle(0, (buttonHeight + buttonCoordinateYPadding) * i, buttonWidth, buttonHeight), Color.White);
                    if (detect.Contains(Main.MouseScreen.ToPoint()))
                    {
                        hoverButton = i + 1;
                        specialHoverButton = specialnum;
                        hoveringOverButton = true;
                    }
                    specialnum++;
                }
                else
                {
                    Rectangle detect = new Rectangle(buttonXPadding + (buttonWidth + buttonPositionPadding) * (i - specialnum), buttonYPadding, buttonWidth, buttonHeight);
                    Main.spriteBatch.Draw(buttonTexture, detect, new Rectangle(0, (buttonHeight + buttonCoordinateYPadding) * i, buttonWidth, buttonHeight), Color.White);
                    if (detect.Contains(Main.MouseScreen.ToPoint()))
                    {
                        hoverButton = i + 1;
                        hoverDrawX = detect.X;
                        hoveringOverButton = true;
                    }
                }
            }
            if (!hoveringOverButton)
            {
                hoverButton = -1;
            }
            else
            {
                if (specialIcon[hoverButton])
                {
                    Rectangle detect = new Rectangle(buttonXPadding + (buttonWidth + buttonPositionPadding) * (specialHoverButton), buttonYPadding + buttonHeight + buttonPositionPadding, buttonWidth, buttonHeight);
                    Main.spriteBatch.Draw(buttonTextureHighlight, detect, Color.White);
                    int offsetX = -modeName[hoverButton].Length;
                    if (detect.X + offsetX < 0)
                    {
                        offsetX = 0;
                    }
                    ChatManager.DrawColorCodedString(Main.spriteBatch, Main.fontMouseText, modeName[hoverButton], detect.TopLeft() + new Vector2(offsetX, 20), Color.White, 0f, Vector2.Zero, Vector2.One);
                }
                else
                {
                    Rectangle detect = new Rectangle(hoverDrawX, buttonYPadding, buttonWidth, buttonHeight);
                    Main.spriteBatch.Draw(buttonTextureHighlight, detect, Color.White);
                    int offsetX = -modeName[hoverButton].Length;
                    if (detect.X + offsetX < 0)
                    {
                        offsetX = 0;
                    }
                    ChatManager.DrawColorCodedString(Main.spriteBatch, Main.fontMouseText, modeName[hoverButton], detect.TopLeft() + new Vector2(offsetX, 40), Color.White, 0f, Vector2.Zero, Vector2.One);
                }
                if (Main.mouseLeft)
                {
                    if (!pressed)
                    {
                        if (!specialIcon[hoverButton])
                        {
                            Main.NewText("Mode set to: " + modeName[hoverButton], new Color(255, 255, 10));
                            mode = hoverButton;
                            pressed = true;
                        }
                        else
                        {
                            if (hoverButton == 9)
                            {
                                noHoverGlow = !noHoverGlow;
                                Main.NewText("Toggled [Hover Glow] to " + (!noHoverGlow).ToString().ToLower(), new Color(255, 255, 10));
                            }
                            pressed = true;
                        }
                    }
                }
                else
                {
                    pressed = false;
                }
            }
            if (mode >= 0 && mode < maxModes)
            {
                ChatManager.DrawColorCodedString(Main.spriteBatch, Main.fontMouseText, "Current Mode [" + modeName[mode] + "]", new Vector2(buttonXPadding + (buttonWidth + buttonPositionPadding) * (nonSpecialMaxModes - 1), buttonYPadding), new Color(255, 255, 10), 0f, Vector2.Zero, Vector2.One);
            }
        }
    }
}