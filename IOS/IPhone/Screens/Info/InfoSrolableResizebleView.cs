using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.MessageUI;
using MonoTouch.Foundation;

namespace HashBot
{
	public class InfoSrolableResizebleView : UIScrollView
	{
		private UIViewController _controller;

		private UIImageView _logoImageView;
		private UITextView _infoTextView;
		private UIButton _btnCall;
		private UIButton _btnSendMessage;
		private SizeF _buttonSize;

		public InfoSrolableResizebleView(RectangleF viewArea, UIViewController controller) : base(viewArea)
		{
			_controller = controller;

			this.Frame = viewArea;
			this.ContentSize = viewArea.Size;
			this.AutoresizingMask = UIViewAutoresizing.All;

			_logoImageView = new UIImageView (new UIImage ("Images/Info/logo.png"));
			//_logoImageView.AutoresizingMask = UIViewAutoresizing.All ^ UIViewAutoresizing.FlexibleWidth ^ UIViewAutoresizing.FlexibleHeight;

			UIImage originalNormalImage = new UIImage ("Images/Info/button.png");
			UIImage originalHighlightedImage = new UIImage ("Images/Info/button_pressed.png");

			UIImage backgroundNormalImage = ImageHelper.GetStretchableImage ("Images/Info/button.png", (int) (originalNormalImage.Size.Width/2 - 1), (int)(originalNormalImage.Size.Height/2 - 1)); 
			UIImage backgroundHighlightedImage = ImageHelper.GetStretchableImage ("Images/Info/button_pressed.png", (int) (originalHighlightedImage.Size.Width/2 - 1), (int)(originalHighlightedImage.Size.Height/2 - 1));

			_buttonSize = new SizeF(this.Bounds.Width < this.Bounds.Height ? this.Bounds.Width/2 : this.Bounds.Height/2, backgroundNormalImage.Size.Height);

			this.AddSubview (_logoImageView);

			_infoTextView = new UITextView();

			_infoTextView.Editable = false;
			_infoTextView.Text = "Нам не стыдно за выпускаемые продукты, все они сделаны с вниманием к деталям. Пользователи это ценят, многие наши приложения попадают в топы AppStore и получают высокие оценки. \n\nМы любим своих заказчиков и решаем их задачи. На письма и телефон отвечаем быстро, по праздникам и выходным, делаем работу в срок и никуда не пропадаем.\nЗакажите разработку сейчас! ";
			_infoTextView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			this.AddSubview (_infoTextView);

			_btnCall = new UIButton (UIButtonType.RoundedRect);
			_btnCall.SetImage (new UIImage ("Images/Info/icon_phone.png"), UIControlState.Normal);
			_btnCall.SetBackgroundImage (backgroundNormalImage, UIControlState.Normal);
			_btnCall.SetBackgroundImage (backgroundHighlightedImage, UIControlState.Highlighted);
			_btnCall.ImageEdgeInsets = new UIEdgeInsets(0,0,10,0);

			_btnSendMessage = new UIButton (UIButtonType.RoundedRect);
			_btnSendMessage.SetImage (new UIImage ("Images/Info/icon_mail.png"), UIControlState.Normal);
			_btnSendMessage.SetBackgroundImage (backgroundNormalImage, UIControlState.Normal);
			_btnSendMessage.SetBackgroundImage (backgroundHighlightedImage, UIControlState.Highlighted);
			_btnSendMessage.ImageEdgeInsets = new UIEdgeInsets(0,0,10,0);
			_btnCall.TouchUpInside += (sender, e) => { 
				UIApplication.SharedApplication.OpenUrl (new NSUrl ("tel:8-812-309-3879"));
			};

			_btnSendMessage.TouchUpInside += (sender, e) => 
			{
				if (MFMailComposeViewController.CanSendMail) {
					var mailController = new MFMailComposeViewController ();
					mailController.SetToRecipients (new string[] { "hello@touchin.ru" });
					mailController.Finished += (finishSender, finishE) => { finishE.Controller.DismissViewController (true, null); };
					_controller.PresentViewController (mailController, true, null);
				}
			};
			this.AddSubview (_btnCall);
			this.AddSubview (_btnSendMessage);

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();


			_logoImageView.Frame = new RectangleF (new PointF(this.Bounds.Width/2 - _logoImageView.Bounds.Width/2, 10), _logoImageView.Bounds.Size);


			_infoTextView.Frame = new RectangleF(30, _logoImageView.Bounds.Bottom + 30 ,this.Bounds.Width - 30 * 2, 200);
			//_infoTextView.Frame.Size = _infoTextView.StringSize (_infoTextView.Text, _infoTextView.Font);
			_infoTextView.SizeToFit ();

			PointF btnLocation = new PointF (this.Bounds.Width / 4 - _buttonSize.Width / 2, _infoTextView.Frame.Top + _infoTextView.Bounds.Height);

			_btnCall.Frame = new RectangleF (btnLocation, _buttonSize);

			btnLocation.X += this.Bounds.Width/2;
			_btnSendMessage.Frame = new RectangleF (btnLocation, _buttonSize);

			//this.ContentSize = this.SizeThatFits(
		}

	}
}

