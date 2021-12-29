using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

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
            projectile.width = ;
            projectile.height = ;
            Main.projFrames[projectile.type] = 90;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.minion = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 320;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }
        #endregion
        public override void AI()
        {
            if (Stateidle)
            {
                timer++;
                if (timer > 20)
                {
                    Stateidle = false;
                    Statefire = true;
                    timer = 0;
                }
            }
            else if (Statefire)
            {
                timer++;
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.Flames, 25, 0);
                if (timer > 20)
                {
                    Stateidle = true;
                    Statefire = false;
                    cycle++;
                }
            }


            if (cycle > 4)
            {
                projectile.Kill();
            }
        }

    }
}
