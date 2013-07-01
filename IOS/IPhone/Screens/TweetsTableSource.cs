using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace HashBot
{
	public class TweetsTableSource : UITableViewSource
	{
		List<Tweet> _tweets;
		NSString cellIdentifier = new NSString("TableCell");


		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tweets.Count;
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

		public void AddTweets(IEnumerable<Tweet> tweets)
		{
			_tweets.AddRange (tweets);
		}

		public TweetsTableSource ()
		{
			_tweets = new List<Tweet>();
		}
	}
}

