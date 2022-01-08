using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

// fire starts at 51 ends at 75
// total 90 frames

namespace GenshinImpactMod.Projectiles.ArmourSummons
{
    class Guoba: ModProjectile
    {
        #region Variables
        private int timer = 0;
        private int cycle = 0;



        private bool Stateidle = true;
        private bool Statefire = false;

        #endregion

        #region SetDefaults 
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            Main.projFrames[projectile.type] = 8;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.minion = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 320;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.damage = 27;
        }


        #endregion
        public override void AI()
        {
            Player player = new Player();




            if (++projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }

            if (player.direction == 1)
            {
                projectile.direction = 1;
            }
            else if (player.direction == -1)
            {
                projectile.direction = -1;
            }
            projectile.spriteDirection = projectile.direction;

            if (Stateidle)
            {
                timer++;
                if (timer >= 42)
                {
                    Stateidle = false;
                    Statefire = true;
                    timer = 0;
                    if (projectile.direction == 1)
                    {
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 0, ProjectileID.Flames, 25, 0, player.whoAmI);
                    }

                    if (projectile.direction == -1)
                    {
                        Projectile.NewProjectile(-projectile.position.X, -projectile.position.Y, -5, 0, ProjectileID.Flames, 25, 0, player.whoAmI);
                    }
                }
            }
            else if (Statefire)
            {
                timer++;

                if (timer > 22)
                {
                    Stateidle = true;
                    Statefire = false;
                    timer = 0;
                    cycle++;
                }
            }


            if (cycle > 4)
            {
                projectile.Kill();
            }


            projectile.velocity.X = 0;

        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
