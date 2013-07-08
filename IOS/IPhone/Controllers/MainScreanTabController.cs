using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public class MainScreanTabController : UITabBarController
	{
		private const string _consumerKey = "tajGuj9oxo2J6dyIdOv3Mg";
		private const string _consumerSecret = "Njx3rTnYNXxzJJMkyQPHynJ1tRx8PdHLXBIkp4";
		private const string _requestTokenUrl = "https://api.twitter.com/oauth2/token";
		private const string _userAgent = "Bot";
		private const string _tweeterHostUrl = "https://api.twitter.com";
		private const string _tweeterRequestUrl = "1.1/search/tweets.json";


		public MainScreanTabController () 
		{
			var authService = new ApplicationOnlyTwitterAuthService (_consumerKey, _consumerSecret, _requestTokenUrl, _userAgent);

			var searcher = new TwitterSearcher (authService, _tweeterHostUrl, _tweeterRequestUrl);

			ViewControllers = new UIViewController[] {
				CreateController ("#Twitter","Images/TabBar/icon_twitter.png", searcher),
				CreateController ("#Dribbble","Images/TabBar/icon_dribbble.png", searcher),
				CreateController ("#Apple","Images/TabBar/icon_apple.png", searcher),
				CreateController ("#GitHub","Images/TabBar/icon_github.png", searcher)
			};

			var titleAttributes = new UITextAttributes ();
			titleAttributes.Font = Fonts.HelveticaNeueBold (13);
			titleAttributes.TextColor = UIColor.FromRGB (255, 255, 255);
			TabBarItem.SetTitleTextAttributes (titleAttributes, UIControlState.Normal);
		}

		private UIViewController CreateController (string tabTitle, string tabImagePath, TwitterSearcher searcher)
		{
			var controller = new MainViewController (tabTitle, searcher);
			controller.TabBarItem.Image = UIImage.FromFile (tabImagePath);

			return new UINavigationController (controller);
		}
	}
}

