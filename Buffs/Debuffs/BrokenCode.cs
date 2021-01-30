using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Debuffs
{
    public class BrokenCode : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Broken Code");
            Description.SetDefault("When you screw with code...");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            if (Main.rand.Next(1000) == 0)
                player.velocity.X += 10;
            if (Main.rand.Next(1000) == 0)
                player.velocity.X -= 10;
            if (Main.rand.Next(1000) == 0)
                player.velocity.Y += 10;
            if (Main.rand.Next(1000) == 0)
                player.velocity.Y -= 10;
            for (int i = 0; i < 3; i++) {
                int dustType = mod.DustType("CodeBreakerDust");
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
        public override void Update(NPC npc, ref int buffIndex) {
            if (Main.rand.Next(600) == 0 && npc.boss == false && npc.type != NPCID.TargetDummy)
                npc.velocity.X += 10;
            if (Main.rand.Next(600) == 0 && npc.boss == false && npc.type != NPCID.TargetDummy)
                npc.velocity.X -= 10;
            if (Main.rand.Next(600) == 0 && npc.boss == false && npc.type != NPCID.TargetDummy)
                npc.velocity.Y += 10;
            if (Main.rand.Next(600) == 0 && npc.boss == false && npc.type != NPCID.TargetDummy)
                npc.velocity.Y -= 10;
            for (int i = 0; i < 3; i++) {
                int dustType = mod.DustType("CodeBreakerDust");
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
    }
}