using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bowtide.Utilities
{
    public class BowtideRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            // Mythril and Orichalcum Bars
            RecipeGroup mythrilOrichalcumBars = new RecipeGroup(() => "Any Hardcore Bar", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("Bowtide:MythrilOrichalcumBar", mythrilOrichalcumBars);

            // Mythril and Orichalcum Anvils
            RecipeGroup mythrilOrichalcumAnvils = new RecipeGroup(() => "Any Hardcore Anvil", new int[]
            {
                ItemID.MythrilAnvil,
                ItemID.OrichalcumAnvil
            });
            RecipeGroup.RegisterGroup("Bowtide:MythrilOrichalcumAnvil", mythrilOrichalcumAnvils);

            // Adamantite and Titanium Forges
            RecipeGroup adamantiteTitaniumForge = new RecipeGroup(() => "Any Hardcore Forge", new int[]
            {
                ItemID.AdamantiteForge,
                ItemID.TitaniumForge
            });
            RecipeGroup.RegisterGroup("Bowtide:AdamantiteTitaniumForge", adamantiteTitaniumForge);
        }
    }
}