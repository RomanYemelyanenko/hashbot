using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public class TweetProfileView : UIScrollView
	{
		UIImageView _background;
		UIImageView _usrImageView;
		UILabel _userNameLabel;
		UILabel _sourseLabel;
		UITextView _tweetTextView;
		UIImageView _delimiterLine;
		UILabel _createdandUrlLable;

		public TweetProfileView ()
		{
			this.AutosizesSubviews = true;
			this.AutoresizingMask = UIViewAutoresizing.All;
			UIImage image = UIImage.FromFile ("Images/Tweets/bg.png");
			UIImageView _background = new UIImageView( ImageHelper.GetStretchableImage("Images/Tweets/bg.png", (int)(image.Size.Width/2 - 1),(int)(image.Size.Height / 2 -1)));

			_background.Frame = this.Frame;
			_background.AutoresizingMask = UIViewAutoresizing.All;

			this.AddSubview(_background);
			Console.WriteLine (_background.Image.Size);

			_usrImageView = new UIImageView ();
			_userNameLabel = new UILabel ();
			_sourseLabel = new UILabel ();
			_tweetTextView = new UITextView ();


			UIImage originalImage = UIImage.FromFile ("Images/Tweets/line.png");
			UIImage lineStretchableImage = ImageHelper.GetStretchableImage ("Images/Tweets/line.png", (int)(originalImage.Size.Width/2 -1), (int)(originalImage.Size.Height/2));
			_delimiterLine = new UIImageView (lineStretchableImage);
			_delimiterLine.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin;

			_createdandUrlLable = new UILabel ();
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

		}

	}
}

