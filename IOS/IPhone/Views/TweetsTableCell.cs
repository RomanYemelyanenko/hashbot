using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace HashBot
{
	namespace UI
	{
		public class TweetsTableCell : UITableViewCell, ITweetsTableCell
		{
			private UILabel _headingLabel;
			private UILabel _subheadingLabel;
			private UILabel _createdLable;
			private UIImageView _imageView;

			public TweetsTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
			{
				UIColor backgroundColor = UIColor.FromPatternImage (UIImage.FromBundle("Images/Tweets/bg.png"));

				SelectionStyle = UITableViewCellSelectionStyle.Gray;
				_imageView = new UIImageView ();
				_imageView.Frame = new RectangleF (5, 5, 33, 33);

				_headingLabel = new UILabel () {
					Font = Fonts.HelveticaNeueBold(17),
					TextColor = UIColor.FromRGB (0,0,0),
					BackgroundColor = UIColor.Clear
				};

				_subheadingLabel = new UILabel () {
					Font = Fonts.HelveticaNeue(13),
					TextColor = UIColor.FromRGB (0x89, 0x89, 0x89),
					TextAlignment = UITextAlignment.Center,
					BackgroundColor = UIColor.Clear
				};

				_createdLable = new UILabel () {
					Font =  Fonts.HelveticaNeue(11),
					TextColor = UIColor.FromRGB (0x89, 0x89, 0x89),
					TextAlignment = UITextAlignment.Center,
					BackgroundColor = UIColor.Clear
				};

				_createdLable.Frame = new RectangleF (ContentView.Bounds.Width - 80, 4, 52, 26);
				_createdLable.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;

				ContentView.BackgroundColor = backgroundColor;
				ContentView.Add (_headingLabel);
				ContentView.Add (_subheadingLabel);
				ContentView.Add (_createdLable);
				ContentView.Add (_imageView);
			}

			public void UpdateCell (string name, string text, DateTime created)//  Tweet tweet)
			{
				_headingLabel.Text = name; // tweet.user.name;
				_subheadingLabel.Text = text;// tweet.text;
				_createdLable.Text = ParseDate (created); // ParseDate (DateTime.Parse (tweet.createdAt ));
			}

			public string ParseDate (DateTime date)
			{
				var diff = DateTime.Now - date;
				if (diff.Days > 0)
					return diff.Days + (diff.Hours + diff.Minutes + diff.Seconds != 0 ? 1 : 0) + " д";
				else if (diff.Hours > 0) {
					return diff.Hours + (diff.Minutes + diff.Seconds != 0 ? 1 : 0) + " ч";
				} else if (diff.Minutes > 0) {
					return diff.Minutes + (diff.Seconds != 0 ? 1 : 0) + " мин";
				} else
					return diff.Seconds + " сек";
			}

			public override void LayoutSubviews ()
			{
				base.LayoutSubviews ();
				int viewWidth = (int)ContentView.Bounds.Width;

				_headingLabel.Frame = new RectangleF (50, 4, viewWidth - 63, 25);
				_subheadingLabel.Frame = new RectangleF (50, 25, viewWidth - 70, 20);

			}

			public UIImageView UserImage 
			{ 
				get { return _imageView; }  
			}
		}
	}
}

