using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace HashBot
{
	public static class ImageHelper
	{
		public static UIImage GetStretchableImage(string image,int leftCapWidth, int topCapHeight)
		{
				return UIImage.FromBundle (image).StretchableImage (leftCapWidth, topCapHeight);
		}

		public static UIImage LoadImageFromUrl(string weburl)
		{
			NSData imgdata = NSData.FromUrl(new NSUrl(weburl));
			if (imgdata != null) {
				return new UIImage (imgdata);
			}
			else {
				return new UIImage (new NSData());
			}
		}
	}
}

