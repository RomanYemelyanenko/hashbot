using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreGraphics;

namespace HashBot
{
	public static class Extension
	{
		public static RectangleF SetRoundedBounds(this UIView view, float x = 0, float y = 0, float width = 100, float height = 50)
		{
			return  view.Bounds = new RectangleF((float)Math.Round(x), (float)Math.Round(y), (float)Math.Round(width), (float)Math.Round(height));
		}

		public static RectangleF SetRoundedFrame(this UIView view, float x = 0, float y = 0, float width = 100, float height = 50)
		{
			return view.Frame = new RectangleF((float)Math.Round(x), (float)Math.Round(y), (float)Math.Round(width), (float)Math.Round(height));
		}

		public static RectangleF SetRoundedFrame(this UIView view, RectangleF frame)
		{
			return view.SetRoundedFrame (frame.X, frame.Y, frame.Width, frame.Height);
		}

		public static RectangleF SetRoundedFrame(this UIView view, PointF location, SizeF size)
		{
			return view.SetRoundedFrame (location.X, location.Y, size.Width, size.Height);
		}

		public static RectangleF SetRoundedFrame(this UIView view, float x, float y, SizeF size)
		{
			return view.SetRoundedFrame (x, y, size.Width, size.Height);
		}


		public static PointF SetRoundedCenter(this UIView view, PointF center)
		{
			return view.Center = new PointF ((float)Math.Round(center.X),(float)Math.Round(center.Y));
		}

		public static void SetStretchableImage(this UIButton button, string normalImagePath, string highlightedImagePath = "")
		{
			var normalImage = new UIImage (normalImagePath);
			var stretchableNormalImage = UIImage.FromBundle (normalImagePath).StretchableImage((int) (normalImage.Size.Width/2 - 1), 
			                                                                             (int)(normalImage.Size.Height/2 - 1));
			button.SetBackgroundImage (stretchableNormalImage, UIControlState.Normal);

			if (!String.IsNullOrEmpty (highlightedImagePath)) 
			{
				var highlightedImage = new UIImage (highlightedImagePath);
				var stretchableHighlightedImage = UIImage.FromBundle (highlightedImagePath).StretchableImage((int) (highlightedImage.Size.Width/2 - 1), 
				                                                                                             (int)(highlightedImage.Size.Height/2 - 1));

				button.SetBackgroundImage (stretchableHighlightedImage, UIControlState.Highlighted);
			}

		}

		public static void SetStretchableImage(this UIImageView view, string imagePath)
		{
			var normalImage = new UIImage (imagePath);
			var stretchableNormalImage = UIImage.FromBundle (imagePath).StretchableImage((int) (normalImage.Size.Width/2 - 1), 
			                                                                                   (int)(normalImage.Size.Height/2 - 1));
			view.Image = stretchableNormalImage;
		}

		public static void ApplyImageMask(this UIImageView view, string maskPath)
		{
			var mask = UIImage.FromBundle (maskPath).CGImage;
			var image = view.Image.CGImage;

			var maskImag = CGImage.CreateMask (mask.Width,
			                               mask.Height,
			                               mask.BitsPerComponent,
			                               mask.BitsPerPixel,
			                               mask.BytesPerRow,
			                               mask.DataProvider, null, false);

			view.Image = new UIImage (image.WithMask (maskImag));
		}

		public static void AppentImageFromUrl(this UIImageView view, string url)
		{

		}

	}
}

