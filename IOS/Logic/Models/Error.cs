using System;
using System.Net;
using System.Collections.Generic;
//using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using RestSharp;

namespace HashBot 
{
	public class Error : Exception
	{
		public Error (string message, Exception innerException) : base(message, innerException){}
		public Error (ResponseStatus responceStatus) : base(responceStatus.ToString()){}
	}
}

