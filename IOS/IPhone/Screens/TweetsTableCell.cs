
using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace HashBot
{
	public class TweetsTableCell : UITableViewCell  {
		UILabel _headingLabel, _subheadingLabel, _createdLable;
		UIImageView imageView;
	
		public TweetsTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			imageView = new UIImageView();
			_headingLabel = new UILabel () {
				Font = UIFont.FromName("Cochin-BoldItalic", 17f),
				TextColor = UIColor.FromRGB (0,0,0),
				BackgroundColor = UIColor.Clear
			};

			_subheadingLabel = new UILabel () {
				Font = UIFont.FromName("AmericanTypewriter", 13f),
				TextColor = UIColor.FromRGB (137, 137, 137),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			_createdLable = new UILabel () {
				Font = UIFont.FromName("AmericanTypewriter", 13f),
				TextColor = UIColor.FromRGB (137, 137, 137),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};
			_createdLable.Frame = new RectangleF (ContentView.Bounds.Width - 80, 4, 52, 26);
			_createdLable.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;

			ContentView.Add (_headingLabel);
			ContentView.Add (_subheadingLabel);
			ContentView.Add (_createdLable);
			ContentView.Add (imageView);
		}
		public void UpdateCell (string name, string text, UIImage image, DateTime created)
		{
			imageView.Image = image;
			_headingLabel.Text = name;
			_subheadingLabel.Text = text;
			_createdLable.Text = ParseDate (created);
		}

		public string ParseDate(DateTime date)
		{
			var diff = DateTime.Now - date;

			if (diff.Hours > 0) {
				return diff.Hours + (diff.Minutes + diff.Seconds != 0 ? 1 : 0) + " ч";
			} else if (diff.Minutes > 0) {
				return diff.Minutes + (diff.Seconds != 0 ? 1 : 0) + " мин";
			} else
				return diff.Seconds + " сек";
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			imageView.Frame = new RectangleF (5, 5, 33, 33);
			_headingLabel.Frame = new RectangleF (50, 4, ContentView.Bounds.Width - 63, 25);
			_subheadingLabel.Frame = new RectangleF (50, 25, ContentView.Bounds.Width - 70, 20);

		}
	}

}

