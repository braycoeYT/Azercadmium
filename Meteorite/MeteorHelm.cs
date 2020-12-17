using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Meteorite
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteorHelm : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee speed by 6%");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 22;
			item.value = Item.sellPrice(0, 0, 90, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 7;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemID.MeteorSuit && legs.type == ItemID.MeteorLeggings;
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Rains fallen stars from above the cursor every two seconds while using a melee weapon";
		}
		public override void UpdateEquip(Player player) {
			player.meleeSpeed -= 0.06f;
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.meteorMelee = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}