using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
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
			_navigationService.NavigateTo(AppPages.DetailsPage);
		}

	}
}