using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles.Ranged;

namespace Bowtide.Content.Items.Weapons
{
    public class EnchantedBowmerang : ModItem
    {
        private bool enchantedboomerangActive = false;

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 20);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
            Item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (!enchantedboomerangActive) 
                {
                    Item.useTime = 30; 
                    Item.useAnimation = 30;
                    Item.shoot = ModContent.ProjectileType<EnchantedBowmerangProjectile>();
                    Item.shootSpeed = 10f;
                    Item.useAmmo = AmmoID.None;
                    Item.noUseGraphic = true;
                    enchantedboomerangActive = true;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                if (!enchantedboomerangActive)
                {
                    Item.useTime = 20;
                    Item.useAnimation = 20;
                    Item.shoot = ProjectileID.WoodenArrowFriendly;
                    Item.shootSpeed = 12f;
                    Item.useAmmo = AmmoID.Arrow;
                    Item.noUseGraphic = false; 
                }
                else
                {
                    return false; 
                }
            }
            return base.CanUseItem(player);
        }

        public override void UpdateInventory(Player player)
        {
            if (player.HeldItem.type != Item.type && enchantedboomerangActive)
            {
                ResetBoomerang();
            }
        }
        public void ResetBoomerang()
        {
            enchantedboomerangActive = false; // Reset boomerang state when it returns or despawns
            Item.noUseGraphic = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2) // Right-click: Boomerang
            {
                type = ModContent.ProjectileType<EnchantedBowmerangProjectile>(); // Use custom boomerang projectile
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                return false; // Manually handle boomerang throw
            }
            // Left-click: Arrow shooting
            return true; // Use default arrow shooting behavior
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Bowmerang>(), 1);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}