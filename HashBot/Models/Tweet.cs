using System;

namespace HashBot
{
	public class Tweet
	{
		private String _autor;
		private String _note;
		private String _text;
		private String _created;
		private String _link;

		public Tweet()
		{
			
		}

		public Tweet(String autor, String note, String text, String created, String link)
		{
			_autor = autor;
			_note = note;
			_text = text;
			_created = created;
			_link = link;
		}
	}
}

