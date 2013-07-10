using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using HashBot.UI;

namespace HashBot
{
	namespace Logic
	{
		public class TweetsTableSource : UITableViewSource
		{

			private List<Tweet> _tweets = new List<Tweet> ();
			private NSString _cellIdentifier = new NSString ("TableCell");
			private UIImage _defaultImage = UIImage.FromFile ("Images/Main/avatar.png");

			public event Action<Tweet> RowSelectedEvent;

			public override int RowsInSection (UITableView tableview, int section)
			{
				return _tweets.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (_cellIdentifier) as TweetsTableCell;

				if (cell == null) // if there are no cells to reuse, create a new one
					cell = new TweetsTableCell (_cellIdentifier);

				var tweet = _tweets [indexPath.Row];
				DateTime created;
				DateTime.TryParse (tweet.createdAt, out created);

				cell.UpdateCell (tweet.user.name, tweet.text, created);
				cell.UserImage.ApplyImageFromUrlAsunc(tweet.user.profileImageUrl, _defaultImage);

				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				if (RowSelectedEvent != null)
					RowSelectedEvent (_tweets[indexPath.Row]);
			}

			public void AddTweets (List<Tweet> tweets)
			{
				_tweets.AddRange (tweets);
			}
		}
	}
}

