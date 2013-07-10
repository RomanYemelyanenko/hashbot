using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;
using HashBot;
using HashBot.UI;

namespace HashBot
{
	namespace Logic
	{
		public class TweetProfileViewController : UIViewController
		{
			private TweetProfileView _view;

			public TweetProfileViewController ()
			{
				Title = "Твит";
				_view = new TweetProfileView ();
				_view.Frame = new RectangleF (0, 0, View.Frame.Width, View.Frame.Height);
				_view.AutoresizingMask = UIViewAutoresizing.All;
				View.AddSubview (_view);
			}

			public void BindTweet (Tweet tweet)
			{ 
				_view.BindTweet (tweet);

			}

			public override void ViewDidLoad ()
			{
				base.ViewDidLoad ();
			}
		}
	}
}

