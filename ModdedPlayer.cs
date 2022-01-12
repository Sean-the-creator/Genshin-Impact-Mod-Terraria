using System;
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
        #region Variables
        #region CDs
        public Vector2 velocity = new Vector2(1, 1);
        private int XianglingSkillCooldown = 0;
        private int XianglingBurstCooldown = 0;
        #endregion

        #region Hotkeys
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GenshinImpactMod.ToggleWishingSystem.JustPressed)
            {
                WishingSystem.Visible = !WishingSystem.Visible;
            }

            #region Elemental Skills 
            if (GenshinImpactMod.ElementalSkill.JustPressed)
            {
                #region Xiangling Cooldowns
                if (XianglingHelmet.isArmourSet && XianglingSkillCooldown <=0)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, 0, 9, ModContent.ProjectileType<Guoba>(), 0, 0, player.whoAmI, 0, 0);
                    Main.PlaySound(SoundID.Item20);
                    XianglingSkillCooldown = 360;
                }
                #endregion
            }
            #endregion

            #region Elemental Bursts
            if (GenshinImpactMod.ElementalBurst.JustPressed)
            {
                #region Xiangling Cooldowns
                if (XianglingHelmet.isArmourSet && XianglingBurstCooldown <= 0)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, ModContent.ProjectileType<Pyronado>(), 30, 0, player.whoAmI);
                    Main.PlaySound(SoundID.Item20);
                    XianglingBurstCooldown = 900;
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region Hunger System

        public int Saturation = 0;
        public bool CanEat = true;
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

        #region Weapons
        #region Blackcliff Pole
        public int BlackCliffdefeatedOpponent = 0;
        private int BlackCliffcounter = 0;
        #endregion

        #region Skyrider Greatsword
        public int SkyriderGreatswordHit = 0;
        private int SkyriderGreatswordCounter = 0;
        private int SkyriderGreatswordDelay = 0;
        #endregion

        #region Thrilling Tales of Dragon SLayers
        //uses timer variables and the last item to change wether the modifier should be true or not
        public bool ThrillingTalesOfDragonSlayersDmgModifier = false;
        private int ThrillingTalesOfDragonSlayersDelay = 0;
        private int ThrillingTalesOfDragonSlayersLastItem = 0;
        private int ThrillingTalesOfDragonSlayersTimeRemaining = 0;
        #endregion

        #region Flute
        //establishes how many times the flute has hit someone out of 5
        public int fluteHitCount = 0;
        #endregion

        #region Jade Spear
        public int JadeSpearHits = 0;
        private int JadeSpearTimer = 0;
        private int JadeSpearDelay = 0;
        public float JadeSpearmult = 0f;
        #endregion
        #endregion
        #endregion

        #region On hit stuff
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            #region Weapons On hit NPC
            #region Skyrider Greatsword Code On hit
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
            #endregion

            #region Thrilling Tales Of Dragon Slayers Code On hit
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
            #endregion

            #region Flute Code on hit
            //when the flute hit count reaches 5 it automatically resets to zero
            fluteHitCount++;
            if(fluteHitCount >= 5)
            {
                fluteHitCount = 0;
            }
            #endregion
            #endregion
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            #region Weapons On hit With Proj
            #region Jade Spear Code On hit with Proj
            if (JadeSpearDelay >= 20)
            {
                JadeSpearTimer = 360;
                JadeSpearHits++;
                if (JadeSpearHits >= 8)
                {
                    JadeSpearHits = 7;
                }

                if (JadeSpearHits >= 7)
                {
                    JadeSpearmult = 1.12f;
                }
                else
                {
                    JadeSpearmult = 0f;
                }
            }
            #endregion

            #region Black Cliff Pole On hit With Proj
            if (target.life <= 0)
            {
                BlackCliffdefeatedOpponent += 1;
                BlackCliffcounter = 0;
                if(BlackCliffdefeatedOpponent >= 3)
                {
                    BlackCliffdefeatedOpponent = 3;
                }
            }
            #endregion

            #region Thrilling Tales of Dragon Slayers On hit with Proj
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
            #endregion
            #endregion
        }
        #endregion

        #region Timers and Cooldowns
        public override void PostUpdate()
        {
            #region Weapon Timers and stuff
            #region Jade Spear Timer and stuff
            if (JadeSpearTimer > 0)
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
            #endregion

            #region Skyrider Greatsword Timer and stuff
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
            #endregion

            #region Blackcliff Pole Timer and stuff
            BlackCliffcounter++;
            if(BlackCliffcounter >= 1800)
            {
                BlackCliffdefeatedOpponent = 0;
                BlackCliffcounter = 0;
            }
            #endregion

            #region Thrilling Tales of Dragon Slayers Timer and stuff
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
            #endregion
            #endregion

            #region Xiangling Cooldowns
            if (XianglingSkillCooldown > 0)
            {
                XianglingSkillCooldown--;
            }

            if (XianglingBurstCooldown > 0)
            {
                XianglingBurstCooldown--;
            }
            #endregion
        }
        #endregion
    }
}
