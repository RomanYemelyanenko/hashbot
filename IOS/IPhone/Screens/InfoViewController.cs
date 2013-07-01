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

		public static UIImage GetStretchableImage(string image,int leftCapWidth, int topCapHeight)
		{
			UIImage originalImage = new UIImage (image);
			Console.WriteLine (originalImage.Size);

			UIImage resultImage = UIImage.FromBundle (image).StretchableImage (leftCapWidth, topCapHeight);
			Console.WriteLine (resultImage.Size);

			return resultImage;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
			UIImage logoImage = new UIImage ("Images/Info/logo.png");

			UIImage callImage = new UIImage ("Images/Info/icon_phone@2x.png");
			UIImage mailImage = new UIImage ("Images/Info/icon_mail@2x.png");

			UIImage originalNormalImage = new UIImage ("Images/Info/button.png");
			UIImage originalHighlightedImage = new UIImage ("Images/Info/button_pressed.png");

			SizeF btnSize = new SizeF (View.Bounds.Width/2, originalNormalImage.Size.Height);
			PointF btnLocation = new PointF (0, View.Bounds.Bottom - btnSize.Height);

			UIImage backgroundNormalImage = GetStretchableImage ("Images/Info/button.png", (int) (originalNormalImage.Size.Width/2 - 1), (int)(originalNormalImage.Size.Height/2 - 1)); 
			UIImage backgroundHighlightedImage = GetStretchableImage ("Images/Info/button_pressed.png", (int) (originalHighlightedImage.Size.Width/2 - 1), (int)(originalHighlightedImage.Size.Height/2 - 1));


			UIImageView logoView = new UIImageView ( logoImage);
			logoView.AutoresizingMask = UIViewAutoresizing.All ^ UIViewAutoresizing.FlexibleWidth;
			logoView.Frame = new RectangleF (new PointF(View.Bounds.Width/2 - logoImage.Size.Width/2, 10), logoImage.Size);
			View.AddSubview (logoView);

			UITextView text = new UITextView (new RectangleF(0, 
			                                                 logoView.Bounds.Bottom + 30 ,
			                                                 View.Bounds.Width, 
			                                                 View.Bounds.Height - logoView.Bounds.Bottom));// View.Bounds.Height-logoImage.Size.Height - btnBackgroundImage.Size.Height ));
			text.Editable = false;

			text.Text = "Нам не стыдно за выпускаемые продукты, все они сделаны с вниманием к деталям. Пользователи это ценят, многие наши приложения попадают в топы AppStore и получают высокие оценки. \n\nМы любим своих заказчиков и решаем их задачи. На письма и телефон отвечаем быстро, по праздникам и выходным, делаем работу в срок и никуда не пропадаем.\nЗакажите разработку сейчас! ";
			text.AutoresizingMask = UIViewAutoresizing.All;
			View.AddSubview (text);

			UIButton btnCall = new UIButton (UIButtonType.RoundedRect);
			btnCall.Frame = new RectangleF (btnLocation, btnSize);

			btnCall.AutoresizingMask = UIViewAutoresizing.All ^ UIViewAutoresizing.FlexibleHeight;
			btnCall.SetImage (callImage, UIControlState.Normal);
			btnCall.SetBackgroundImage (backgroundNormalImage, UIControlState.Normal);
			btnCall.SetBackgroundImage (backgroundHighlightedImage, UIControlState.Highlighted);

			btnLocation = new PointF (btnLocation.X + View.Bounds.Width/2, btnLocation.Y);
			
			UIButton btnSendMessage = new UIButton (UIButtonType.RoundedRect);
			btnSendMessage.Frame = new RectangleF (btnLocation, btnSize);
			btnSendMessage.AutoresizingMask = UIViewAutoresizing.All ^ UIViewAutoresizing.FlexibleHeight ;
			btnSendMessage.SetImage (mailImage, UIControlState.Normal);
			btnSendMessage.SetBackgroundImage (backgroundNormalImage, UIControlState.Normal);
			btnSendMessage.SetBackgroundImage (backgroundHighlightedImage, UIControlState.Highlighted);

			btnCall.TouchUpInside += (sender, e) => { 
				//var device = UIDevice.CurrentDevice;
				UIApplication.SharedApplication.OpenUrl (new NSUrl ("tel:8-812-309-3879"));
			};

			btnSendMessage.TouchUpInside += (sender, e) => 
			{
				if (MFMailComposeViewController.CanSendMail) {
					var mailController = new MFMailComposeViewController ();

					mailController.SetToRecipients (new string[] { "hello@touchin.ru" });

					mailController.Finished += (finishSender, finishE) => { finishE.Controller.DismissViewController (true, null); };

					PresentViewController (mailController, true, null);
				}
			};

			View.AddSubview (btnCall);
			View.AddSubview (btnSendMessage);

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

