/* Another Batch of code copied off of example mod

I don't think I need to add editing lol*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework.Graphics;

namespace GenshinImpactMod.UI
{
    internal class UIHoverImageButton : UIImageButton
    {
		internal string HoverText;

		public UIHoverImageButton(Texture2D texture, string hoverText) : base(texture)
		{
			HoverText = hoverText;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			if (IsMouseHovering)
			{
				Main.hoverItemName = HoverText;
			}
		}
	}
}
