using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Azercadmium.Tiles.Ember
{
    public abstract class Herb : ModTile
    {
        public virtual bool DieFromLava => true;

        public virtual LiquidPlacement PlaceInLava => LiquidPlacement.NotAllowed;

        public virtual bool DieFromWater => false;

        public virtual LiquidPlacement PlaceInWater => LiquidPlacement.Allowed;

        public virtual Color MapColor => new Color(255, 255, 255);

        public abstract string MapName { get; }

        public virtual void SetData()
        {
        }

        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileNoFail[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
			SetData();
            TileObjectData.newTile.LavaDeath = DieFromLava;
            TileObjectData.newTile.LavaPlacement = PlaceInLava;
            TileObjectData.newTile.WaterDeath = DieFromWater;
            TileObjectData.newTile.WaterPlacement = PlaceInWater;
			TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault(MapName);
            AddMapEntry(MapColor, name);
            soundType = SoundID.Grass;
		}
    }
}