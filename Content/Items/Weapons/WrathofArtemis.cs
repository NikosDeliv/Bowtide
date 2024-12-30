using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Bowtide.Content.Projectiles.Ranged;
using Bowtide.Content.Items.Weapons;

namespace Bowtide.Content.Items.Weapons
{
    internal class WrathofArtemis : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 170;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 128;
            Item.height = 128;
            Item.useTime = 5; // Reduced use time for faster shooting
            Item.useAnimation = 10; // Reduced use animation for faster shooting
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

        public override Vector2? HoldoutOffset() => new Vector2(-20f, 0f);

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int proj = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false; // Prevent default shot behavior
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ItemID.Acorn, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 10);
            recipe.AddIngredient(ModContent.ItemType<VinewovenRecurve>(), 1); // Add VinewovenRecurve as an ingredient
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}