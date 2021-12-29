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

        }

    }
}
