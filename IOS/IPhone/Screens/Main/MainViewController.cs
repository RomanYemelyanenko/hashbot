using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
using System.Collections.Generic;

namespace HashBot
{

	public partial class MainViewController : UIViewController
	{
		private string _hashTag;
		private readonly TwitterSearcher _searcher;
		private int _currentPage;
		private int _tweetsPerPage = 15;
		private TweetsTableSource _tableSource;
		private static UIAlertView _loadAlertView;


		static MainViewController()
		{
			UIActivityIndicatorView spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White);
			_loadAlertView = new UIAlertView ("Загрузка", "!!!!!!!!", null, null, null);
			_loadAlertView.AddSubview (spinner);
		}

		public MainViewController (string hashTag, TwitterSearcher searcher) : base ("MainViewController", null)
		{
			_hashTag = hashTag;
			_searcher = searcher;
			Title = hashTag;
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
			btnLoadMore.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin;
			_tweetsTable.Source = _tableSource = new TweetsTableSource (this);


			btnLoadMore.TouchUpInside += OnLoadTweets;
			OnLoadTweets (new object(), new EventArgs ());

			NavigationItem.SetRightBarButtonItem( new UIBarButtonItem("Инфо", UIBarButtonItemStyle.Plain,
			                                                          (sender,args) => {
				NavigationController.PushViewController (new InfoViewController () { HidesBottomBarWhenPushed = true } , true);
			}), true);


		}

		void OnLoadTweets(object sender, EventArgs e)
		{
			lock(_loadAlertView)
			{
				if(!_loadAlertView.Visible)
					_loadAlertView.Show ();
			}

			_searcher.SearchAsync (_hashTag, _tweetsPerPage, LoadTweets);
			// нет перегрузки SearchAsync с пейджингом
			_tweetsPerPage += 15;
		}

		void LoadTweets(Error error, List<Tweet> tweets)
		{
			if(error == null)
			{
				InvokeOnMainThread(() => {
					_tableSource.AddTweets(tweets);
					_tweetsTable.ReloadData();
					_loadAlertView.DismissWithClickedButtonIndex (0, true);
				});
			}
		}
	}
}

