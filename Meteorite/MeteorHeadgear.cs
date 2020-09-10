using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Meteorite
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteorHeadgear : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases ranged critcal strike chance by 5");
		}
		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.value = Item.sellPrice(0, 0, 90, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 6;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemID.MeteorSuit && legs.type == ItemID.MeteorLeggings;
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "20% chance to not consume ammo";
			player.ammoCost80 = true;
		}
		public override void UpdateEquip(Player player) {
			player.rangedCrit += 5;
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