using Xamarin.Forms;

namespace MvvmAppDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = App.Locator.MainViewModel;
		}
	}
}
