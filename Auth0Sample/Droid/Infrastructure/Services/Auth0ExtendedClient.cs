using System;
using System.Threading.Tasks;
using Auth0.SDK;
using Auth0Sample.Droid;
using Auth0Sample.Enums;
using Auth0Sample.Infrastructure.Services.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(Auth0ExtendedClient))]
namespace Auth0Sample.Droid
{
	public class Auth0ExtendedClient : IAuth0Client
	{
		private Auth0Client _auth0Client;

		public Auth0ExtendedClient()
		{
			_auth0Client = new Auth0Client(Config.ServiceDomain, Config.ClientId);
		}

        public async Task LoginAsync(object context)
        {
            var renderer = (Auth0LoginPageRenderer)context;
            await _auth0Client.LoginAsync(renderer.Context, "Username-Password-Authentication", true);
        }

        public async Task LoginWithSocialAsync(object context, GrantType socialProvider)
		{
			var renderer = (Auth0LoginPageRenderer)context;
			await _auth0Client.LoginAsync(renderer.Context, socialProvider.ToString(), true);
		}

		public async Task RefreshSocialTokenAsync()
		{
			await _auth0Client.RenewIdToken();
		}
	}
}
