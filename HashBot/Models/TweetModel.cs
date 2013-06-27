using System;
using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp;


namespace HashBot
{
	public class Metadata
	{
		public string resultType { get; set; }
		public string isoLanguageCode { get; set; }
	}

	public class User 
	{
		public string name { get; set; }
		public string profileImageUrl { get; set; }
		public string createdAt { get; set; } 
		public string profileImageUrlHttps { get; set; }
		public int id { get; set; }
		public string screenName { get; set;}

	}

	public class Tweet
	{
		public string createdAt { get; set; } 
		public string idStr { get; set; }
		public string text { get; set; }
		public User user { get; set; }
		public string source { get; set; }
		public object geo { get; set; }
		public string id { get; set; }
		public Metadata metadata { get; set; }
	}

	public class SearchMetadata
	{

		public long maxId { get; set; }
		public int sinceId { get; set; }
		public string refreshUrl { get; set; }
		public string next_results { get; set; }
		public int count { get; set; }
		public double completedIn { get; set; }
		public string sinceIdStr { get; set; }
		public string query { get; set; }
		public string maxIdStr { get; set; }
	}

	public class TwitterSearchResponse
	{
		public List<Tweet> statuses { get; set; }
		public SearchMetadata searchMetadata { get; set; }
	}



}

