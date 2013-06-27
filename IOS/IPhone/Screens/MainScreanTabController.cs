using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public class MainScreanTabController : UITabBarController
	{
		UIViewController twitterTab, dribbbleTab, appleTab, gihubTab;

		public MainScreanTabController () 
		{
			twitterTab = new MainViewController("#Twitter");
			twitterTab.TabBarItem.Image = UIImage.FromFile ("Images/TabBar/icon_twitter.png");
			twitterTab.Title = "#Twitter";

			twitterTab.View.BackgroundColor = UIColor.Green;

			dribbbleTab = new MainViewController("#Dribbble");
			dribbbleTab.TabBarItem.Image = UIImage.FromFile ("Images/TabBar/icon_dribbble.png");
			dribbbleTab.Title = "#Dribbble";
			dribbbleTab.View.BackgroundColor = UIColor.Orange;

			appleTab = new MainViewController("#Apple");
			appleTab.TabBarItem.Image = UIImage.FromFile ("Images/TabBar/icon_apple.png");
			appleTab.Title = "#Apple";
			appleTab.View.BackgroundColor = UIColor.Red;

			gihubTab = new MainViewController("#GitHub");
			gihubTab.TabBarItem.Image = UIImage.FromFile ("Images/TabBar/icon_github.png");
			gihubTab.Title = "#GitHub";
			gihubTab.View.BackgroundColor = UIColor.Brown;

			var tabs = new UIViewController[] {
				twitterTab, dribbbleTab, appleTab, gihubTab
			};

			ViewControllers = tabs;
		}

	}
}

