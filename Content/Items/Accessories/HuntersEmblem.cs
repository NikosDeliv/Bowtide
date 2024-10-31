using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bowtide.Content.Items.Accessories
{
    public class HuntersEmblem : ModItem
    {
       

        public override void SetDefaults()
        {
            Item.width = 24; 
            Item.height = 24; 
            Item.accessory = true; // Marks it as an accessory
            Item.value = Item.buyPrice(gold: 5); 
            Item.rare = ItemRarityID.Green; 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.08f; // Increase ranged damage by 8%
            player.moveSpeed += 0.1f; // Boost movement speed by 10%
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RangerEmblem, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 10); 
            recipe.AddIngredient(ItemID.CrystalShard, 5); 
            recipe.AddRecipeGroup("Bowtide:MythrilOrichalcumAnvil");
            recipe.Register();
        }
    }
}