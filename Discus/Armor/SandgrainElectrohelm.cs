using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Discus.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SandgrainElectrohelm : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sandgrain Electrohelm");
			Tooltip.SetDefault("3% increased ranged damage");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 26;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 5;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<SandgrainElectroplates>() && legs.type == ItemType<SandgrainElectroboots>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Taking over 40 damage creates a temporary damaging electric cube around you\nThe electric cube deals true damage that is equal to the amount of damage taken";
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.electricField = true;
		}
		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.03f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 7);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}