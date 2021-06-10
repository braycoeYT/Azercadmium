using System;
using Terraria.Enums;

namespace Azercadmium.Aaa
{
    public struct PlantInfo
    {
        public int tileType;

        public int[] tileAnchors;

        public LiquidPlacement waterLiquidPlacement;

        public LiquidPlacement lavaLiquidPlacement;

        public PlantInfo(int type, int[] anchors, LiquidPlacement water, LiquidPlacement lava)
        {
            tileType = type;
            tileAnchors = anchors;
            waterLiquidPlacement = water;
            lavaLiquidPlacement = lava;
        }
    }

    public struct ThornInfo
    {
        public int damage;

        public int tileType;

        public ThornDamageMethod damageMethod;

        public ThornInfo(int damage, int tileType, ThornDamageMethod damageMethod)
        {
            this.damage = damage;
            this.tileType = tileType;
            this.damageMethod = damageMethod;
        }

        public override string ToString() => "damage: " + damage + " tileType: " + tileType;
    }

    [Obsolete("Not used anymore. Replaced with internal tree variables")]
    public struct LegacyTreeInfo
    {
        public int treeTileType;

        public int saplingTileType;

        public int minimumHeight;

        public int maximumHeight;

        public int branchChance;

        public string topTexture;

        public string branchTexture;

        public LegacyTreeInfo(int type, int saplingType, int min, int max, string topsTexture, string branchesTexture, int branches)
        {
            treeTileType = type;
            saplingTileType = saplingType;
            minimumHeight = min;
            maximumHeight = max;
            branchChance = branches;
            topTexture = topsTexture;
            branchTexture = branchesTexture;
        }
    }

    public struct TileWandSaveInfo
    {
        public string mode;
        public bool hoverGlow;

        public TileWandSaveInfo(string mode, bool hoverGlow)
        {
            this.mode = mode;
            this.hoverGlow = hoverGlow;
        }
    }

    [Obsolete("Replaced with the Ember Glades class")]
    public struct EmberGladesInfo
    {
        public int[][] chestLoot;

        public int[] butterflies;

        public EmberGladesInfo(int[][] chestLoot, int[] butterflies)
        {
            this.chestLoot = chestLoot;
            this.butterflies = butterflies;
        }
    }
}