// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace HashBot
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		MonoTouch.UIKit.UINavigationBar _navigationBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView _tweetsTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _btnShowMore { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_navigationBar != null) {
				_navigationBar.Dispose ();
				_navigationBar = null;
			}

			if (_tweetsTable != null) {
				_tweetsTable.Dispose ();
				_tweetsTable = null;
			}

			if (_btnShowMore != null) {
				_btnShowMore.Dispose ();
				_btnShowMore = null;
			}
		}
	}
}
