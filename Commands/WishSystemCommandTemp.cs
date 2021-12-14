using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinImpactMod.UI;
using Terraria.ModLoader;

namespace GenshinImpactMod.Commands
{
    class WishSystemCommandTemp : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "wish";
        public override string Description => "e";
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            WishingSystem.Visible = true;
        }
    }
}
