using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles.Ranged;

namespace Bowtide.Content.Items.Weapons
{
    internal class Nightpiercer : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 165;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 128;
            Item.height = 128;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 40);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Arrow; // Use default arrow ammo
        }

        public override Vector2? HoldoutOffset() => new Vector2(-55f, 0f);

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 2; // Number of arrows to shoot
            float spacing = 10f; // Adjust the spacing between arrows as needed

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 offset = new Vector2(0, spacing * (i - (numberProjectiles - 1) / 2f));
                Vector2 newPosition = position + offset;
                int proj = Projectile.NewProjectile(source, newPosition, velocity, type, damage, knockback, player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<NightpiercerProjectile>().applyShadowflame = true; // Apply Shadowflame debuff
            }
            return false; // Prevent default shot behavior
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddIngredient(ItemID.HellwingBow, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}