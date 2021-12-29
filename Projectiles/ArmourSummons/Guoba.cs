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
        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;
        private const int AI_Fire_Time_Slot = 2;
        private const int AI_Cycle_Slot = 3;

        private const int STATE_IDLE = 0;
        private const int STATE_FIRE = 1;
        #endregion
        #region Properties
        public float AI_State
        {
            get => projectile.ai[AI_State_Slot];
            set => projectile.ai[AI_State_Slot] = value;
        }

        public float AI_Timer
        {
            get => projectile.ai[AI_Timer_Slot];
            set => projectile.ai[AI_Timer_Slot] = value;
        }

        public float AI_Fire_Time
        {
            get => projectile.ai[AI_Fire_Time_Slot];
            set => projectile.ai[AI_Fire_Time_Slot] = value;
        }

        public float AI_Cycle
        {
            get => projectile.ai[AI_Cycle_Slot];
            set => projectile.ai[AI_Cycle_Slot] = value;
        }
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
            if (AI_State == STATE_IDLE)
            {
                AI_Timer = 0;
                AI_Timer++;
                if (AI_Timer > 20)
                {
                    AI_State = STATE_FIRE;
                    AI_Timer = 0;
                }
            }
            else if (AI_State == STATE_FIRE)
            {
                Projectile.NewProjectile();
                AI_Timer++;
                if(AI_Timer > 20)
                {
                    AI_State = STATE_IDLE;
                    AI_Timer = 0;
                    AI_Cycle++;
                }
            }

            if (AI_Cycle == 4)
            {
                projectile.Kill();
            }
        }

    }
}
