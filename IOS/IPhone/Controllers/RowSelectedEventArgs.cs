using System;

namespace HashBot
{
	public class RowSelectedEventArgs : EventArgs
	{
		private Tweet _tweet;

		public RowSelectedEventArgs (Tweet tweet) : base()
		{
			_tweet = tweet;
		}

		public Tweet Tweet
		{
			get { return _tweet; }
		}
	}
}

