using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Auth0Sample.Enums;
using Auth0Sample.Infrastructure.Services.Interfaces;
using Auth0Sample.View;

namespace Auth0Sample.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAccountService _accountService;


        ImageSource _microsofImageSource;
        public ImageSource MicrosofImageSource
        {
            get
            {
                if (_microsofImageSource == null)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            return ImageSource.FromFile("Images/ic_button_ms.png");
                        case Device.Android:
                            return ImageSource.FromFile("ic_button_ms.png");
                        case Device.Windows:
                            return ImageSource.FromFile("Images/ic_button_ms.png");
                    }
                }
                return _microsofImageSource;
            }

            set
            {
                Set(ref _microsofImageSource, value);
            }
        }

        ImageSource _twitterImageSource;
        public ImageSource TwitterImageSource
        {
            get
            {
                if (_twitterImageSource == null)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            return ImageSource.FromFile("Images/ic_button_twitter.png");
                        case Device.Android:
                            return ImageSource.FromFile("ic_button_twitter.png");
                        case Device.Windows:
                            return ImageSource.FromFile("Images/ic_button_twitter.png");
                    }
                }
                return _twitterImageSource;
            }

            set
            {
                Set(ref _twitterImageSource, value);
            }
        }

        ImageSource _facebookmageSource;
        public ImageSource FacebookmageSource
        {
            get
            {
                if (_facebookmageSource == null)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            return ImageSource.FromFile("Images/ic_button_facebook.png");
                        case Device.Android:
                            return ImageSource.FromFile("ic_button_facebook.png");
                        case Device.Windows:
                            return ImageSource.FromFile("Images/ic_button_facebook.png");
                    }
                }
                return _facebookmageSource;
            }

            set
            {
                Set(ref _facebookmageSource, value);
            }
        }

        ImageSource _lineImageSource;
        public ImageSource LineImageSource
        {
            get
            {
                if (_lineImageSource == null)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            return ImageSource.FromFile("Images/ic_line.png");
                        case Device.Android:
                            return ImageSource.FromFile("ic_line.png");
                        case Device.Windows:
                            return ImageSource.FromFile("Images/ic_linefacebook.png");
                    }
                }
                return _lineImageSource;
            }

            set
            {
                Set(ref _lineImageSource, value);
            }
        }

        ImageSource _appLogoImage;
        public ImageSource AppLogoImage
        {
            get
            {
                if (_appLogoImage == null)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            return ImageSource.FromFile("Images/ic_login_logo.png");
                        case Device.Android:
                            return ImageSource.FromFile("ic_login_logo.png");
                        case Device.Windows:
                            return ImageSource.FromFile("Images/ic_login_logo.png");
                    }
                }
                return _appLogoImage;
            }

            set
            {
                Set(ref _appLogoImage, value);
            }
        }


        public ICommand Login { get; set; }
        public ICommand FacebookLogin { get; set; }
        public ICommand TwitterLogin { get; set; }
        public ICommand MicrosoftLogin { get; set; }
        public ICommand SignUp { get; set; }
        public ICommand ForgotPassword { get; set; }

        public LoginViewModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            Login = new RelayCommand(StandardLogin, () => true);
            FacebookLogin = new RelayCommand(FacebookSignIn, () => true);
            TwitterLogin = new RelayCommand(TwitterSignIn, () => true);
            MicrosoftLogin = new RelayCommand(MicrosoftSignIn, () => true);
        }

        private void StandardLogin()
        {
            Application.Current.MainPage = new Auth0LoginPage(GrantType.standard);
        }

        private void FacebookSignIn()
        {
            Application.Current.MainPage = new Auth0LoginPage(GrantType.facebook);
        }

        private void TwitterSignIn()
        {
            Application.Current.MainPage = new Auth0LoginPage(GrantType.twitter);
        }

        private void MicrosoftSignIn()
        {
            Application.Current.MainPage = new Auth0LoginPage(GrantType.windowslive);
        }
    }
}
