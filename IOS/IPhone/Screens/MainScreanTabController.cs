using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public class MainScreanTabController : UITabBarController
	{
		public MainScreanTabController () 
		{
			ViewControllers = new UIViewController[] {
				CreateController ("#Twitter","Images/TabBar/icon_twitter.png"),
				CreateController ("#Dribbble","Images/TabBar/icon_dribbble.png"),
				CreateController ("#Apple","Images/TabBar/icon_apple.png"),
				CreateController ("#GitHub","Images/TabBar/icon_github.png")
			};
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

