using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public class MainScreanTabController : UITabBarController
	{


		public MainScreanTabController () 
		{
			ApplicationOnlyTwitterAuthService authService = new ApplicationOnlyTwitterAuthService ( "tajGuj9oxo2J6dyIdOv3Mg",
			                                                                                   "Njx3rTnYNXxzJJMkyQPHynJ1tRx8PdHLXBIkp4", 
			                                                                                   "https://api.twitter.com/oauth2/token",
			                                                                                   "#Bot");

			TwitterSearcher searcher = new TwitterSearcher (authService, "https://api.twitter.com","1.1/search/tweets.json");

			ViewControllers = new UIViewController[] {
				CreateController ("#Twitter","Images/TabBar/icon_twitter.png", searcher),
				CreateController ("#Dribbble","Images/TabBar/icon_dribbble.png", searcher),
				CreateController ("#Apple","Images/TabBar/icon_apple.png", searcher),
				CreateController ("#GitHub","Images/TabBar/icon_github.png", searcher)
			};

			var titleAttributes = new UITextAttributes ();
			titleAttributes.Font = Fonts.HelveticaNeueBold (13);
			titleAttributes.TextColor = UIColor.FromRGB (255, 255, 255);
			this.TabBarItem.SetTitleTextAttributes (titleAttributes, UIControlState.Normal);
		}

		private UIViewController CreateController (string tabTitle, string tabImagePath, TwitterSearcher searcher)
		{


			var controller = new MainViewController (tabTitle, searcher);
			controller.TabBarItem.Image = UIImage.FromFile (tabImagePath);


			var navController = new UINavigationController (controller);

			return navController;
		}
	}
}

