using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Azercadmium.Buffs;
using Azercadmium.Aaa;
using Azercadmium.Buffs.Debuffs;

namespace Azercadmium.Items.Ember
{
    public class OverwrathMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overwrath Mask");
            Tooltip.SetDefault("Grants the ability to swim and greatly extends underwater breathing" +
                "\nProvides light in liquids and extra mobility on ice" +
                "\nProvides immunity to lava damage and Burning Skin" +
                "\nProvides immunity to Chilled, Frozen, and On Fire" +
                "\nEmber Thorns deal no damage" +
                "\nLiquids reset flight time");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 8);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TAZPlayer>().overwrathMask = true;
            player.accFlipper = true;
            player.accDivingHelm = true;
            player.iceSkate = true;
            player.lavaImmune = true;
            player.buffImmune[ModContent.BuffType<BurningSkin>()] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.OnFire] = true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ArcticDivingGear);
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddIngredient(ItemID.HandWarmer);
            recipe.AddIngredient(ModContent.ItemType<RevenantShield>());
            recipe.AddIngredient(ItemID.ObsidianSkinPotion, 3);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddIngredient(ModContent.ItemType<ScorchSap>(), 16);
            recipe.AddIngredient(ModContent.ItemType<BurntStinger>(), 9);
            recipe.AddIngredient(ModContent.ItemType<SparkingBatFoot>(), 9);
            recipe.AddIngredient(ModContent.ItemType<FlareSerpentScale>(), 9);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this); 
			recipe.AddRecipe(); 
		}
    }
}