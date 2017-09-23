using System;
using Auth0Sample.Enums;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Auth0Sample
{
	public interface INavigationService
	{
		void Configure(AppPages pageKey, Type pageType);
		void InitializeRootPage(Page page);
        Task GoBack();
        Task NavigateTo(AppPages pageKey);
        Task NavigateTo(AppPages pageKey, object parameter);

    }
}

