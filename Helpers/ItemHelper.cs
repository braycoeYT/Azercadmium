using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items
{
    [Obsolete("Replaced with global item methods")]
    public static class ItemHelper
    {
        public static void AddChairRecipe(this ModItem modItem, Mod mod, int item, int tile = -1)
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(item, 4);
            if (tile != -1)
                recipe.AddTile(tile);
            recipe.SetResult(modItem);
            recipe.AddRecipe();
        }

        public static void AddDoorRecipe(this ModItem modItem, Mod mod, int item, int tile = -1)
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(item, 6);
            if (tile != -1)
                recipe.AddTile(tile);
            recipe.SetResult(modItem);
            recipe.AddRecipe();
        }

        public static void AddTableRecipe(this ModItem modItem, Mod mod, int item, int tile = -1)
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(item, 8);
            if (tile != -1)
                recipe.AddTile(tile);
            recipe.SetResult(modItem);
            recipe.AddRecipe();
        }

        public static void DefaultToTorch(this Item item, int tileStyleToPlace, bool allowWaterPlacement = false)
        {
            item.flame = true;
            item.noWet = !allowWaterPlacement;
            item.holdStyle = 1;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = TileID.Torches;
            item.placeStyle = tileStyleToPlace;
            item.width = 10;
            item.height = 12;
            item.value = 60;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
        }

        public static void DefaultToTileItem(this Item item, int tileIDToPlace, int tileStyleToPlace = 0)
        {
            item.createTile = tileIDToPlace;
            item.placeStyle = tileStyleToPlace;
            item.width = 14;
            item.height = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
        }

        public static void DefaultToFurnitureItem(this Item item, int tileIDToPlace, int tileStyleToPlace = 0)
        {
            item.createTile = tileIDToPlace;
            item.placeStyle = tileStyleToPlace;
            item.width = 14;
            item.height = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
        }

        // this seems completely useless ngl
        public static void SetShopValues(this Item item, int rarity, int coinValue)
        {
            item.rare = rarity;
            item.value = coinValue;
        }
    }
}