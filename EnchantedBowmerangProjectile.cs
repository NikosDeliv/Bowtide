using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Bowtide.Content.Items.Weapons;

namespace Bowtide.Content.Projectiles.Ranged
{
    public class EnchantedBowmerangProjectile : ModProjectile
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

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Pink);
            Main.dust[dust].velocity *= 0.5f; // Slow trail
            Main.dust[dust].scale = 1.2f;
            Main.dust[dust].noGravity = true;

            Lighting.AddLight(Projectile.Center, 0.3f, 0.6f, 1f); 
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            Player player = Main.player[Projectile.owner];
            foreach (Item item in player.inventory)
                if (item.ModItem is EnchantedBowmerang enchantedbowmerang)
                {
                enchantedbowmerang.ResetBoomerang(); 
            }
        }

    }
}
