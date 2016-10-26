using Xamarin.Forms;
using XamarinUniversity.Services;

namespace XamarinCoginitveServicesDemoApp
{
	public partial class App : Application
	{

		static App()
		{
			// Register dependencies:
			DependencyService.Register<MainViewModel>();
			DependencyService.Register<ICognitiveClient, CognitiveClient>();
			// Register standard XamU services:
			XamUInfrastructure.Init();
		}

		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
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
