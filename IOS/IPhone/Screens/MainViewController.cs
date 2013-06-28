using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HashBot
{
	public partial class MainViewController : UIViewController
	{
		private string _hashTag;
		private readonly TwitterSearcher _searcher;
		private int _currentPage;
		private int _tweetsPerPage = 15;

//		searcher.SearchAsync("Name", 20, (error, tweetList ) => { 
//
//		} );


		public MainViewController (string hashTag, TwitterSearcher searcher) : base ("MainViewController", null)
		{
			_hashTag = hashTag;
			_searcher = searcher;
			Title = hashTag;


		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var btnLoadMore = new UIButton (UIButtonType.RoundedRect);
			btnLoadMore.Frame = new RectangleF (10, 10, 300, 44);
			btnLoadMore.SetTitle ("Показать еще", UIControlState.Normal);

			var footer = new UIView (new RectangleF (0, 0, 10, 50)); 
			footer.Frame = new RectangleF (0, 0, ContentSizeForViewInPopover.Width, 64);
			footer.AutoresizingMask = new UIViewAutoresizing ();
			footer.AddSubview (btnLoadMore);

			_tweetsTable.TableFooterView = footer;
			//footer.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

			btnLoadMore.TouchUpInside += (sender, e) => {
				_searcher.SearchAsync(_hashTag, 15,  (error, tweets) => {

					if(error == null)
					{
						InvokeOnMainThread(() => {
							_tweetsTable.Source = new TweetsTableSource(tweets.ToArray());
							_tweetsTable.ReloadData();
						});
					}
				});
			};

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

