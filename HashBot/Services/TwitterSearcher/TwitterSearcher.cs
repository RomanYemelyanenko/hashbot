using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Json;
using RestSharp;
using System.Text.RegularExpressions;
using RestSharp.Deserializers;

namespace HashBot
{
	public class TwitterSearcher
	{
		private readonly ITwitterAuthorizationService _authorizationService;
		private String _host;
		private String _requestURL;


		public TwitterSearcher (ITwitterAuthorizationService authorizationService, String host = "https://api.twitter.com/", String requestURL = "1.1/search/tweets.json")
		{
			_authorizationService = authorizationService;
			_host = host;
			_requestURL = requestURL;
		}

		public void SearchAsync (string hashTag, int numberTweets, Action<Error,List<Tweet>> callback)
		{
			if (callback == null) 
			{
				throw new ArgumentNullException ("callback");
			}


			var client = new RestClient (_host); 

			var queryRequest = new RestRequest (_requestURL, Method.GET); // old api search.json
			queryRequest.AddParameter ("q", hashTag);
			//queryRequest.AddParameter("rpp", userCount); //old twitter Api 1.0 
			queryRequest.AddParameter ("count", numberTweets); 
			//queryRequest.AddParameter ("include_entities", true);

			client.AddDefaultHeader ("Authorization", "Bearer " + _authorizationService.BearerToken );

			client.AddHandler ("application/json", new JsonDeserializer ());
			//var responseTweets = client.Execute<TwitterSearchResponse>(queryRequest);

			client.ExecuteAsync<TwitterSearchResponse> (queryRequest, response => 
			                                            {
				var listTweets = new List<Tweet> ();
				Error error = null;
				try 
				{
					if (response.ResponseStatus != ResponseStatus.Completed) 
					{
						error = new Error (response.ResponseStatus);
					} 
					listTweets = ParseTweet (response.Data.statuses);
				} 
				catch (Exception ex) 
				{
					error = new Error ("Tweets loading error", ex);
				}

				callback (error, listTweets);

			});	
		}

		private List<Tweet> ParseTweet (List<Tweet> statuses)
		{
			var listTweets = new List<Tweet> ();

			foreach (var tweet in statuses) 
			{
				var strBegin = tweet.createdAt.Substring (0, 4); 
				var strDay = tweet.createdAt.Substring (8, 3);
				var strMonth = tweet.createdAt.Substring (4, 4);
				var strYear = tweet.createdAt.Substring (26, 4);
				var strEnd = tweet.createdAt.Substring (11, 14);
				tweet.createdAt = strBegin + strDay + strMonth + strYear + " " + strEnd;

				if (tweet.source != "web")
					tweet.source = Regex.Match (tweet.source, @"(?<=<.*>)(.*)(?=</a>)").ToString ();
				listTweets.Add (tweet);
			}
			return listTweets;


		}
	}
}

