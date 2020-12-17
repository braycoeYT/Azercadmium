using Microsoft.Xna.Framework;
using System.Threading;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Devastation
{
	public class DreaminEye : ModNPC
	{
		public override string Texture => "Terraria/NPC_" + NPCID.DemonEye;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dreamin Eye");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DemonEye);
			npc.value = 0f;
			npc.aiStyle = NPCID.DemonEye;
			animationType = NPCID.DemonEye;
			npc.lifeMax = 48;
			npc.damage = 36;
			npc.defense = 4;
			npc.noTileCollide = true;
			//npc.color = Color.Aqua;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(1, 4) * 60, true);
		}
		int Timer = Main.rand.Next(1, 480);
		public override void AI() {
			Timer++;
			if (Timer % 480 == 0 && npc.spriteDirection == 0)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + 90), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
			else if (Timer % 480 == 0)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedBy(npc.rotation + 270), ProjectileID.EyeLaser, npc.damage / 4, 0f, Main.myPlayer);
			switch ((int)(Timer / 4) % 13) {
				case 1:
					npc.color = Color.Red;
					break;
				case 2:
					npc.color = Color.OrangeRed;
					break;
				case 3:
					npc.color = Color.Orange;
					break;
				case 4:
					npc.color = Color.Yellow;
					break;
				case 5:
					npc.color = Color.Lime;
					break;
				case 6:
					npc.color = Color.Green;
					break;
				case 7:
					npc.color = Color.LightSeaGreen;
					break;
				case 8:
					npc.color = Color.PowderBlue;
					break;
				case 9:
					npc.color = Color.Blue;
					break;
				case 10:
					npc.color = Color.RoyalBlue;
					break;
				case 11:
					npc.color = Color.Purple;
					break;
				case 12:
					npc.color = Color.DeepPink;
					break;
				case 13:
					npc.color = Color.Magenta;
					break;
			}
		}
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 2; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void NPCLoot() {
			for (int i = 0; i < 5; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}