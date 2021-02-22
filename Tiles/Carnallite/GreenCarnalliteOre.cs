using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles.Carnallite
{
	public class GreenCarnalliteOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 320;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1220;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Green Carnallite Ore");
			AddMapEntry(new Color(103, 217, 69), name); //110, 150, 98
			dustType = mod.DustType("GreenCarnalliteDust");
			drop = ItemType<Items.Carnallite.GreenCarnalliteOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 1f;
			minPick = 9999999;
			if (NPC.downedBoss1)
				minPick = 40;
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
			if (NPC.downedBoss1)
				minPick = 40;
		}
		public override bool CanExplode(int i, int j) {
			return NPC.downedBoss1;
		}
	}
}