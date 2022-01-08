using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;

namespace GenshinImpactMod.Projectiles.ArmourSummons
{
    class Pyronado : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            Main.projFrames[projectile.type] = 4;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.minion = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.damage = 27;
        }

        public override void AI()
        {
            Player player = new Player();

            Random random = new Random();

            projectile.Center = Main.player[projectile.owner].Center + new Vector2(0f, 70).RotatedBy(MathHelper.ToRadians(projectile.ai[0]));
            projectile.ai[0] += 5;

            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }

            for (int x = 0; x < 10; x++) { int dust = Dust.NewDust(projectile.position, projectile.height, projectile.width, DustID.Fire, random.Next(-3, 3), random.Next(-3, 3)); }
        }
    }
}
