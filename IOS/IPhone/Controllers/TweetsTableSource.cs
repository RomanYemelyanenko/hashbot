using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashBot
{
	public class TweetsTableSource : UITableViewSource
	{

		private List<Tweet> _tweets = new List<Tweet>();
		private NSString _cellIdentifier = new NSString("TableCell");

		private static string _documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
		private static string _tmpPath = Path.Combine (_documents, "..", "tmp");

		private DirectoryInfo _tempDir = new DirectoryInfo (_tmpPath);

		public event Action<Tweet> RowSelectedEvent;

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tweets.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (_cellIdentifier) as TweetsTableCell;
			if (cell == null)
			{
				cell = new TweetsTableCell (_cellIdentifier);
			}

			Tweet tweet = _tweets [indexPath.Row];
			string imageId = tweet.user.id.ToString();
			string imageName = imageId + ".jpeg";

			var imageFile = _tempDir.GetFiles ().FirstOrDefault (file => file.Name == imageName);
			List<string> filesN = _tempDir.GetFiles ().Select (p=> p.Name).ToList ();

			var profileImage = new UIImage();

			if (imageFile != null)
			{
				var filename = Path.Combine (_tmpPath, imageName);
				profileImage = UIImage.FromFile (filename);
			}
			else 
			{
				profileImage = ImageHelper.LoadImageFromUrl (tweet.user.profileImageUrl);
				var _err = new NSError ();
				var filename = Path.Combine (_tmpPath, imageName);
				NSData imageData = profileImage.AsJPEG ();
				UIImage.LoadFromData (imageData).AsPNG ().Save (filename, NSDataWritingOptions.Atomic, out _err);
					
			}

			DateTime created;
			DateTime.TryParse (tweet.createdAt, out created);

			cell.UpdateCell (profileImage, tweet.user.name, tweet.text, created);
			//cell.BindImage (profileImage);

			return cell;
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

