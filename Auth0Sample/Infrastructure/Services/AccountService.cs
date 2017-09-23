using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Auth0Sample.Enums;
using Auth0Sample.Infrastructure.Services.Interfaces;

namespace Auth0Sample.Infrastructure.Services
{
	public class AccountService: IAccountService
	{
		private IAuth0Client _auth0Client;
		public AccountService(IAuth0Client auth0Client)
		{
			_auth0Client = auth0Client;
		}

        public async Task AuthenticateMobileClientAsync(object context)
        {
            await _auth0Client.LoginAsync(context);
        }

        public async Task AuthenticateSocialMobileClientAsync(object context, GrantType socialProvider)
		{
			await _auth0Client.LoginWithSocialAsync(context, socialProvider);	
		}

		public async Task RefreshSocialTokenAsync()
		{
			await _auth0Client.RefreshSocialTokenAsync();
		}
	}
}
