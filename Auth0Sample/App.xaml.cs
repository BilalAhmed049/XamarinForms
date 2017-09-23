using GalaSoft.MvvmLight.Ioc;
using Auth0Sample.Infrastructure.Services;
using Auth0Sample.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Auth0Sample.Enums;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Auth0Sample
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			InitNavigation();
		}

		private void InitNavigation()
		{
			INavigationService navigationService;

			if (!SimpleIoc.Default.IsRegistered<INavigationService>())
			{
				// Setup navigation service:
				navigationService = new ExtendedNavigationService();

				// Configure pages:
				navigationService.Configure(AppPages.LoginPage, typeof(LoginPage));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register(() => navigationService);
			}

			else
				navigationService = SimpleIoc.Default.GetInstance<INavigationService>();

			// Create new Navigation Page and set MainPage as its default page:
			var firstPage = new NavigationPage(new LoginPage());
			// Set Navigation page as default page for Navigation Service:
			navigationService.InitializeRootPage(firstPage);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
