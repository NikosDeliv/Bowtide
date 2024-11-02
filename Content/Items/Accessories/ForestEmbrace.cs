using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bowtide.Content.Items.Accessories
{
    class ForestEmbrace : ModItem
    {
    
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 28;
        Item.accessory = true;
        Item.value = Item.buyPrice(gold: 2);
        Item.rare = ItemRarityID.Green;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        // Check if the player is in a forest biome and not moving
        if (player.ZoneOverworldHeight && player.velocity.Length() < 0.1f)
        {
            // Gradual health regeneration
            ApplyForestRegen(player);
        }
    }

        private void ApplyForestRegen(Player player)
        {
            // Increases the player's lifeRegen by 5 
            player.lifeRegen += 5; 


            if (Main.rand.NextBool(10)) // Control spawn rate of particles
            {
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, DustID.Grass);
                Main.dust[dustIndex].velocity *= 0.5f;
                Main.dust[dustIndex].scale = 1.2f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Vine, 3);  
            recipe.AddIngredient(ItemID.Topaz, 5);  
            recipe.AddIngredient(ItemID.Wood, 10); 
            recipe.AddTile(TileID.WorkBenches);     
            recipe.Register();
        }
    }
}
