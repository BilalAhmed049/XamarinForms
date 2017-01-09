using System;
namespace MvvmAppDemo
{
	public interface INavigationService
	{
		void GoBack();
		void NavigateTo(AppPages pageKey);
		void NavigateTo(AppPages pageKey, object parameter);
	}
}
