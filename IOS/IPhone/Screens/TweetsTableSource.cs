using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace HashBot
{
	public class TweetsTableSource : UITableViewSource
	{
		Tweet[] _tweets;
		NSString cellIdentifier = new NSString("TableCell");

		public TweetsTableSource (Tweet[] tweets)
		{
			_tweets = tweets;
		}
		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tweets.Length;
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

		public TweetsTableSource ()
		{
			_tweets = new Tweet[] { };
		}
	}
}

