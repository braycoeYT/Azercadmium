using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Items.Ember;

namespace Azercadmium.NPCs.Ember.Critters
{
    public class InfernoButterfly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 3;
            Main.npcCatchable[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.Butterfly);
            npc.friendly = true;
            npc.catchItem = (short)ModContent.ItemType<SiltwingButterflyItem>();
            npc.lavaImmune = true;
            animationType = NPCID.Butterfly;
            aiType = NPCID.Butterfly;
        }

        public override void AI() => npc.ai[2] = 1;

        public override bool? CanBeHitByItem(Player player, Item item) => true;

        public override bool? CanBeHitByProjectile(Projectile projectile) => true;

        public override void OnCatchNPC(Player player, Item item) => item.SetDefaults(ModContent.ItemType<SiltwingButterflyItem>());

        //public override void PostDraw(SpriteBatch spriteBatch, Color drawColor) => EmberGlades.Draw1(npc, Texture + "Glow", new Vector2(0, -4), new Vector2(12, 12));
    }
}