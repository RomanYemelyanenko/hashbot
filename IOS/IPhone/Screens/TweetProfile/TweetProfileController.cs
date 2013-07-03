using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace HashBot
{
	public class TweetProfileViewController : UIViewController
	{

		public TweetProfileViewController ()
		{
			Title = "Твит";
		}

		public void BindTweet(Tweet tweet)
		{ 
			this.View = new TweetProfileView(tweet);
			//NavigationItem.LeftBarButtonItem.Title = "Твиты";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}
	

	}
}

