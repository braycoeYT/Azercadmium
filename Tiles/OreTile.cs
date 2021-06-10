using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Tiles
{
    public abstract class OreTile : ModTile
    {
		public abstract int ItemDrop { get; }
		public abstract string MapName { get; }
		public abstract Color MapColor { get; }
		public abstract int MinPickaxe { get; }
		public virtual float MineResist => 1f;
		public virtual int DustType => 0;
		public virtual int Rarity => 200;
		public virtual int ShineChance => 1000;
        public override void SetDefaults()
        {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; 
			Main.tileValue[Type] = (short)Rarity; 
			Main.tileShine2[Type] = true; 
			Main.tileShine[Type] = ShineChance;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault(MapName);
			AddMapEntry(MapColor, name);
			dustType = DustType;
			drop = ItemDrop;
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = MineResist;
			minPick = MinPickaxe;
		}
	}
}