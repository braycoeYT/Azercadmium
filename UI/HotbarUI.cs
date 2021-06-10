using Azercadmium.Aaa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.UI.Chat;

namespace Azercadmium.UI
{
    public class HotbarUI
    {
        public static List<HotbarUI> instances;

        public static Texture2D outline;

        public bool active = false;

        public int whoAmI;

        public readonly float priority;

        public string internalName;

        public string name;

        public PlayerUpdateMethod clickMethod;

        public Texture2D texture;

        public HotbarUI(Texture2D texture, string internalName, string name, PlayerUpdateMethod clickMethod, float priority = -1)
        {
            this.texture = texture;
            this.internalName = internalName;
            this.name = name;
            this.priority = priority;
            this.clickMethod = clickMethod;
            whoAmI = instances.Count;
        }

        /// <summary>
        /// Gets the index of the first UI instance with the same name. Defaults to -1 if no UI is found
        /// </summary>
        /// <param name="name">The internal name of the UI instance</param>
        /// <returns></returns>
        public static int GetIndex(string name)
        {
            for (int i = 0; i < instances.Count; i++)
            {
                if (instances[i].internalName == name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Organizes the instances by their priority value. Only should ran in <see cref="Terraria.ModLoader.Mod.PostSetupContent"/>
        /// </summary>
        public static void Organize()
        {
            instances.Sort((ui1, ui2) => ui1.priority.CompareTo(ui2.priority));
            for (int i = 0; i < instances.Count; i++)
            {
                instances[i].whoAmI = i;
                if (instances[i].name == "")
                {

                }
            }
        }

        public static void DrawActive()
        {
            Main.LocalPlayer.ModPlayer().hoveringOverUI = false;
            if (Main.playerInventory)
            {
                return;
            }
            Vector2 position = new Vector2(4, 4);
            Vector2 selectedPosition = new Vector2(-1, -1);
            int selectedIndex = -1;
            int grayOutIndexCount = -1;
            for (int i = 0; i < instances.Count; i++)
            {
                HotbarUI ui = instances[i];
                if (ui.active)
                {
                    Color drawColor = grayOutIndexCount >= 0 ? Color.Gray : Color.White;
                    Main.spriteBatch.Draw(ui.texture, position, null, drawColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    Rectangle detect = new Rectangle((int)position.X, (int)position.Y, 16, 16);
                    if (grayOutIndexCount >= 0)
                    {
                        grayOutIndexCount--;
                    }
                    if (selectedIndex < 0 && detect.Contains(Main.MouseScreen.ToPoint()))
                    {
                        selectedIndex = i;
                        selectedPosition = position;
                        grayOutIndexCount = (int)(Main.fontMouseText.MeasureString(ui.name).X / 20);
                    }
                    position.X += 20;
                }
            }
            if (selectedIndex >= 0)
            {
                HotbarUI ui = instances[selectedIndex];
                Main.LocalPlayer.ModPlayer().hoveringOverUI = true;
                Main.spriteBatch.Draw(outline, selectedPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (!string.IsNullOrEmpty(ui.name))
                {
                    ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, ui.name, selectedPosition + new Vector2(20, 0), Color.White, 0f, Vector2.Zero, Vector2.One);
                }
                if (Main.mouseLeft && Main.mouseLeftRelease)
                {
                    ui.clickMethod(Main.LocalPlayer);
                }
            }
        }

        public static void Reset()
        {
            foreach (HotbarUI ui in instances)
            {
                ui.active = false;
            }
        }
    }
}