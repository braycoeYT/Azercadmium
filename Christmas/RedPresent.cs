using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Christmas
{
	public class RedPresent : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Present");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 16;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
		}
		public override bool CanRightClick() {
			return true;
		}
		public override void RightClick(Player player) {
			float rand = Main.rand.NextFloat();
			if (rand < .1f)
				player.QuickSpawnItem(ItemID.CandyCaneBlock, Main.rand.Next(20, 50));
			else if (rand < .2f)
				player.QuickSpawnItem(ItemID.GreenCandyCaneBlock, Main.rand.Next(20, 50));
			else if (rand < .23f)
				player.QuickSpawnItem(ItemID.ChristmasPudding);
			else if (rand < .26f)
				player.QuickSpawnItem(ItemID.SugarCookie);
			else if (rand < .29f)
				player.QuickSpawnItem(ItemID.GingerbreadCookie);
			else if (rand < .3f)
				player.QuickSpawnItem(ItemID.DogWhistle);
			else if (rand < .4f)
				player.QuickSpawnItem(ItemID.PineTreeBlock, Main.rand.Next(20, 50));
			else if (rand < .45f)
				player.QuickSpawnItem(ItemID.Coal);
			else if (rand < .456f)
				player.QuickSpawnItem(ItemID.CandyCaneSword);
			else if (rand < .462f)
				player.QuickSpawnItem(1917);
			else if (rand < .468f)
				player.QuickSpawnItem(ItemID.FruitcakeChakram);
			else if (rand < .474f)
				player.QuickSpawnItem(ItemID.HandWarmer);
			else if (rand < .48f)
				player.QuickSpawnItem(ItemID.Toolbox);
			else if (rand < .57f)
				player.QuickSpawnItem(ItemID.Holly);
			else if (rand < .64f)
				player.QuickSpawnItem(ItemID.StarAnise, Main.rand.Next(20, 41));
			else if (rand < .65f)
				player.QuickSpawnItem(mod.ItemType("RedPivot"));
			else if (rand < .66f)
				player.QuickSpawnItem(mod.ItemType("GreenPivot"));
			else if (rand < .68f)
				player.QuickSpawnItem(ItemID.ReindeerAntlers);
			else if (rand < .69f)
				player.QuickSpawnItem(ItemID.SnowHat);
			else if (rand < .7f)
				player.QuickSpawnItem(ItemID.UglySweater);
			else if (rand < .71f) {
				player.QuickSpawnItem(ItemID.RedRyder);
				player.QuickSpawnItem(ItemID.MusketBall, Main.rand.Next(30, 61));
			}
			else if (rand < .77f)
				player.QuickSpawnItem(mod.ItemType("Pinecone"), Main.rand.Next(30, 61));
			else if (rand < .83f)
				player.QuickSpawnItem(ItemID.Eggnog, Main.rand.Next(1, 4));
			else if (rand < .84f)
				player.QuickSpawnItem(mod.ItemType("CandyCaneCrusher"));
			else if (rand < .85f)
				player.QuickSpawnItem(mod.ItemType("CandyCanePike"));
			else if (rand < .9f)
				player.QuickSpawnItem(mod.ItemType("Smore"), Main.rand.Next(1, 4));
			else if (rand < .901f)
				player.QuickSpawnItem(ItemID.LifeCrystal);
			else if (rand < .925f)
				player.QuickSpawnItem(ItemID.WarmthPotion, Main.rand.Next(1, 6));
			else if (rand < .94f)
				player.QuickSpawnItem(ItemID.Snowball, Main.rand.Next(50, 121));
			else if (rand < .945f)
				player.QuickSpawnItem(ItemID.IceMachine);
			else if (rand < .946f)
				player.QuickSpawnItem(ItemID.IceBoomerang);
			else if (rand < .947f)
				player.QuickSpawnItem(ItemID.SnowballCannon);
			else if (rand < .948f)
				player.QuickSpawnItem(ItemID.IceSkates);
			else if (rand < .949f)
				player.QuickSpawnItem(724);
			else if (rand < .95f)
				player.QuickSpawnItem(ItemID.BlizzardinaBottle);
			else if (rand < .951f)
				player.QuickSpawnItem(ItemID.IceMirror);
			else
				player.QuickSpawnItem(mod.ItemType("UglySocks"));
		}
	}
}