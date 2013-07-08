using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace HashBot
{
	public class TweetsTableSource : UITableViewSource
	{

		private List<Tweet> _tweets = new List<Tweet>();
		private NSString _cellIdentifier = new NSString("TableCell");

		private static string _documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
		private static string _tmpPath = Path.Combine (_documents, "..", "tmp");

		public event Action<Tweet> RowSelectedEvent;

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tweets.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = new TweetsTableCell (_cellIdentifier);

			Tweet tweet = _tweets [indexPath.Row];
			DateTime created;
			DateTime.TryParse (tweet.createdAt, out created);

			cell.UpdateCell (tweet.user.name, tweet.text, created);

			BindImage (cell, tweet);

			return cell;
		}

		private void BindImage(TweetsTableCell tableCell, Tweet tweet)
		{
				ThreadPool.QueueUserWorkItem( (state) =>	 {

				 var backProfileImage = ImageHelper.LoadImageFromUrl (tweet.user.profileImageUrl);

					InvokeOnMainThread (() => 
                    {
						tableCell.BindImage (backProfileImage); 
					});
				});
		}


		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if(RowSelectedEvent != null)
				RowSelectedEvent(_tweets[indexPath.Row]);
		}

		public void AddTweets(List<Tweet> tweets)
		{
			_tweets.AddRange (tweets);
		}
	}
}

