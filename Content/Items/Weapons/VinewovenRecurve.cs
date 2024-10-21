using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Bowtide.Content.Items.Weapons
{
    public class VinewovenRecurve : ModItem
    {
      
        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 40;
            Item.knockBack = 5.2f;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.value = Item.buyPrice(gold: 1, silver: 20);
            Item.rare = ItemRarityID.LightRed;
            Item.useAmmo = AmmoID.Arrow; // Use any arrow as ammo
            Item.shoot = ProjectileID.WoodenArrowFriendly; // Default to wooden arrows
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.scale = 2f;
            Item.UseSound = SoundID.Item5;
        }

        // Shoot two arrows, and convert wooden arrows to custom VineArrow
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Check if the ammo is wooden arrows, then convert to VineArrow
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<Projectiles.Ranged.VineArrowProjectile>();
            }

            // Shoot two arrows with slight spread
            float numberProjectiles = 2; // Number of arrows to shoot
            float rotation = MathHelper.ToRadians(10); // Angle of spread

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false; 
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.RichMahogany, 8);
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ItemID.Stinger, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
