using ReactiveExtensionsWithXamarin.Core.ViewModels;
using ReactiveExtensionsWithXamarin.Core.Views;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ReactiveExtensionsWithXamarin.Core
{
    public partial class App : Application, IScreen
    {
        public RoutingState Router { get; set; }

        public App()
        {
            InitializeComponent();

            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new LoginPage(), typeof(IViewFor<LoginViewModel>));
            Locator.CurrentMutable.Register(() => new CarsListViewPage(), typeof(IViewFor<CarsListViewModel>));
            Router.NavigateAndReset.Execute(new LoginViewModel());

            MainPage = new RoutedViewHost();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
