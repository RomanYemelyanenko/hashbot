using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.MessageUI;
using MonoTouch.Foundation;

namespace HashBot
{
	public class InfoSrolableResizebleView : UIScrollView
	{
		private UIImageView _logoImageView;
		private UITextView _infoText;
		private UIButton _btnCall;
		private UIButton _btnSendMessage;
		private SizeF _buttonSize;
		private int _leftAndRigthOffsets;

		public InfoSrolableResizebleView(RectangleF viewArea, UIViewController controller) : base(viewArea)
		{
			InitViewStyle (viewArea);
			InitLogoImage ();
			InitInfoText ();
			InitCallAndSendMsgBtns ();
		}

		private void InitViewStyle (RectangleF viewArea)
		{
			BackgroundColor = UIColor.FromRGB (0xFF,0xFF,0xFF);
			Frame = viewArea;
			ContentSize = viewArea.Size;
			AutoresizingMask = UIViewAutoresizing.All;
		}

		private void InitLogoImage()
		{
			_logoImageView = new UIImageView (new UIImage ("Images/Info/logo.png"));
			AddSubview (_logoImageView);
		}

		private void InitInfoText()
		{
			_infoText = new UITextView();

			_infoText.Editable = false;
			_infoText.Text = "Нам не стыдно за выпускаемые продукты, все они сделаны с вниманием к деталям. Пользователи это ценят, многие наши приложения попадают в топы AppStore и получают высокие оценки. \n\nМы любим своих заказчиков и решаем их задачи. На письма и телефон отвечаем быстро, по праздникам и выходным, делаем работу в срок и никуда не пропадаем.\nЗакажите разработку сейчас! ";
			_infoText.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			_infoText.Font = Fonts.HelveticaNeue (10);
			_infoText.TextColor = UIColor.FromRGB (0x41,0x41,0x41);
			AddSubview (_infoText);
		}

		private void InitCallAndSendMsgBtns()
		{
			UIImage image = UIImage.FromFile ("Images/Info/button.png");

			_buttonSize = new SizeF(120, image.Size.Height);
			_btnCall = new UIButton (UIButtonType.RoundedRect);
			_btnCall.SetImage (new UIImage ("Images/Info/icon_phone.png"), UIControlState.Normal);
			_btnCall.SetStretchableImage ("Images/Info/button.png", "Images/Info/button_pressed.png");
			_btnCall.ImageEdgeInsets = new UIEdgeInsets(0,0,10,0);


			_btnSendMessage = new UIButton (UIButtonType.RoundedRect);
			_btnSendMessage.SetImage (new UIImage ("Images/Info/icon_mail.png"), UIControlState.Normal);
			_btnSendMessage.SetStretchableImage ("Images/Info/button.png", "Images/Info/button_pressed.png");
			_btnSendMessage.ImageEdgeInsets = new UIEdgeInsets(0,0,10,0);

			AddSubview (_btnCall);
			AddSubview (_btnSendMessage);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			_leftAndRigthOffsets = (int)(Bounds.Width * 0.1);

			//reset logo image and info text position
			_logoImageView.SetRoundedFrame (Bounds.Width / 2 - _logoImageView.Bounds.Width / 2 , 10, _logoImageView.Bounds.Size );
			_infoText.SetRoundedFrame (_leftAndRigthOffsets, _logoImageView.Bounds.Bottom + 30, Bounds.Width - _leftAndRigthOffsets * 2, 200);
			_infoText.SizeToFit ();

			PointF btnLocation = new PointF (_infoText.Frame.X, _infoText.Frame.Bottom  + 30);
			_btnCall.SetRoundedFrame (btnLocation, _buttonSize);
			//alignment by left side
			btnLocation.X = Bounds.Width - _leftAndRigthOffsets - _buttonSize.Width;
			_btnSendMessage.SetRoundedFrame (btnLocation, _buttonSize);

			ContentSize = new SizeF (ContentSize.Width, _btnSendMessage.Frame.Bottom + 30);
		}

		public UIButton SendMessage
		{
			get { return _btnSendMessage; } 
		}

		public UIButton Call
		{
			get { return _btnCall; }
		}

	}
}

