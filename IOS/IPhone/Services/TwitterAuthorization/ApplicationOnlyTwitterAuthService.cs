using System;
using System.Collections.Generic;

//using Microsoft.Build.Tasks;
using System.Web;
using System.Text;
using System.Net;
using System.Json;
using MonoTouch.UIKit;

namespace HashBot
{
	public class ApplicationOnlyTwitterAuthService : ITwitterAuthorizationService
	{
		private readonly String _consumerKey;
		private readonly String _consumerSecret;
		private readonly String _requestTokenURL;
		private readonly String _userAgent;
		private String _bearerToken;

		public ApplicationOnlyTwitterAuthService (String consumerKey, String consumerSecret, String requestTokenURL, String userAgent)
		{
			_consumerKey = consumerKey;
			_consumerSecret = consumerSecret;
			_requestTokenURL = requestTokenURL;
			_userAgent = userAgent;
		}

		public String RequestTokenURL {
			get { return _requestTokenURL; }
		}

		public String BearerToken {
			get {
				if (String.IsNullOrEmpty (_bearerToken))
					_bearerToken = ObtainBearerToken ();

				return _bearerToken;
			}
		}

		private String EncodedToBase64ConsumerKeyAndSecret {
			get {
				return System.Convert.ToBase64String (this.EncodedConsumerKeyAndSecret);
			}
		}

		private Byte[] EncodedConsumerKeyAndSecret {
			get {
				return Encoding.ASCII.GetBytes (_consumerKey + ":" + _consumerSecret);
			}
		}

		private String ObtainBearerToken ()
		{
			try {
				var request = (HttpWebRequest)WebRequest.Create (_requestTokenURL);
				request.Method = "POST";
				request.UserAgent = _userAgent;
				request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
				request.ContentLength = 29;
				request.Headers.Add ("Authorization", "Basic " + EncodedToBase64ConsumerKeyAndSecret);

				using (var stream = request.GetRequestStream()) {
					Byte[] content = Encoding.ASCII.GetBytes ("grant_type=client_credentials");
					stream.Write (content, 0, content.Length);
				}

				var response = request.GetResponse ();

				String responseContent = ""; 

				using (var strem = response.GetResponseStream()) {
					byte[] bytes = new byte[strem.Length];
					strem.Read (bytes, 0, bytes.Length);
					responseContent = Encoding.UTF8.GetString (bytes, 0, bytes.Length);

				}
				JsonValue result = JsonValue.Parse (responseContent);
				try {
					String access_token = result ["access_token"];
					return access_token;
				} catch (KeyNotFoundException ex) {
					return String.Empty;
				}
			} catch (WebException ex) 
			{
				return String.Empty;
			}

		}
	}
}

