using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bowtide.Content.Projectiles;

namespace Bowtide.Content.Items.Ammo
{
    internal class CosmicArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 36;

            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 1);
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.CosmicArrowProjectile>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 5f;
            Item.ammo = AmmoID.Arrow;
    
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ItemID.LunarBar, 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 2);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

    }

}
