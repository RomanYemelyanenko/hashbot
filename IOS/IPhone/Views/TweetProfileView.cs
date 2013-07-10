using System;
using MonoTouch.UIKit;
using System.Drawing;
using HashBot;

namespace HashBot
{
	namespace UI
	{
		public class TweetProfileView : UIScrollView
		{
			private UIImageView _userImage;
			private UILabel _userName;
			private UILabel _sourse;
			private UITextView _tweetText;
			private UIImageView _delimiterLine;
			private UILabel _created;
			private UILabel _url;
			private int _leftAndRigthOffsets;
			private int _topAndBottomOffsets;

			public TweetProfileView ()
			{
				InitView ();
				InitAvatar ();
				InitUserName ();
				InitSourceLable ();
				InitTweetText ();
				InitDelimiterLine ();
				InitCreatedAndUrl ();

			}

			private void InitView ()
			{
				AutosizesSubviews = true;
				AutoresizingMask = UIViewAutoresizing.All;
				UIColor backgroundColor = UIColor.FromPatternImage (UIImage.FromBundle("Images/Tweets/bg.png"));

				BackgroundColor = backgroundColor;
			}

			private void InitAvatar ()
			{
				_userImage = new UIImageView ();
				_userImage.BackgroundColor = BackgroundColor;
				AddSubview (_userImage);
			}

			private void InitUserName ()
			{
				_userName = new UILabel ();

				_userName.BackgroundColor = BackgroundColor;
				_userName.Font = Fonts.HelveticaNeueBold (16);
				_userName.TextColor = UIColor.FromRGB (0x44, 0x64, 0x8f);
				_userName.AutoresizingMask = UIViewAutoresizing.None;
				AddSubview (_userName);
			}

			private void InitSourceLable ()
			{
				_sourse = new UILabel ();

				_sourse.BackgroundColor = BackgroundColor;
				_sourse.Font = Fonts.HelveticaNeueBold (12);
				_sourse.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
				AddSubview (_sourse);
			}

			private void InitTweetText ()
			{
				_tweetText = new UITextView ();

				_tweetText.BackgroundColor = BackgroundColor;
				_tweetText.Font = Fonts.HelveticaNeue (12);
				_tweetText.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
				_tweetText.Editable = false;
				AddSubview (_tweetText);
			}

			private void InitDelimiterLine ()
			{
				_delimiterLine = new UIImageView ();
				_delimiterLine.SetStretchableImage ("Images/Tweets/line.png");

				_delimiterLine.AutoresizingMask = UIViewAutoresizing.None;
				AddSubview (_delimiterLine);
			}

			private void InitCreatedAndUrl ()
			{
				_created = new UILabel ();

				_created.BackgroundColor = BackgroundColor;
				_created.Font = Fonts.HelveticaNeue (10);
				_created.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
				AddSubview (_created);

				_url = new UILabel ();

				_url.BackgroundColor = BackgroundColor;
				_url.Font = Fonts.HelveticaNeue (10);
				_url.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
				AddSubview (_url);
			}

			public void BindTweet (Tweet tweet)
			{
				_userName.Text = tweet.user.name;
				_sourse.Text = tweet.source;
				_tweetText.Text = tweet.text;
				_created.Text = String.Format ("{0:dd.MM.yyyy}", DateTime.Parse (tweet.createdAt));
				_url.Text = "http://tweeter.com/" + tweet.user.screenName;
			}

			public override void LayoutSubviews ()
			{

				base.LayoutSubviews ();

				_leftAndRigthOffsets = (int)(Bounds.Width * 0.1);
				_topAndBottomOffsets = (int)(Bounds.Height * 0.1);

				float workWidth = Bounds.Width - _leftAndRigthOffsets * 2;


				_userImage.SetRoundedFrame (_leftAndRigthOffsets, 
				                           _topAndBottomOffsets, 
				                           _userImage.Image.Size.Width, 
				                           _userImage.Image.Size.Height);

				_userName.SetRoundedBounds (width: workWidth - _leftAndRigthOffsets - _userImage.Bounds.Width, 
				                           height: 16);

				var userNameCenter = new PointF ();
				userNameCenter.X = _userImage.Frame.Right + _userName.Bounds.Width / 2 + _leftAndRigthOffsets;
				userNameCenter.Y = _userImage.Frame.Bottom - _userImage.Bounds.Height / 2;
				_userName.SetRoundedCenter (userNameCenter);

				_sourse.SetRoundedBounds (width: workWidth - _leftAndRigthOffsets  - _userImage.Bounds.Width, 
				                         height: 16);

				var sourseCenter = new PointF ();
				sourseCenter.X = _userImage.Frame.Right + _userName.Bounds.Width / 2 + _leftAndRigthOffsets;
				sourseCenter.Y = _userImage.Frame.Bottom - 6;
				_sourse.SetRoundedCenter (sourseCenter);

				var tweetTextFrame = new RectangleF ();
				tweetTextFrame.X = _leftAndRigthOffsets;
				tweetTextFrame.Y = _userImage.Frame.Bottom + _topAndBottomOffsets;
				tweetTextFrame.Width = workWidth;
				tweetTextFrame.Height = 200;

				_tweetText.SetRoundedFrame (tweetTextFrame);

				_tweetText.SizeToFit ();

				_delimiterLine.SetRoundedFrame (_leftAndRigthOffsets, 
				                               _tweetText.Frame.Bottom, 
				                               20, 
				                               _delimiterLine.Image.Size.Height);

				_created.SetRoundedFrame (_leftAndRigthOffsets, 
				                         _delimiterLine.Frame.Bottom + 10, 
				                         workWidth, 
				                         10);
				_created.SizeToFit ();

				_url.SetRoundedFrame (_created.Frame.Right + 20, 
				                     _delimiterLine.Frame.Bottom + 10, 
				                     workWidth, 
				                     10);
				_url.SizeToFit ();

				_delimiterLine.SetRoundedFrame (_delimiterLine.Frame.Left, 
				                               _delimiterLine.Frame.Top, 
				                               _url.Frame.Right - _created.Frame.Left, 
				                               _delimiterLine.Frame.Height);

			}


		}
	}
}

