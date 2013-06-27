using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HashBot
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			ApplicationOnlyTwitterAuthService service = new ApplicationOnlyTwitterAuthService ( "tajGuj9oxo2J6dyIdOv3Mg",
			                                                                                   "Njx3rTnYNXxzJJMkyQPHynJ1tRx8PdHLXBIkp4", 
			                                                                                   "https://api.twitter.com/oauth2/token",
			                                                                                   "#Bot");

			TwitterSearcher searcher = new TwitterSearcher (service, "https://api.twitter.com","1.1/search/tweets.json");

			searcher.SearchAsync("Name", 20, (error, tweetList ) => { 

			} );

			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");

		}
	}
}
