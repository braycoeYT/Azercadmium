using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles.Aquite
{
	public class AquiteOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 710;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 400;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Aquite Ore");
			AddMapEntry(new Color(57, 237, 237), name); //110, 150, 98
			dustType = mod.DustType("AquiteDust");
			drop = ItemType<Items.Aquite.AquiteOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 6f;
			minPick = 200;
		}
		public override bool CanExplode(int i, int j) {
			return false;
		}
	}
}