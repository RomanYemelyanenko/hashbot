using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public class MainScreanTabController : UITabBarController
	{
		private UIViewController twitterTab, dribbbleTab, appleTab, gihubTab;

		public MainScreanTabController () 
		{
			twitterTab = CreateController ("#Twitter","Images/TabBar/icon_twitter.png");
			dribbbleTab = CreateController ("#Dribbble","Images/TabBar/icon_dribbble.png");
			appleTab = CreateController ("#Apple","Images/TabBar/icon_apple.png");
			gihubTab = CreateController ("#GitHub","Images/TabBar/icon_github.png");

			var tabs = new UIViewController[] {
				twitterTab, dribbbleTab, appleTab, gihubTab
			};

			ViewControllers = tabs;
		}



		private UIViewController CreateController (string tabTitle, string tabImagePath)
		{
			var controller = new MainViewController (tabTitle);
			controller.TabBarItem.Image = UIImage.FromFile (tabImagePath);
			controller.View.BackgroundColor = UIColor.Green;

			var navController = new UINavigationController (controller);

			return navController;
		}
	}
}

