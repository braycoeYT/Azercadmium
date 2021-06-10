using Terraria;

namespace Azercadmium.Helpers
{
    public static class RunningHelper
    {
        public static bool GameWorldRunning => !Main.gameInactive && !Main.gameMenu && !Main.gamePaused;
    }
}