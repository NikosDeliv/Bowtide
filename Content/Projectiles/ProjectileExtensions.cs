using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bowtide.Content.Projectiles
{
    public static class ProjectileExtensions
    {
        public static int FindClosestNPC(this Projectile projectile, float maxDistance)
        {
            int target = -1;
            float distance = maxDistance;
            Vector2 center = projectile.Center;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy(projectile))
                {
                    float currentDistance = Vector2.Distance(center, npc.Center);
                    if (currentDistance < distance)
                    {
                        distance = currentDistance;
                        target = i;
                    }
                }
            }
            return target;
        }
    }
}