using System;
using MonoTouch.UIKit;

namespace HashBot
{
	public interface ITweetsTableCell
	{
		UILabel TweetHeadingLabel { get; }
		UILabel TweetSubheadingLabel { get; }
		UILabel TweetCreatedLable { get; }
		UIImageView UserImage { get; }
	}
}

