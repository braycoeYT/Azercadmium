using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Azercadmium.Aaa
{
    public class TAZRecipe : ModRecipe
    {
        public TAZRecipe(Mod mod) : base(mod) { }

        //public const int infiniteAmmoAmount = 3996;

        public static Point BrokenCastData { get; set; }

        /*public override int ConsumeItem(int type, int numRequired) 
        { 
            if (Azercadmium.ItemCastCache[type])
            {
                if (Main.rand.Next(1000) != 0)
                {
                    numRequired = 0;
                }
                else
                {
                    BrokenCastData = new Point(type, numRequired);
                }
            }
            return numRequired;
        }

        public override void OnCraft(Item item)
        {
            if (BrokenCastData != Point.Zero)
            {
                Main.PlaySound(SoundID.Item37, Main.LocalPlayer.position);
                Main.NewText("[i/s" + BrokenCastData.Y + ":" + BrokenCastData.X + "] has broken", Color.LimeGreen);
                BrokenCastData = Point.Zero;
            }
        }*/
    }
}