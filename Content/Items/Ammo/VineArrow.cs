using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bowtide.Content.Projectiles;

namespace Bowtide.Content.Items.Ammo
{
    public class VineArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 36;

            Item.damage = 6; 
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(copper: 16);
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.VineArrowProjectile>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 5f; 
            Item.ammo = AmmoID.Arrow; 
        }

        public void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 600); // Apply poison for 10 seconds
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
               recipe.AddIngredient(ItemID.Vine, 2);
               recipe.AddTile(TileID.WorkBenches);
               recipe.Register();
        }
    }
}