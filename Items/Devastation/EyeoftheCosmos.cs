using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Azercadmium.Items.Devastation
{
	public class EyeoftheCosmos : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye of the Cosmos");
			Tooltip.SetDefault("Used to activate and deactivate Devastation Mode\nDevastation mode heavily increases the difficulty of the game and is not recommended for a first playthrough\nNote: Heavily unfinished\nCan only be activated in Expert Mode and when no bosses are alive\nDevastation mode only items will have the Mint Chocolate rarity\nCheck the Azercadmium Discord Server in #info for full list of changes");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.value = 0;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = false;
		}
		public bool BossAlive() 
		{
			for (int i = 0; i < Main.maxNPCs; i++) 
			{
				if ((Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead) && Main.npc[i].active) 
				{
					return true;
				}
            }
			return false;
        }
		public override void ModifyTooltips(List<TooltipLine> list) 
		{
            foreach (TooltipLine tooltipLine in list) 
			{
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") 
				{
					Color color1 = new Color(146, 255, 138);
					Color color2 = new Color(97, 56, 10);
					tooltipLine.overrideColor = Color.Lerp(color1, color2, (float)Math.Sin(Main.GlobalTime % Math.PI));
                }
            }
        }
		public override bool CanUseItem(Player player) 
		{
			return !BossAlive() && Main.expertMode;
		}
		public override bool UseItem(Player player) 
		{
			AzercadmiumWorld.devastation = !AzercadmiumWorld.devastation;
			Main.PlaySound(SoundID.Roar, player.position, 0);
			if (AzercadmiumWorld.devastation == true) 
			{
				Color messageColor = Color.LightGreen;
				string chat = "Devastation Mode activated! Prepare for pain (and mint)!";
				if (Main.netMode == NetmodeID.Server)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				else if (Main.netMode == NetmodeID.SinglePlayer)
					Main.NewText(Language.GetTextValue(chat), messageColor);
			}
			if (AzercadmiumWorld.devastation == false) 
			{
				Color messageColor = Color.Maroon;
				string chat = "Devastation Mode deactivated! Too easy?";
				if (Main.netMode == NetmodeID.Server)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				else if (Main.netMode == NetmodeID.SinglePlayer)
					Main.NewText(Language.GetTextValue(chat), messageColor);
			}
			return true;
		}
	}
}