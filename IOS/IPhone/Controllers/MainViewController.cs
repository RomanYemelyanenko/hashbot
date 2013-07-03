using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

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
		private TweetProfileViewController _tweetViewController;

		static MainViewController()
		{
			_loadAlertView = new UIAlertView ("HashBot", "Загрузка данных...", null, null, null);
			UIActivityIndicatorView spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White);
			_loadAlertView.Presented += (object sender, EventArgs e) => {
				spinner.Center = new PointF(_loadAlertView.Bounds.Width / 2, _loadAlertView.Frame.Height / 2 + 10);
			};


			spinner.StartAnimating ();

			_loadAlertView.AddSubview (spinner);
		}

		public MainViewController (string hashTag, TwitterSearcher searcher) : base ("MainViewController", null)
		{
			_hashTag = hashTag;
			_searcher = searcher;
			Title = hashTag;

			_tweetViewController = new TweetProfileViewController () { HidesBottomBarWhenPushed = true };
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
			_tweetsTable.Source = _tableSource = new TweetsTableSource ();

			_tableSource.RowSelectedEvent += (sender,e) => {
				_tweetViewController.BindTweet (e.Tweet); 
				this.NavigationController.PushViewController ( _tweetViewController , true);
			};

			btnLoadMore.TouchUpInside += OnLoadTweets;
			OnLoadTweets (new object(), new EventArgs ());

			var titleAttributes = new UITextAttributes ();
			titleAttributes.Font = Fonts.HelveticaNeueBold (10);
			titleAttributes.TextColor = UIColor.FromRGB (255, 255, 255);
			TabBarItem.SetTitleTextAttributes (titleAttributes, UIControlState.Normal);

			NavigationItem.SetRightBarButtonItem( new UIBarButtonItem ("Инфо", UIBarButtonItemStyle.Plain,
			                                                           (sender,args) => {
				NavigationController.PushViewController (new InfoViewController () { HidesBottomBarWhenPushed = true }, true);
			}) , true);


			var infoAttributes = new UITextAttributes ();
			infoAttributes.Font = Fonts.HelveticaNeueBold (12);
			infoAttributes.TextColor = UIColor.FromRGB (255, 255, 255);
			infoAttributes.TextShadowColor = UIColor.FromRGB (0, 0, 0);
			infoAttributes.TextShadowOffset = new UIOffset (0,2);

			NavigationItem.RightBarButtonItem.SetTitleTextAttributes (infoAttributes, UIControlState.Normal);
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

