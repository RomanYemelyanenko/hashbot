using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace HashBot
{
	public class TweetProfileViewController : UIViewController
	{
		private Tweet _tweet;


		public TweetProfileViewController ()
		{
			_tweet = new Tweet();
		}

		public void BindTweet(Tweet tweet)
		{
			_tweet = tweet;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View = new TweetProfileView();

//			View.AutosizesSubviews = true;
//			View.BackgroundColor = UIColor.FromRGB(235,235,235);
//
//			UIView headView = new UIView (new RectangleF(0,0, View.Bounds.Width, View.Bounds.Height/3));
//			headView.AutoresizingMask = UIViewAutoresizing.All;
//
//
//			UIImage userImage = ImageHelper.LoadImageFromUrl (_tweet.user.profileImageUrlHttps);
//
//			UIImageView userImageView = new UIImageView (userImage);
//			userImageView.Frame = new RectangleF (30, 30, userImage.Size.Width, userImage.Size.Height);
//			userImageView.AutoresizingMask = UIViewAutoresizing.None; //UIViewAutoresizing.FlexibleHeight ^ UIViewAutoresizing.FlexibleHeight;
//
//
//			headView.AddSubview (userImageView);
//
//			UILabel userNameView = new UILabel ();
//			userNameView.Frame = new RectangleF (
//				userImageView.Frame.Right + 30,
//				userImageView.Frame.Top,
//				View.Bounds.Width - userImageView.Frame.Right,
//				32);
//
//			userNameView.BackgroundColor = UIColor.FromRGB(235,235,235);
//			userNameView.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin;
//			userNameView.Text = _tweet.user.name;
//			headView.AddSubview (userNameView);
//
//
//			UILabel sourceTextViex = new UILabel ();
//			sourceTextViex.Frame = new RectangleF (
//				userNameView.Frame.Left,
//				userNameView.Frame.Bottom,
//				userNameView.Frame.Width,
//				userNameView.Frame.Height);
//
//			sourceTextViex.BackgroundColor = UIColor.FromRGB(235,235,235);
//			sourceTextViex.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin;
//			sourceTextViex.Text = _tweet.source;
//
//			headView.AddSubview (sourceTextViex);
//			View.AddSubview (headView);
//
//			UITextView tweetText = new UITextView (new RectangleF(
//				30,
//				userImageView.Frame.Bottom + 30,
//				View.Bounds.Width - 30*2,
//				View.Bounds.Height / 3
//				));
//			tweetText.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleBottomMargin;
//
//			tweetText.Text = _tweet.text;
//			tweetText.BackgroundColor = UIColor.FromRGB(235,235,235);
//			tweetText.Editable = false;
//			View.AddSubview (tweetText);
//
//			UIImage originalImage = UIImage.FromFile ("Images/Tweets/line@2x.png");
//			UIImage lineStretchableImage = ImageHelper.GetStretchableImage ("Images/Tweets/line@2x.png", (int)(originalImage.Size.Width/2 -1), (int)(originalImage.Size.Height/2));
//
//			UIImageView line = new UIImageView (lineStretchableImage);
//			line.Frame = new RectangleF(
//				30,
//				tweetText.Frame.Bottom,
//				View.Bounds.Width - 30 * 2,
//				originalImage.Size.Height);
//
//			line.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
//	
//
//			View.AddSubview (line);
		}
	

	}
}

