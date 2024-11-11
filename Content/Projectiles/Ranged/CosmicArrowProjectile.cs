using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bowtide.Content.Projectiles.Ranged
{
    public class CosmicArrowProjectile : ModProjectile
    {
      

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 32;
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            Projectile.aiStyle = 1; // Standard arrow AI
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Custom behavior: Add semi-homing effect
            int target = Projectile.FindClosestNPC(500f);
            if (target != -1)
            {
                NPC npc = Main.npc[target];
                Vector2 direction = npc.Center - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = (Projectile.velocity * 19 + direction * 12) / 20f;
            }

            // Optional: Add visual effects like shimmer
            Lighting.AddLight(Projectile.Center, 0.2f, 0.3f, 0.6f);
        }

  
    }
}