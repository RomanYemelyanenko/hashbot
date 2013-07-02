using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;

namespace HashBot
{
	public class InfoViewController : UIViewController
	{

		public InfoViewController () : base ("InfoVievController", null)
		{
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
			View.AddSubview (new InfoSrolableResizebleView( new RectangleF(0,0, View.Bounds.Width, View.Bounds.Height), this));
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

