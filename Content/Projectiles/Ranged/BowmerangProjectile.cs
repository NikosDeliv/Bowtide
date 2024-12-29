using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Bowtide.Content.Items.Weapons;

namespace Bowtide.Content.Projectiles.Ranged
{
    public class BowmerangProjectile : ModProjectile
    {
       
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1; 
            Projectile.timeLeft = 600; 
            Projectile.aiStyle = 3; 
            Projectile.tileCollide = true; 
        }



        public override void Kill(int timeLeft)
        {
            // Play a sound when the boomerang returns or is destroyed
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            // Get the player holding the Bowmerang item
            Player player = Main.player[Projectile.owner];
            foreach (Item item in player.inventory)
            if (item.ModItem is Bowmerang bowmerang)
            {
                bowmerang.ResetBoomerang(); // Reset boomerangActive flag
            }
        }

    }
}
