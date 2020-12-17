using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Projectiles
{
	public class DevastationGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public override void SetDefaults(Projectile projectile)
		{
			if (AzercadmiumWorld.devastation && projectile.type != -1)
			{
			    switch (projectile.type)
			    {
			    	case 1:
			    	
				    break;
			    }
			}
		}
		public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
		{
			if (AzercadmiumWorld.devastation && projectile.type != -1)
			{
				switch (projectile.type)
				{
					case 174: //ice spike
						target.AddBuff(BuffID.Frostburn, 180);
						target.AddBuff(BuffID.Chilled, 300);
						goto case 605;
					case 176: //jungle spike
						goto case 605;
					case 605: //slime proj
						target.AddBuff(mod.BuffType("SlimyOoze"), 300);
						break;
				}
			}
		}
		public static Projectile[] ProjExplosion(int num, Vector2 pos, int type, float speed, int damage, float knockback)
        {
            Projectile[] proj = new Projectile[num];
            double spread = 2 * Math.PI / num;
            for (int i = 0; i < num; i++)
                proj[i] = NewProjectile2(pos, new Vector2(speed, speed).RotatedBy(spread * i), type, damage, knockback, Main.myPlayer);
            return proj;
        }
		public static Projectile NewProjectile2(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < 1000) ? Main.projectile[p] : null;
        }
	}
}