using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Bowtide.Content.Items.Accessories;

namespace Bowtide.Utilities
{
    public class BowtideGlobalNPC : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Dryad)
            {
                
                shop.Add(ModContent.ItemType<ForestEmbrace>(), Condition.InOverworldHeight);
            }
        }
    }
}
