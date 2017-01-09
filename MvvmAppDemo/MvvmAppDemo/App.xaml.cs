using GalaSoft.MvvmLight.Ioc;
using MvvmAppDemo.ViewModel;
using Xamarin.Forms;

namespace MvvmAppDemo
{
	public partial class App : Application
	{
		private static ViewModelLocator _locator;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

		public App()
		{
			InitializeComponent();

			var navigationService = new NavigationService();
			navigationService.Configure(AppPages.MainPage, typeof(MainPage));
			navigationService.Configure(AppPages.DetailsPage, typeof(DetailsPage));
			SimpleIoc.Default.Register<INavigationService>(() => navigationService);

			var firstPage = new NavigationPage(new MainPage());
			navigationService.Initialize(firstPage);
			MainPage = firstPage;
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
