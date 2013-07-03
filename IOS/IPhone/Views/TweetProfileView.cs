using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace HashBot
{
	public class TweetProfileView : UIScrollView
	{
		private UIImageView _userImageView;
		private UILabel _userNameLabel;
		private UILabel _sourseLabel;
		private UITextView _tweetTextView;
		private UIImageView _delimiterLine;
		private UILabel _createdLable;
		private UILabel _urlLable;

		private int _leftAndRigthOfsets;
		private int _topAndBottomOfsets;

		public TweetProfileView ()
		{
			this.AutosizesSubviews = true;
			this.AutoresizingMask = UIViewAutoresizing.All;
			UIColor backgroundColor = UIColor.FromPatternImage (UIImage.FromBundle("Images/Tweets/bg.png"));


			this.BackgroundColor = backgroundColor;

			_userImageView = new UIImageView ();
			_userImageView.BackgroundColor = backgroundColor;
			this.AddSubview (_userImageView);

			_userNameLabel = new UILabel ();

			_userNameLabel.BackgroundColor = backgroundColor;
			_userNameLabel.Font = Fonts.HelveticaNeueBold (16);
			_userNameLabel.TextColor = UIColor.FromRGB (0x44, 0x64, 0x8f);
			_userNameLabel.AutoresizingMask = UIViewAutoresizing.None;
			this.AddSubview (_userNameLabel);

			_sourseLabel = new UILabel ();

			_sourseLabel.BackgroundColor = backgroundColor;
			_sourseLabel.Font = Fonts.HelveticaNeueBold (12);
			_sourseLabel.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
			this.AddSubview (_sourseLabel);

			_tweetTextView = new UITextView ();

			_tweetTextView.BackgroundColor = backgroundColor;
			_tweetTextView.Font = Fonts.HelveticaNeue (12);
			_tweetTextView.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
			_tweetTextView.Editable = false;
			this.AddSubview (_tweetTextView);

			UIImage originalImage = UIImage.FromFile ("Images/Tweets/line.png");
			UIImage lineStretchableImage = ImageHelper.GetStretchableImage ("Images/Tweets/line.png", (int)(originalImage.Size.Width/2 -1), (int)(originalImage.Size.Height / 2));
			_delimiterLine = new UIImageView (lineStretchableImage);
			_delimiterLine.AutoresizingMask = UIViewAutoresizing.None;
			this.AddSubview (_delimiterLine);

			_createdLable = new UILabel ();

			_createdLable.BackgroundColor = backgroundColor;
			_createdLable.Font = Fonts.HelveticaNeue (10);
			_createdLable.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
			this.AddSubview (_createdLable);

			_urlLable = new UILabel ();

			_urlLable.BackgroundColor = backgroundColor;
			_urlLable.Font = Fonts.HelveticaNeue (10);
			_urlLable.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
			this.AddSubview (_urlLable);
		}

		public void BindTweet(Tweet tweet)
		{
			_userImageView.Image = ImageHelper.LoadImageFromUrl (tweet.user.profileImageUrl);
			_userNameLabel.Text = tweet.user.name;
			_sourseLabel.Text = tweet.source;
			_tweetTextView.Text = tweet.text;
			_createdLable.Text = String.Format ("{0:dd.MM.yyyy}", DateTime.Parse(tweet.createdAt));
			_urlLable.Text = "http://tweeter.com/" + tweet.user.screenName;
		}

		public override void LayoutSubviews ()
		{

			base.LayoutSubviews ();
			_leftAndRigthOfsets = (int)(this.Bounds.Width * 0.1);
			_topAndBottomOfsets = (int)(this.Bounds.Height * 0.1);

			float workWidth = this.Bounds.Width - _leftAndRigthOfsets * 2;

			_userImageView.Frame = new RectangleF (_leftAndRigthOfsets, _topAndBottomOfsets, _userImageView.Image.Size.Width, _userImageView.Image.Size.Height); 

			_userNameLabel.Bounds = new RectangleF (0, 0, workWidth - _leftAndRigthOfsets - _userImageView.Bounds.Width, 16);
			_userNameLabel.Center = new PointF (_userImageView.Frame.Right + _userNameLabel.Bounds.Width / 2 + _leftAndRigthOfsets, _userImageView.Frame.Bottom - _userImageView.Bounds.Height / 2 );

			_sourseLabel.Bounds = new RectangleF (0, 0, workWidth - _leftAndRigthOfsets  - _userImageView.Bounds.Width, 16);
			_sourseLabel.Center = new PointF (_userImageView.Frame.Right + _userNameLabel.Bounds.Width / 2 + _leftAndRigthOfsets, _userImageView.Frame.Bottom - 6 );


			_tweetTextView.Frame = new RectangleF (_leftAndRigthOfsets, _userImageView.Frame.Bottom + _topAndBottomOfsets, workWidth , 200);
			_tweetTextView.SizeToFit ();

			_delimiterLine.Frame = new RectangleF (_leftAndRigthOfsets, _tweetTextView.Frame.Bottom, 20, _delimiterLine.Image.Size.Height);

			_createdLable.Frame = new RectangleF (_leftAndRigthOfsets, _delimiterLine.Frame.Bottom + 10, workWidth, 10);
			_createdLable.SizeToFit ();

			_urlLable.Frame = new RectangleF (_createdLable.Frame.Right + 20, _delimiterLine.Frame.Bottom + 10, workWidth, 10);
			_urlLable.SizeToFit ();

			_delimiterLine.Frame = new RectangleF (_delimiterLine.Frame.Left, _delimiterLine.Frame.Top, _urlLable.Frame.Right - _createdLable.Frame.Left, _delimiterLine.Frame.Height);

		}

	}
}

