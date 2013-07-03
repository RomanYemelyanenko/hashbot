using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace HashBot
{
	public class TweetsTableSource : UITableViewSource
	{

		private List<Tweet> _tweets = new List<Tweet>();
		private NSString cellIdentifier = new NSString("TableCell");

		public delegate void EventHandler(object sender, RowSelectedEventArgs e);
		private event EventHandler _rowSelected;


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

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_rowSelected (this, new RowSelectedEventArgs (_tweets[indexPath.Row]));
		}

		public EventHandler RowSelectedEvent
		{
			get { return _rowSelected; }
			set { _rowSelected = value; }
		}


		public void AddTweets(IEnumerable<Tweet> tweets)
		{
			_tweets.AddRange (tweets);
		}
	}
}

