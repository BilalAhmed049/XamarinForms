using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace MvvmAppDemo.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		public ICommand NavigateCommand { get; private set; }


		public MainViewModel(INavigationService navigationService)
		{
			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}
			/// 
			/// 
			_navigationService = navigationService;
			NavigateCommand = new Command(() => Navigate());
		}

		private void Navigate()
		{
			var person = new Person() { Name = "Daniel" };
			Messenger.Default.Send(person);
			_navigationService.NavigateTo(AppPages.DetailsPage, person);
		}

	}
}