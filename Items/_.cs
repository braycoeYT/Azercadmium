using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;
using Azercadmium.Tiles.Tree;

namespace Azercadmium.Items
{
    [Obsolete("Only used for testing")]
    public class _ : ModItem
    {
        public override bool Autoload(ref string name) => false;
        public override string Texture => "ModLoader/MysteryItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("_");
            Tooltip.SetDefault("Turns all plants and stems into their modern tile");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Purple;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    ModTile mTile = ModContent.GetModTile(tile.type);
                    if (mTile != null)
                    {
                        if (mTile.mod.Name == "Azercadmium")
                        {
                            if (mTile.Name == "Plants")
                            {
                                tile.type = (ushort)ModContent.TileType<HellPlants>();
                                tile.frameY = 0;
                                tile.frameX = (short)MathHelper.Clamp(tile.frameX, 0, 198);
                            }
                            if (mTile.Name == "Stems")
                            {
                                tile.type = (ushort)ModContent.TileType<CinderCedarTree>();
                                if (tile.frameX > 264)
                                {
                                    tile.frameX -= 264;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}