using Azercadmium.Aaa;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Azercadmium.Tiles.Ember
{
    public abstract class Plants : ModTile
    {
        public abstract int[] TileAnchors { get; }
        public abstract Color MapColor { get; }
        public virtual bool WaterDeath => false;
        public virtual bool LavaDeath => true;
        public virtual int StyleRange => 3;
        public virtual LiquidPlacement WaterPlacement => LiquidPlacement.Allowed;
        public virtual LiquidPlacement LavaPlacement => LiquidPlacement.NotAllowed;
        public sealed override void SetDefaults()
        {
            Azercadmium.PlantInfo.Add(new PlantInfo(Type, TileAnchors, WaterPlacement, LavaPlacement));
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.AnchorValidTiles = TileAnchors;
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot, TileID.PlanterBox };
            TileObjectData.newTile.CoordinateHeights = new int[] { 19, };
            TileObjectData.newTile.RandomStyleRange = StyleRange;
            TileObjectData.newTile.WaterDeath = WaterDeath;
            TileObjectData.newTile.LavaDeath = !LavaDeath;
            TileObjectData.newTile.WaterPlacement = WaterPlacement;
            TileObjectData.newTile.LavaPlacement = LavaPlacement;
            TileObjectData.addTile(Type);
            AddMapEntry(MapColor);
            disableSmartCursor = false;
            soundType = SoundID.Grass;
        }
    }
}