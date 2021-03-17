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
        private byte damage;
        private byte defense;
        private byte mana;

        public override float RollChance(Item item)
        {
            return 1.2f;
        }

        public override bool CanRoll(Item item)
        {
            return GetInstance<AzercadmiumConfig>().azercadmiumPrefixes;
        }

        public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

        public AccessoryPrefix()
        {
        }

        public AccessoryPrefix(byte health, byte crit, byte damage, byte defense, byte mana)
        {
            this.health = health;
            this.crit = crit;
            this.damage = damage;
            this.defense = defense;
            this.mana = mana;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                //mod.AddPrefix("name", new AccessoryPrefix(health, crit, damage, defense, mana));
                mod.AddPrefix("Animated", new AccessoryPrefix(2, 0, 0, 0, 0));
                mod.AddPrefix("Living", new AccessoryPrefix(4, 0, 0, 0, 0));
                mod.AddPrefix("Organic", new AccessoryPrefix(6, 0, 0, 0, 0));
                mod.AddPrefix("Biological", new AccessoryPrefix(8, 0, 0, 0, 0));
                mod.AddPrefix("Pleasant", new AccessoryPrefix(0, 1, 0, 0, 0));
                mod.AddPrefix("Charming", new AccessoryPrefix(0, 3, 0, 0, 0));
                mod.AddPrefix("Critical", new AccessoryPrefix(0, 5, 0, 0, 0));
                mod.AddPrefix("Dangerous", new AccessoryPrefix(0, 1, 2, 1, 0));
                mod.AddPrefix("Natural", new AccessoryPrefix(4, 0, 0, 2, 0));
                mod.AddPrefix("Restored", new AccessoryPrefix(4, 0, 0, 0, 10));
                mod.AddPrefix("Awakened", new AccessoryPrefix(2, 1, 1, 1, 5));
            }
            return false;
        }

        public override void Apply(Item item)
        {
            item.GetGlobalItem<AzercadmiumForge>().health = health;
            item.GetGlobalItem<AzercadmiumForge>().crit = crit;
            item.GetGlobalItem<AzercadmiumForge>().damage = damage;
            item.GetGlobalItem<AzercadmiumForge>().defense = defense;
            item.GetGlobalItem<AzercadmiumForge>().mana = mana;
        }

        public override void ModifyValue(ref float valueMult)
        {
            float multiplier = 1f * (1 + health * 0.02f) * (1 + crit * 0.04f) * (1 + damage * 0.04f) * (1 + defense * 0.04f) * (1 + mana * 0.02f);
            valueMult *= multiplier;
        }
    }

    public class AzercadmiumForge : GlobalItem
    {
        public int health;
        public int crit;
        public int damage;
        public int defense;
        public int mana;
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            AzercadmiumForge myClone = (AzercadmiumForge)base.Clone(item, itemClone);

            myClone.health = health;
            myClone.crit = crit;
            myClone.damage = damage;
            myClone.defense = defense;
            myClone.mana = mana;
            return myClone;
        }
        public override bool NewPreReforge(Item item) {
            health = 0;
            crit = 0;
            damage = 0;
            defense = 0;
            mana = 0;
            return base.NewPreReforge(item);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
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
                line.text = "+" + crit + "% critical strike chance";
            }
            if (damage > 0)
            {
                TooltipLine line = new TooltipLine(mod, "damage", "+" + damage + "% damage");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + damage + "% damage";
            }
            if (defense > 0)
            {
                TooltipLine line = new TooltipLine(mod, "defense", "+" + defense + " defense");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + defense + " defense";
            }
            if (mana > 0)
            {
                TooltipLine line = new TooltipLine(mod, "mana", "+" + mana + " max mana");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + mana + " max mana";
            }
        }
        public override void UpdateEquip(Item item, Player player) {
            if (item.prefix > 0) {
                player.statLifeMax2 += health;
                player.meleeCrit += crit;
                player.rangedCrit += crit;
                player.magicCrit += crit;
                player.allDamage += (float)damage / 100;
                player.statDefense += defense;
                player.statManaMax2 += mana;
            }
        }

        public override void NetSend(Item item, BinaryWriter writer) {
            writer.Write(health);
            writer.Write(crit);
            writer.Write(damage);
            writer.Write(defense);
            writer.Write(mana);
        }

        public override void NetReceive(Item item, BinaryReader reader) {
            health = reader.ReadInt32();
            crit = reader.ReadInt32();
            damage = reader.ReadInt32();
            defense = reader.ReadInt32();
            mana = reader.ReadInt32();
        }
    }
}