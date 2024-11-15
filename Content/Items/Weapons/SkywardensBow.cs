using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles.Ranged;

namespace Bowtide.Content.Items.Weapons
{
    internal class SkywardensBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 60; // Set the bow's damage
            Item.DamageType = DamageClass.Ranged;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ModContent.ProjectileType<SkywardensBlessing>();
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
            Item.height = 50;
            Item.width = 20;
            Item.scale = 2f;
            Item.useTime = 23;
            Item.autoReuse = true;
            Item.Size = new Vector2(64, 64);
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Override the type to always be SkywardensBlessing, no matter what arrow is used
            type = ModContent.ProjectileType<Projectiles.Ranged.SkywardensBlessing>();

            // Fire the SkywardensBlessing projectile
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            // Return false so the default arrow doesn't also spawn
            return false;
        }


        public override Vector2? HoldoutOffset() => new Vector2(-5f, 0f);

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddRecipeGroup("Bowtide:MythrilOrichalcumBar", 12); // Requires 12 bars of either Mythril or Orichalcum
            recipe.AddIngredient(ItemID.Feather, 5); 
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddRecipeGroup("Bowtide:MythrilOrichalcumAnvil");
            recipe.Register();
        }
    }
}
