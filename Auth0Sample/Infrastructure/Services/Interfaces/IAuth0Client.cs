using System;
using System.Threading.Tasks;
using Auth0Sample.Enums;

namespace Auth0Sample.Infrastructure.Services.Interfaces
{
	public interface IAuth0Client
	{
        Task LoginAsync(object context);
        Task LoginWithSocialAsync(object context, GrantType socialProvider);
		Task RefreshSocialTokenAsync();
	}
}
