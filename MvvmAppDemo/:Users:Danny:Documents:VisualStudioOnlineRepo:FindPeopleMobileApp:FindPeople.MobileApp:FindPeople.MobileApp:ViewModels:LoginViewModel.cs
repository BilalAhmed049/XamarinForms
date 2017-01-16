using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FindPeople.MobileApp.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using FindPeople.MobileApp.Enums;
using FindPeople.MobileApp.Infrastructure.Services;
using GalaSoft.MvvmLight.Messaging;

namespace FindPeople.MobileApp.ViewModels
{
	public class LoginViewModel: ViewModelBase
	{
		private readonly INavigationService _navigationService;

		private ImageSource _mainLogoImageSource;
		public ImageSource MainLogoimageSource
		{
			get
			{
				if (_mainLogoImageSource == null)
				{
					return Device.OnPlatform(
						iOS: ImageSource.FromFile("Images/bg_main_logo.jpg"),
						Android: ImageSource.FromFile("bg_main_logo.jpg"),
						WinPhone: ImageSource.FromFile("Images/bg_main_logo.jpg"));
				}

				return _mainLogoImageSource;
			}
		}

		public ICommand LoginWithFacebookCommand { get; private set; }


		public LoginViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			LoginWithFacebookCommand = new Command(() => LoginWithFacebook());
			Messenger.Default.Register<int>(this, parameter =>
			{
				var passed = parameter;
			});
		}

		private void LoginWithFacebook()
		{
			//SimpleIoc.Default.GetInstance<INavigationService>().NavigateTo(AppPages.DecisionPage);
			Messenger.Default.Send(0);
			Application.Current.MainPage = new DoFavorInstructionsPage();
		}

	}
}
