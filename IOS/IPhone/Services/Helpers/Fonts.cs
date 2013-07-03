using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace HashBot
{
	public static class Fonts
	{
		public static UIFont HelveticaNeueBold(float fontSize)
		{
			return UIFont.FromName ("HelveticaNeue-Bold", fontSize);
		}

		public static UIFont HelveticaNeue(float fontSize)
		{
			return UIFont.FromName ("HelveticaNeue", fontSize);
		}
	}
}

