using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles.Zinc
{
	public class ZincOre : ModTile
	{
		public override void SetDefaults() {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 235;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 775;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Zinc Ore");
			AddMapEntry(new Color(108, 158, 181), name);
			dustType = mod.DustType("ZincDust");
			drop = ItemType<Items.Zinc.ZincOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 1f;
			minPick = 0;
		}
	}
}