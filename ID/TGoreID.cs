using Terraria;

namespace Azercadmium.ID
{
    public static class TGoreID
    {
        public static int RandomCloudPuff() => Main.rand.Next(3) + 11;
        public static int RandomSmokePuff() => Main.rand.Next(3) + 61;

        public const int CloudPuff = 11;
        public const int CloudPuff2 = 12;
        public const int CloudPuff3 = 13;
        public const int SmokePuff = 61;
        public const int SmokePuff2 = 62;
        public const int SmokePuff3 = 63;
    }
}