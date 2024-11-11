using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles.Ranged;


namespace Bowtide.Content.Items.Weapons
{
    internal class TheTide : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 100; 
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 20; 
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; 
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 50);
            Item.rare = ItemRarityID.Purple; // Rainbow rarity
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly; 
            Item.shootSpeed = 16f;
        }
        public override Vector2? HoldoutOffset() => new Vector2(-5f, 0f);

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.2f; // Increases movement speed
            player.jumpSpeedBoost += 2.4f; // Increases jump height
            if (player.wet) // Underwater effect
            {
                player.gills = true; // Grants water breathing
                player.moveSpeed += 0.2f; // Additional speed underwater
            }

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<CosmicArrowProjectile>();

            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            float numberProjectiles = 3; 
            float rotation = MathHelper.ToRadians(15);

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            // Return false so the default arrow doesn't also spawn
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddIngredient(ItemID.Tsunami, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
