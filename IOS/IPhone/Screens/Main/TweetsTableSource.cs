using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace HashBot
{
	public class TweetsTableSource : UITableViewSource
	{
		List<Tweet> _tweets = new List<Tweet>();
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController _controller;

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tweets.Count;
		}

		public TweetsTableSource(UIViewController controller)
		{
			_controller = controller;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier) as TweetsTableCell;
			if (cell == null)
				cell = new TweetsTableCell (cellIdentifier);
			cell.UpdateCell (_tweets[indexPath.Row].user.name, 
			                 _tweets[indexPath.Row].text, 
			                 UIImage.FromFile("Images/Main/avatar.png"),
			                 DateTime.Parse (_tweets[indexPath.Row].createdAt ) );
			return cell;
		}
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_controller.NavigationController.PushViewController (new TweetProfileViewController (_tweets[indexPath.Row]) { HidesBottomBarWhenPushed = true } , true);
		}

		public void AddTweets(IEnumerable<Tweet> tweets)
		{
			_tweets.AddRange (tweets);
		}
	}
}

