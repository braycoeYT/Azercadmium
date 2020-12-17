using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Prefixes
{
    public class AccessoryPrefix : ModPrefix
    {
        private byte health;
        private byte crit;

        public override float RollChance(Item item)
        {
            return GetInstance<AzercadmiumConfig>().azercadmiumPrefixes ? 1.2f : 0f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

        public AccessoryPrefix()
        {
        }

        public AccessoryPrefix(byte health, byte crit)
        {
            this.health = health;
            this.crit = crit;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                //mod.AddPrefix("name", new AccessoryPrefix(health, crit));
                mod.AddPrefix("Animated", new AccessoryPrefix(2, 0));
                mod.AddPrefix("Living", new AccessoryPrefix(4, 0));
                mod.AddPrefix("Organic", new AccessoryPrefix(6, 0));
                mod.AddPrefix("Biological", new AccessoryPrefix(8, 0));
                mod.AddPrefix("Pleasant", new AccessoryPrefix(0, 1));
                mod.AddPrefix("Charming", new AccessoryPrefix(0, 3));
                mod.AddPrefix("Critical", new AccessoryPrefix(0, 5));
            }
            return false;
        }

        public override void Apply(Item item)
        {
            item.GetGlobalItem<AzercadmiumForge>().health = health;
            item.GetGlobalItem<AzercadmiumForge>().crit = crit;
        }

        public override void ModifyValue(ref float valueMult)
        {
            float multiplier = 1f * (1 + health * 0.02f) * (1 + crit * 0.04f);
            valueMult *= multiplier;
        }
    }

    public class AzercadmiumForge : GlobalItem
    {
        public int health;
        public int crit;
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            AzercadmiumForge myClone = (AzercadmiumForge)base.Clone(item, itemClone);

            myClone.health = health;
            myClone.crit = crit;
            return myClone;
        }

        public override bool NewPreReforge(Item item)
        {
            health = 0;
            crit = 0;
            return base.NewPreReforge(item);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (health > 0)
            {
                TooltipLine line = new TooltipLine(mod, "health", "+" + health + " max health");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + health + " max health";
            }
            if (crit > 0)
            {
                TooltipLine line = new TooltipLine(mod, "crit", "+" + crit + "% critical strike chance");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + crit + " critical strike chance";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.prefix > 0)
            {
                player.statLifeMax2 += health;
                player.meleeCrit += crit;
                player.rangedCrit += crit;
                player.magicCrit += crit;
            }
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(health);
            writer.Write(crit);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            health = reader.ReadInt32();
            crit = reader.ReadInt32();
        }
    }
}