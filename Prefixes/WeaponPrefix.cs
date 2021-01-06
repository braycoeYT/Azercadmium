using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Prefixes
{
    public class Rough : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rough");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.05f;
        }
    }
    public class Tremendous : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tremendous");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            scaleMult = 1.3f;
            useTimeMult = 1.2f;
        }
    }
    public class Atomic : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Atomic");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            scaleMult = 0.7f;
            useTimeMult = 0.8f;
        }
    }
    public class Epic : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Epic");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.12f;
            useTimeMult = 0.9f;
            knockbackMult = 1.2f;
        }
    }
    public class Blessed : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blessed");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            critBonus = 10;
        }
    }
    public class Cursed : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cursed");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 0.9f;
            knockbackMult = 0.9f;
        }
    }
    public class Wasted : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wasted");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            shootSpeedMult = 0.75f;
        }
    }
    public class Empowered : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Empowered");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.05f;
            shootSpeedMult = 1.25f;
        }
    }
    public class Egotistical : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Egotistical");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 0.8f;
            knockbackMult = 1.25f;
            critBonus = 2;
        }
    }
    public class Odd : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Odd");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.01f;
            knockbackMult = 1.01f;
            critBonus = 1;
        }
    }
    public class Exotic : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Exotic");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.2f;
            knockbackMult = 1.1f;
            critBonus = 10;
            useTimeMult = 0.95f;
        }
    }
}