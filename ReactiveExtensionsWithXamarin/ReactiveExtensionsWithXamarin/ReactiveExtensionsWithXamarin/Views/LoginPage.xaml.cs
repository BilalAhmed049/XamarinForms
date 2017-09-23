using ReactiveExtensionsWithXamarin.Core.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveExtensionsWithXamarin.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPageBase<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Username, c => c.UsernameEntry.Text)
                .DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.Password, c => c.PasswordEntry.Text)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, x => x.LoginCommand, x => x.LoginButton.Command)
                .DisposeWith(disposables);

                this.OneWayBind(ViewModel, x => x.IsLoading, x => x.LoginActivityIndicator.IsRunning)
                .DisposeWith(disposables);
            });
        }
    }
}