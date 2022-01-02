using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace GenshinImpactMod.Projectiles.ArmourSummons
{
    class Pyronado : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            Main.projFrames[projectile.type] = 5;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.minion = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 320;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.damage = 27;
        }

        public override void AI()
        {
            Player player = new Player();

            projectile.Center = Main.player[projectile.owner].Center + new Vector2(0f, 70).RotatedBy(MathHelper.ToRadians(projectile.ai[0]));
            projectile.ai[0] += 5;
        }
    }
}
