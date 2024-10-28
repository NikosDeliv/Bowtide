using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bowtide.Content.Projectiles.Ranged
{
    public class SkywardensBlessing : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10; // Number of frames the trail is visible
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 32;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.light = 0.5f; // Light emitted by the projectile
            Projectile.extraUpdates = 1; // Makes the projectile move smoothly
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void AI()
        {
            // Add light based on the projectile position
            Lighting.AddLight(Projectile.position, 0.0f, 0.6f, 0.9f); // Cyan light

            // Spawn trail copies at intervals
            if (Projectile.timeLeft % 5 == 0) // Controls frequency of trail copies
            {
                Vector2 trailPosition = Projectile.position + new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-2, 3));

                // Create a smaller version of the main projectile as a trail
                Projectile trail = Projectile.NewProjectileDirect(
                    Projectile.GetSource_FromThis(),
                    trailPosition,
                    Projectile.velocity * 0.9f, // Slightly slower than main projectile
                    Projectile.type,
                    Projectile.damage / 2, // Lower damage for the trail projectiles
                    Projectile.knockBack * 0.5f,
                    Projectile.owner
                );

                // Set properties for the trail effect
                trail.scale = Projectile.scale * 0.6f; // Make the trail projectile smaller
                trail.alpha = 150; // Partially transparent
                trail.timeLeft = 10; // Short lifespan for trail effect
                trail.penetrate = -1; // No penetration
                trail.tileCollide = false; // Trail copies should phase through blocks

                // Optionally adjust appearance for the trail
                trail.light = 0.3f; // Slightly less light for the trail
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Additional effects on hit, such as a small explosion or more particles
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, DustID.Electric);
                dust.velocity *= 1.5f;
                dust.scale = 1.5f;
                dust.noGravity = true;
            }
        }
    }
}