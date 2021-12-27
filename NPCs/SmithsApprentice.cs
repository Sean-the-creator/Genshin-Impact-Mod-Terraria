using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using GenshinImpactMod.Weapons;
using GenshinImpactMod.Weapons.Claymores;
using GenshinImpactMod.Weapons.Swords;
using GenshinImpactMod.Weapons.Spears;
using GenshinImpactMod.Weapons.Catalysts;
using GenshinImpactMod.Weapons.Bows;
using GenshinImpactMod.NPCs;
namespace GenshinImpactMod.NPCs
{
    [AutoloadHead]
    class SmithsApprentice : ModNPC
    {
        public override string Texture => "GenshinImpactMod/NPCs/SmithsApprentice";

        public override bool Autoload(ref string name)
        {
            name = "Smith's Apprentice";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smith's Apprentice");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 40;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedSlimeKing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override string TownNPCName()
        {
            return "Schulz";
        }

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                "My strength still fails me.",
                "Looking to buy a weapon? You should talk to Wagner ... wait he's not in this world.",
                "What do I sell here? Take your pick from this selection. Sadly Master isn't here, so the weapons won't be as strong but, they can still help you fight.",
                "Due to the fact that I'm an apprentice, my weapons aren't as good as Master's, but if you find them affordable I will gladly sell them to you.",
                "This world is much more different than Teyvat.",
                "The reason why the smithy at home is named Schulz's Blacksmith and not Wagner's Blacksmith is because I won a drinking contest against Master."
            };

            int armsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (armsDealer >= 0)
            {
                dialogue.Add("That arms dealer has never made his weapons, yet he has the audacity to sell them");
            }

            int blacksmith = NPC.FindFirstNPC(ModContent.NPCType<Blacksmith>());

            if (blacksmith >= 0 )
            {
                if (!NPC.downedMechBossAny)
                {
                    dialogue.Add("I'm so glad Master has returned. ");
                }

                dialogue.Add("Master creates some of the best weapon in teyvat, he even knows where important ores are located!");
            }

            if (blacksmith < 0)
            {
                dialogue.Add("I wish Master were here.");
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Tips on Ore Mining";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            string quote = "";
            Player player = Main.LocalPlayer;
            if (firstButton)
            {
                shop = true;
                return;
            }

            else
            {
                quote = "I recommend using heavy objects like the Waster Greatsword for mining ores, they destroy them faster then anything";
                player.AddBuff(BuffID.Mining, 18000);
            }
            Main.npcChatText = quote;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<DullBlade>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WasterGreatsword>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<HuntersBow>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ApprenticesNotes>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BeginnersProtector>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.MiningPotion);
            shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
        }


    }
}
