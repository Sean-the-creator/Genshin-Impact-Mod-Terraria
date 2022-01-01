﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using GenshinImpactMod.UI;
using GenshinImpactMod.Characters;
using Microsoft.Xna.Framework;
using GenshinImpactMod.Projectiles.ArmourSummons;

namespace GenshinImpactMod
{
    class ModdedPlayer : ModPlayer
    {
        public Vector2 velocity = new Vector2(1, 1);

        #region Hotkeys
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GenshinImpactMod.ToggleWishingSystem.JustPressed)
            {
                WishingSystem.Visible = !WishingSystem.Visible;
            }

            if (GenshinImpactMod.ElementalSkill.JustPressed)
            {
                if (XianglingHelmet.isArmourSet)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, 0, 1, ModContent.ProjectileType<Guoba>(), 30, 0, player.whoAmI);
                }
            }
            if (GenshinImpactMod.ElementalBurst.JustPressed)
            {
                if (XianglingHelmet.isArmourSet)
                {
                    Projectile.NewProjectile(player.position.X - 5, player.position.Y + 5, 0, 5, /*add item*/, 30, 0, player.whoAmI);
                }
            }
        }
        #endregion
        #region Hunger System

        public int Saturation = 0;
        public bool CanEat = false;
        private int EatingTimer = 0;
        public override void PreUpdate()
        {
            EatingTimer++;
            if(EatingTimer>= 120)
            {
                if(Saturation > 0)
                {
                    Saturation--;
                }
            }
            if (Saturation >= 100)
            {
                CanEat = false;
            }
            else
            {
                CanEat = true;
            }
        }

        #endregion

        public int BlackCliffdefeatedOpponent = 0;
        private int BlackCliffcounter = 0;

        public int SkyriderGreatswordHit = 0;
        private int SkyriderGreatswordCounter = 0;
        private int SkyriderGreatswordDelay = 0;

        //uses timer variables and the last item to change wether the modifier should be true or not
        public bool ThrillingTalesOfDragonSlayersDmgModifier = false;
        private int ThrillingTalesOfDragonSlayersDelay = 0;
        private int ThrillingTalesOfDragonSlayersLastItem = 0;
        private int ThrillingTalesOfDragonSlayersTimeRemaining = 0;


        //establishes how many times the flute has hit someone out of 5
        public int fluteHitCount = 0;

        public int JadeSpearHits = 0;
        private int JadeSpearTimer = 0;
        private int JadeSpearDelay = 0;

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            

            SkyriderGreatswordCounter = 0;
            if (SkyriderGreatswordDelay <= 0)
            {
                SkyriderGreatswordHit += 1;
                SkyriderGreatswordDelay = 30;
                if (SkyriderGreatswordHit >= 4)
                {
                    SkyriderGreatswordHit = 4;
                }
            }

            //tests for if the last item that was used is equal to this item
            if (item.type != ThrillingTalesOfDragonSlayersLastItem)
            {
                ThrillingTalesOfDragonSlayersLastItem = item.type;
                if (ThrillingTalesOfDragonSlayersDelay == 0)
                {
                    //sets timers for the amount of time the item will do increased damage
                    ThrillingTalesOfDragonSlayersTimeRemaining = 600;
                    ThrillingTalesOfDragonSlayersDelay = 1200;
                }
            }

            //when the flute hit count reaches 5 it automatically resets to zero
            fluteHitCount++;
            if(fluteHitCount >= 5)
            {
                fluteHitCount = 0;
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (JadeSpearDelay >= 20)
            {
                JadeSpearTimer = 360;
                JadeSpearHits++;
                if (JadeSpearHits == 8)
                {
                    JadeSpearHits = 7;
                }
            }

            if (target.life <= 0)
            {
                BlackCliffdefeatedOpponent += 1;
                BlackCliffcounter = 0;
                if(BlackCliffdefeatedOpponent >= 3)
                {
                    BlackCliffdefeatedOpponent = 3;
                }
            }

            //tests for if the last item that was used is equal to this item
            if (proj.type != ThrillingTalesOfDragonSlayersLastItem)
            {
                ThrillingTalesOfDragonSlayersLastItem = proj.type;
                if (ThrillingTalesOfDragonSlayersDelay == 0)
                {
                    //sets timers for the amount of time the item will do increased damage
                    ThrillingTalesOfDragonSlayersTimeRemaining = 600;
                    ThrillingTalesOfDragonSlayersDelay = 1200;
                }
            }
        }
        public override void PostUpdate()
        {
            if(JadeSpearTimer > 0)
            {
                JadeSpearTimer--;
            }
            else
            {
                JadeSpearHits = 0;
            }
            if(JadeSpearDelay < 20)
            {
                JadeSpearDelay++;
            }

            SkyriderGreatswordCounter++;
            if (SkyriderGreatswordDelay > 0)
            {
                SkyriderGreatswordDelay--;
            }
            if(SkyriderGreatswordCounter >= 360)
            {
                SkyriderGreatswordCounter = 0;
                SkyriderGreatswordHit = 0;
            }

            BlackCliffcounter++;
            if(BlackCliffcounter >= 1800)
            {
                BlackCliffdefeatedOpponent = 0;
                BlackCliffcounter = 0;
            }

            //updates the item according to timers
            ThrillingTalesOfDragonSlayersDmgModifier = ThrillingTalesOfDragonSlayersTimeRemaining > 0;
            if(ThrillingTalesOfDragonSlayersTimeRemaining > 0)
            {
                ThrillingTalesOfDragonSlayersTimeRemaining--;
            }
            if(ThrillingTalesOfDragonSlayersDelay > 0)
            {
                ThrillingTalesOfDragonSlayersDelay--;
            }
        }
    }
}
