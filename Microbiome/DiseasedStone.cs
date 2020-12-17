using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles.Microbiome
{
	public class DiseasedStone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			dustType = mod.DustType("MicrobiomeDust");
			drop = ItemType<Items.Microbiome.DiseasedStone>();
			AddMapEntry(new Color(0, 0, 127));
			mineResist = 2f;
			minPick = 65;
			soundType = SoundID.Tink;
			soundStyle = 1;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0f;
			g = 0f;
			b = 0.02f;
		}
	}
}