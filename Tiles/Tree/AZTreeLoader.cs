using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Tiles.Tree
{
    public static class AZTreeLoader
    {
        public static Dictionary<int, AZTree> trees;

        public static List<int> saplings;

        /// <summary>
        /// Attempts to get a tree at the specific tile. Defaults to null if no tree is found. Only one instance of every tree exists.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static AZTree GetTree(int i, int j) => trees.ContainsKey(Framing.GetTileSafely(i, j).type) ? trees[Main.tile[i, j].type] : null;

        /// <summary>
        /// Attempts to get a tree at the specific tile. Defaults to null if no tree is found. Only one instance of every tree exists.
        /// </summary>
        /// <returns></returns>
        public static AZTree GetTree(Tile tile) => trees.ContainsKey(tile.type) ? trees[tile.type] : null;

        /// <summary>
        /// Attempts to get a tree at the specific tile. Defaults to null if no tree is found. Only one instance of every tree exists.
        /// </summary>
        /// <returns></returns>
        public static AZTree GetTree(int type) => trees.ContainsKey(type) ? trees[type] : null;

        public static bool GrowSapling(int i, int j, AZTree instance)
        {
            AZTree tree = GetTree(i, j);
            return tree != null ? AZTree.GrowTree(i, j, tree) : false;
        }
    }
}