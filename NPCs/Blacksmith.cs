// one small issue with sprite however it is barely noticable

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
    class Blacksmith : ModNPC
    {
        int smithsAppentice = NPC.FindFirstNPC(ModContent.NPCType<SmithsApprentice>());
        public override string Texture => "GenshinImpactMod/NPCs/Blacksmith"; 

        public override bool Autoload(ref string name)
        {
            name = "Blacksmith";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blacksmith");
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
            npc.width = 24; 
            npc.height = 46; 
            npc.aiStyle = 7;
            npc.damage = 30; 
            npc.defense = 15;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss3 && smithsAppentice >= 0)
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
            return "Wagner";
        }


        /* NPC has dialogue for goblin tinkerer, arms dealer, smith's apprentice, and mechanic
         * 
         * 
         * 
         * 
         * for anyone reading this there will be something special with wagner and the mechanic
         */
        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                "Where in the world am I? This isn't Monsdadt!",
                "Come, you'll find no second rate items here at Schulz's Blacksmith, well unless the weapons in this world are awful...",
                "If you need assistance on finding ores just talk to me.",
                "If you can't afford my items then I recommend talking to my apprentice Schulz, if he's here",
            };

            int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            if (goblinTinkerer >= 0)
            {
                dialogue.Add("Is that a hillichurl, or a goblin either way he seems pretty smart.");
                dialogue.Add("That Tinkerer can do some really cool reforges I can only forge weapons not reforge them.");
            }

            int armsdealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (armsdealer >= 0 && smithsAppentice >= 0)
            {
                dialogue.Add("That puny " + Main.npc[armsdealer].GivenName + " thinks he can get away with anything like making me and my apprentice mad, don't show him any love");
            }

            if (smithsAppentice >= 0)
            {
                dialogue.Add("I was really happy to see my apprentice Schulz here, I thought I might've died or something.");
            }

            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            if (mechanic >= 0 && !NPC.downedMechBossAny && goblinTinkerer < 0)
            {
                dialogue.Add("Ah, a mechanic I see you have an engineer in this world");
            }

            if (mechanic >= 0 && !NPC.downedMechBossAny && goblinTinkerer >= 0)
            {
                dialogue.Add("2 engineers in one town, wow never thought of it.");
            }

            if (mechanic >= 0 && NPC.downedMechBossAny)
            {
                dialogue.Add(Main.npc[mechanic].GivenName + " was asking me if I can build something for her... she was talking about some sort of brain, skeleton, esophogas, and eye? I might help her");
            }
            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Ore locations";
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
                quote = "Here are the locations for crystal ore, just come back to me if you need anymore.";
                player.AddBuff(BuffID.Spelunker, 18000);
            }
            Main.npcChatText = quote;
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SilverSword>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<OldMercsPal>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SeasonedHuntersBow>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<PocketGrimoire>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<IronPoint>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.SpelunkerPotion);
            shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.ReaverShark);
            shop.item[nextSlot].shopCustomPrice = 1000000;
        }
    }
}
