using ReactiveExtensionsWithXamarin.Core.ViewModels;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveExtensionsWithXamarin.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsListViewPage : ContentPageBase<CarsListViewModel>
    {
        public CarsListViewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Cars, x => x.CarsListView.ItemsSource).DisposeWith(disposables);
                this.Bind(ViewModel, x => x.SearchQuery, c => c.SearchViewEntry.Text)
                    .DisposeWith(disposables);
            });
        }
    }
}