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
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.damage = 27;
        }


        #endregion
        public override void AI()
        {
            Player player = new Player();
            if (Stateidle)
            {
                projectile.frame = (int)(timer / 5);
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
                projectile.frame = (int)(timer / 5) + 4;
                timer++;
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 0, ProjectileID.Flames, 25, 0, player.whoAmI);
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


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
