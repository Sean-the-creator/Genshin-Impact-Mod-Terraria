using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using GenshinImpactMod;

namespace GenshinImpactMod.Buffs
{
	//warning: the debuff is untested (cannot be tested without creating a method of applying it) - but should work : if you have problems talk to EatMySocks.jpg
    class Cryo : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cryo");
			Description.SetDefault("Affected by cryo affects");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			canBeCleared = true;
		}

		//used for calculating when damage ticks should happen
		int DmgCounter = 0;
		int NpcDmgCounter = 0;

        public override void Update(Terraria.Player player, ref int buffIndex)
        {
			ModdedPlayer p = player.GetModPlayer<ModdedPlayer>();
			//  ^ not necessary but may be used for combination of attacks!
			
			//this function is called every tick, so the player should get damaged by 6 damage a second
			player.moveSpeed -= 0.05f;
			if(DmgCounter == 1)
            {
				player.statLife -= 2;
            }
			DmgCounter++;
			if(DmgCounter >= 20)
            {
				DmgCounter = 0;
            }
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.stepSpeed -= 0.05f;
			if (NpcDmgCounter == 1)
			{
				npc.life -= 2;
			}
			NpcDmgCounter++;
			if (NpcDmgCounter >= 20)
			{
				NpcDmgCounter = 0;
			}
		}
    }
}
