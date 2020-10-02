using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class MonarchalGel : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Monarchal Gel");
			Tooltip.SetDefault("You are a slime monarch\nMost slimes are friendly\nFor every 10% of hp lost, defense increases by 2");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.npcTypeNoAggro[1] = true;
			player.npcTypeNoAggro[16] = true;
			player.npcTypeNoAggro[59] = true;
			player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[122] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[537] = true;
			player.statDefense += 20;
			for (int i = 0; i < player.statLife; i += player.statLifeMax2 / 10) {
				player.statDefense -= 2;
			}
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RoyalGel);
			recipe.AddIngredient(mod.ItemType("SackofProtection"));
			recipe.AddIngredient(mod.ItemType("EmpressShard"), 3);
			recipe.AddIngredient(mod.ItemType("ElementalGel"), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}