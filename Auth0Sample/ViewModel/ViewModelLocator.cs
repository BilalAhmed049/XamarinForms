/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LostApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Auth0Sample.Infrastructure.Services;
using Auth0Sample.Infrastructure.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace Auth0Sample.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => DependencyService.Get<IAuth0Client>());
            SimpleIoc.Default.Register<IAccountService, AccountService>();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<Auth0LoginViewModel>();
        }


        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public Auth0LoginViewModel SocialLogin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Auth0LoginViewModel>();

            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}