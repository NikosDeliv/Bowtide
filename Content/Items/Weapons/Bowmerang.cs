using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles;

namespace Bowtide.Content.Items.Weapons
{
    public class Bowmerang : ModItem
    {

        private bool boomerangActive = false;

        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
            Item.autoReuse = true;
        }




            public override bool AltFunctionUse(Player player)
            {
                // Enable alternate function (right-click) to throw the boomerang
                return true;
            }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) // Right-click: Boomerang mode
            {
                if (!boomerangActive) // If boomerang is not active, throw it
                {
                    Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.BowmerangProjectile>();
                    Item.shootSpeed = 10f; // Boomerang speed
                    boomerangActive = true; // Set boomerang as active
                }
                else
                {
                    return false; // Prevent additional boomerang throws
                }
            }
            else // Left-click: Arrow mode
            {
                if (!boomerangActive) // Only shoot arrows if boomerang is not active
                {
                    Item.shoot = ProjectileID.WoodenArrowFriendly;
                    Item.shootSpeed = 12f;
                    return true;
                }
                else
                {
                    return false; // Block arrow shooting if the boomerang is out
                }
            }
            return base.CanUseItem(player);
        }

        public void ResetBoomerang()
        {
            boomerangActive = false; // Reset when boomerang comes back or is destroyed
        }




        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
            {
                if (player.altFunctionUse == 2) // Right-click: Boomerang
                {
                    type = ModContent.ProjectileType<Projectiles.Ranged.BowmerangProjectile>(); // Use custom boomerang projectile
                    Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                }
                else // Left-click: Arrows
                {
                    type = ProjectileID.WoodenArrowFriendly; // Shoot arrows
                    Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                }

                return false; // Return false to manually handle the projectile firing
            }

            public override void AddRecipes()
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.WoodenBoomerang, 1); 
                recipe.AddIngredient(ItemID.Wood, 15); 
                recipe.AddIngredient(ItemID.Cobweb, 10); 
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }
        
    }
}