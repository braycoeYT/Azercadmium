using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Smore.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GooeyCowl : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Somehow just as strong as metal, but I wouldn't question it\nIncreases damage by 3%");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = 0;
			item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<GooeyCover>() && legs.type == ItemType<GooeyLeggings>();
		}
		public override void UpdateArmorSet(Player player) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			player.setBonus = "Every third projectile releasing swing/shot/use also releases an explosive marshmallow (excluding certain weapons)";
			p.gooeySetBonus = true;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.03f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Smore"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}