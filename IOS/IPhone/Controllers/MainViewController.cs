using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HashBot.UI;
using HashBot.Logic;

namespace HashBot
{
	public partial class MainViewController : UIViewController
	{
		private string _hashTag;
		private readonly TwitterSearcher _searcher;
		private int _currentPage;
		private int _tweetsPerPage = 15;
		private TweetsTableSource _tableSource;
		private UIAlertView _loadAlertView;
		private TweetProfileViewController _tweetViewController;

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

			InitTableFooter ();
			InitTableSource ();

			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem ("Инфо", UIBarButtonItemStyle.Plain,
			                                                           (sender,args) => {
				NavigationController.PushViewController (new InfoViewController () { HidesBottomBarWhenPushed = true }, true);
			}), true);

			InitTabBarItemsStyle ();
			InitInfoButtonStyle ();

			OnLoadTweets (new object(), new EventArgs ());
		}

		private void InitTableFooter ()
		{
			var btnLoadMore = new UIButton (UIButtonType.RoundedRect);
			btnLoadMore.Frame = new RectangleF (10, 10, 300, 44);
			btnLoadMore.SetTitle ("Показать еще", UIControlState.Normal);

			var footer = new UIView (new RectangleF (0, 0, 10, 50)); 
			footer.Frame = new RectangleF (0, 0, ContentSizeForViewInPopover.Width, 64);
			footer.AutoresizingMask = new UIViewAutoresizing ();
			footer.AddSubview (btnLoadMore);

			_tweetsTable.TableFooterView = footer;

			btnLoadMore.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin;
			btnLoadMore.TouchUpInside += OnLoadTweets;
		}

		private void InitTableSource ()
		{
			_tweetsTable.Source = _tableSource = new TweetsTableSource ();

			_tableSource.RowSelectedEvent += (Tweet) => {
				_tweetViewController.BindTweet (Tweet); 
				NavigationController.PushViewController (_tweetViewController, true);
			};
		}

		private void InitTabBarItemsStyle ()
		{
			var titleAttributes = new UITextAttributes ();
			titleAttributes.Font = Fonts.HelveticaNeueBold (10);
			titleAttributes.TextColor = UIColor.FromRGB (255, 255, 255);
			TabBarItem.SetTitleTextAttributes (titleAttributes, UIControlState.Normal);
		}

		private void InitInfoButtonStyle ()
		{
			var infoAttributes = new UITextAttributes ();
			infoAttributes.Font = Fonts.HelveticaNeueBold (12);
			infoAttributes.TextColor = UIColor.FromRGB (255, 255, 255);
			infoAttributes.TextShadowColor = UIColor.FromRGB (0, 0, 0);
			infoAttributes.TextShadowOffset = new UIOffset (0, 2);

			NavigationItem.RightBarButtonItem.SetTitleTextAttributes (infoAttributes, UIControlState.Normal);
		}

		private void OnLoadTweets (object sender, EventArgs e)
		{
			EnsureAlertView ();

			try {
				_searcher.SearchAsync (_hashTag, _tweetsPerPage, LoadTweets);
				// нет перегрузки SearchAsync с пейджингом
				_tweetsPerPage += 15;
			} catch (Exception ex) {
				UIAlertView noInternetConnectAlert = new UIAlertView ("Ошибка", ex.Message, null, null, null);
				noInternetConnectAlert.Show ();
			}
		}

		private void EnsureAlertView ()
		{
			if (_loadAlertView == null) {
				_loadAlertView = new UIAlertView ("HashBot", "Загрузка данных...", null, null, null);
				_loadAlertView.Presented += (object sender, EventArgs e) => {
					var alert = sender as UIAlertView;

					var spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White);
					spinner.Center = new PointF (_loadAlertView.Bounds.Width / 2, _loadAlertView.Frame.Height / 2 + 10);
					alert.AddSubview (spinner);
					spinner.StartAnimating ();
				};
			}
			if (!_loadAlertView.Visible)
				_loadAlertView.Show ();
		}

		private void LoadTweets (Error error, List<Tweet> tweets)
		{
			if (error == null) {
				InvokeOnMainThread (() => {
					_tableSource.AddTweets(tweets);
					_tweetsTable.ReloadData();
					_loadAlertView.DismissWithClickedButtonIndex (0, true);
				});
			} else {
				InvokeOnMainThread (() => {
				var alert = new UIAlertView ("Ошибка", error.Message, null, null, null);
				alert.Show ();
				});
			}
		}
	}
}

