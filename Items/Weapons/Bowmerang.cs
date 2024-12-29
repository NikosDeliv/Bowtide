using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles.Ranged;

namespace Bowtide.Content.Items.Weapons
{
    public class Bowmerang : ModItem
    {
        private bool boomerangActive = false;

        public override void SetDefaults()
        {
            Item.damage = 20;
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
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
            Item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true; // Enable right-click functionality
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) // Right-click for Boomerang mode
            {
                if (!boomerangActive) // Only allow if boomerang is not active
                {
                    Item.useTime = 30; // Adjust throw timing
                    Item.useAnimation = 30;
                    Item.shoot = ModContent.ProjectileType<BowmerangProjectile>(); // Throw the boomerang
                    Item.shootSpeed = 10f;
                    Item.useAmmo = AmmoID.None; // Prevent arrow use
                    Item.noUseGraphic = true; // Hide bow in hand
                    boomerangActive = true; // Mark boomerang as active
                }
                else
                {
                    return false; // Prevent additional throws if boomerang is out
                }
            }
            else // Left-click for Arrow mode
            {
                if (!boomerangActive) // Only shoot arrows if boomerang is not out
                {
                    Item.useTime = 20;
                    Item.useAnimation = 20;
                    Item.shoot = ProjectileID.WoodenArrowFriendly;
                    Item.shootSpeed = 12f;
                    Item.useAmmo = AmmoID.Arrow;
                    Item.noUseGraphic = false; // Show bow in hand
                }
                else
                {
                    return false; // Block arrow shooting if boomerang is active
                }
            }
            return base.CanUseItem(player);
        }

        public override void UpdateInventory(Player player)
        {
          if (player.HeldItem.type != Item.type && boomerangActive)
           {
                ResetBoomerang(); 
           }
        }

        public void ResetBoomerang()
        {
            boomerangActive = false; // Reset boomerang state when it returns or despawns
            Item.noUseGraphic = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2) // Right-click: Boomerang
            {
                type = ModContent.ProjectileType<BowmerangProjectile>(); // Use custom boomerang projectile
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                return false; // Manually handle boomerang throw
            }
            // Left-click: Arrow shooting
            return true; // Use default arrow shooting behavior
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