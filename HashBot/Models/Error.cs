using System;
using System.Net;
using System.Collections.Generic;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Deserializers;
using System.IO;
using RestSharp.Authenticators;
using System.Diagnostics;
using MonoTouch.UIKit;

namespace HashBot 
{
	public class Error : Exception
	{
		public Error (string message, Exception innerException) : base(message, innerException){}
		public Error (ResponseStatus responceStatus) : base(responceStatus.ToString()){}
	}
}

