using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;

namespace HashBot
{
	public class InfoViewController : UIViewController
	{
		private InfoSrolableResizebleView _view;

		public InfoViewController () 
		{
			Title = "Инфо";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.AddSubview (this.InfoView);
		}

		private InfoSrolableResizebleView InfoView
		{
			get {
				if (_view == null) {

					_view = new InfoSrolableResizebleView (new RectangleF(0,0, View.Bounds.Width, View.Bounds.Height), this);

					_view.Call.TouchUpInside += (sender, e) => { 
						UIApplication.SharedApplication.OpenUrl (new NSUrl ("tel:8-812-309-3879"));
					};

					_view.SendMessage.TouchUpInside += SendMessage;
				}
				return _view;
			}

		}

		private void SendMessage(object sender, EventArgs e)
		{
			if (MFMailComposeViewController.CanSendMail) {
				var mailController = new MFMailComposeViewController ();
				mailController.SetToRecipients (new string[] { "hello@touchin.ru" });
				mailController.Finished += (finishSender, finishE) => { finishE.Controller.DismissViewController (true, null); };
				this.PresentViewController (mailController, true, null);
			}

		}
	}
}

