using System;

namespace HashBot
{
	public interface ITwitterAuthorizationService
	{
		String BearerToken{ get; }
	}
}

