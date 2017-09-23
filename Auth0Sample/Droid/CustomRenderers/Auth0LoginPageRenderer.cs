using System;
using System.Threading.Tasks;
using Auth0Sample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Auth0Sample.Enums;
using Auth0Sample.Infrastructure.Services.Interfaces;
using Auth0Sample.View;

[assembly: ExportRenderer(typeof(Auth0LoginPage), typeof(Auth0LoginPageRenderer))]
namespace Auth0Sample.Droid
{
	public class Auth0LoginPageRenderer : PageRenderer
	{
		private IAccountService _accountService;
        private GrantType _grantType;


		protected async override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			var currentView = (Auth0LoginPage)e.NewElement;
			_accountService = currentView.AccountService;
			_grantType = currentView.GrantType;
			await ShowLoginPageAsync();
		}


		private async Task ShowLoginPageAsync()
		{
			try
			{
                if(_grantType == GrantType.standard)
                    await _accountService.AuthenticateMobileClientAsync(this);

                else
                    await _accountService.AuthenticateSocialMobileClientAsync(this, _grantType);
            }

			catch (TaskCanceledException)
			{
				System.Diagnostics.Debug.WriteLine("User cancelled social login operation");
				Xamarin.Forms.Application.Current.MainPage = new LoginPage();
			}
		}

	}
}
