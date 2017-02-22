using System;
using Xamarin.Forms;

namespace MvvmAppDemo
{
	public interface INavigationService
	{
        void Configure(AppPages pageKey, Type pageType);
        void Initialize(NavigationPage page);
        void GoBack();
		void NavigateTo(AppPages pageKey);
		void NavigateTo(AppPages pageKey, object parameter);
	}
}
