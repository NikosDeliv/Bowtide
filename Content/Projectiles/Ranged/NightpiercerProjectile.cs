using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bowtide.Content.Projectiles.Ranged
{
    public class NightpiercerProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true; // Ensures each projectile has its own instance

        public bool applyShadowflame = false;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (applyShadowflame)
            {
                target.AddBuff(BuffID.ShadowFlame, 300); // Apply Shadowflame debuff for 5 seconds
            }
        }
    }
}