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
			UIImage bgOriginalImage = UIImage.FromFile ("Images/Tweets/gb.png");
			UIImage bgStretchableImage = ImageHelper.GetStretchableImage ("Images/Tweets/gb.png", 0, 0);
			UIImageView _background = new UIImageView (bgStretchableImage);
			

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

