using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace HashBot
{
	public static class ImageHelper
	{
		public static UIImage GetStretchableImage(string image,int leftCapWidth, int topCapHeight)
		{
			UIImage originalImage = new UIImage (image);
			UIImage resultImage = UIImage.FromBundle (image).StretchableImage (leftCapWidth, topCapHeight);

			return resultImage;
		}

		public static UIImage LoadImageFromUrl(string weburl)
		{
			NSUrl nsUrl = new NSUrl(weburl);
			NSData imgdata = NSData.FromUrl(nsUrl);
			return new UIImage(imgdata);
		}
	}
}

