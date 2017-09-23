using System;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0Sample.Enums;

namespace Auth0Sample.Infrastructure.Services.Interfaces
{
	public interface IAccountService
	{
        Task AuthenticateMobileClientAsync(object context);
        Task AuthenticateSocialMobileClientAsync(object context, GrantType socialProvider);
        Task RefreshSocialTokenAsync();
	}
}
