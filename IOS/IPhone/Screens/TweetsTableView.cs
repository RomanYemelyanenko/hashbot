using System;
using MonoTouch.UIKit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace HashBot
{
	public class TweetsTableView : UITableView 
	{
		public TweetsTableView () : base()
		{
			TableFooterView = GetFooterView (0);
		}

		public override UITableViewHeaderFooterView GetFooterView (int section)
		{
			var footer = new UITableViewHeaderFooterView (new RectangleF (0, 0, 10, 50));

			var buttonLoadMore = new UIButton (UIButtonType.RoundedRect);
			buttonLoadMore.Frame = new RectangleF (10, 10, 300, 44);
			buttonLoadMore.SetTitle ("Показать еще", UIControlState.Normal);

			//todo 200 - ContentSizeForViewInPopover.Width
			footer.Frame = new RectangleF (0, 0, 200, 64);
			footer.AddSubview (buttonLoadMore);


			return footer;

		}



	}
}

