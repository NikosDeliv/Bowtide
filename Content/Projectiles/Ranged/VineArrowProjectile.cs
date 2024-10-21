using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Bowtide.Content.Projectiles.Ranged
{
    public class VineArrowProjectile : ModProjectile
    {
    

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 32;
            Projectile.aiStyle = 1; // Arrow AI
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1; // Number of enemies the projectile can hit before being destroyed
            Projectile.arrow = true; // Makes the projectile an arrow
            AIType = ProjectileID.WoodenArrowFriendly; // Copy AI from wooden arrow
        }

        public override void AI()
        {
            // Rotate the arrow sprite to match the direction of movement
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2; // PiOver2 is a 90-degree adjustment
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Poisoned, 600); // Apply poison for 10 seconds
        }

    }
}
