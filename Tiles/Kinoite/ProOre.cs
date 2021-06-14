using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles.Kinoite
{
	public class ProOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 820;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1220;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Kinoite Ore");
			AddMapEntry(new Color(30, 75, 90), name); //110, 150, 98
			dustType = mod.DustType("KinoiteDust");
			drop = ItemType<Items.Kinoite.KinoiteOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 5f;
			minPick = 225;
		}
		public override bool CanExplode(int i, int j) {
			return false;
		}
	}
}