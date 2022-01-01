using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Projectiles.ArmourSummons
{
    class Pyronado : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            Main.projFrames[projectile.type] = /*Add frames*/;
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

            if (projectile.position.X == player.position.X && projectile.position.Y <= player.position.Y - 5)
            {
                projectile.velocity.Y++;
            }
            else if (projectile.position.X == player.position.X && projectile.position.Y >= player.position.Y + 5)
            {
                projectile.velocity.Y--;
            }
            else if (projectile.position.X >= player.position.X + 5 && projectile.position.Y == player.position.Y)
            {
                projectile.velocity.X--;
            }
            else if (projectile.position.X <= player.position.X - 5 && projectile.position.Y == player.position.Y)
            {
                projectile.velocity.X++;
            }
        }
    }
}
