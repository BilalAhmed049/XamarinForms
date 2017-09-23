using ReactiveExtensionsWithXamarin.Core.Extensions;
using ReactiveExtensionsWithXamarin.Core.Model;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace ReactiveExtensionsWithXamarin.Core.ViewModels
{
    public class CarsListViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "Cars list";
        public IScreen HostScreen { get; protected set; }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value); }
        }

        //List with search results once user start typing

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            private set
            {
              this.RaiseAndSetIfChanged(ref _cars, value); 
            }
        }
        //List with initial items retrieved from web service. This is mocked by CreateList() method.

        ObservableCollection<Car> _carsSourceList;
        private ObservableCollection<Car> CarsSourceList
        {
            get { return _carsSourceList; }
            set { this.RaiseAndSetIfChanged(ref _carsSourceList, value); }
        }


        public CarsListViewModel()
        {
            HostScreen = Locator.Current.GetService<IScreen>();
            CreateList();
            SetupReactiveObservables();
        }

        protected void SetupReactiveObservables()
        {
            //When any value is provided in SearchViewEntry field and this value is not empty or null.
            //Throttle method here is responsible for delay displaying search result.
            //Once user finish typing, search query will be executed after two seconds.
            //Subscribe method here is responsible for filtering CarsSourceList and returning the result to Cars property.
            //Cars property is binded to CarsListViewControl in CarsListViewPage.

            this.WhenAnyValue(vm => vm.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(2))
                .Where(x => !string.IsNullOrEmpty(x))
                .Subscribe(vm =>
                    {
                        var filteredList = CarsSourceList.Where(brand => brand.Brand
                            .Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                        Device.BeginInvokeOnMainThread(() => { Cars = new ObservableCollection<Car>(filteredList); });
                    });

            //When empty value is provided in SearchViewEntry field (so user cleared it), display original list without filters.

            this.WhenAnyValue(vm => vm.SearchQuery).Where(x => string.IsNullOrEmpty(x)).Subscribe(vm =>
            {
                Cars = CarsSourceList;
            });
        }

        #region Mock List Items

        private void CreateList()
        {
            CarsSourceList = new ObservableCollection<Car>
            {
               new Car
               {
                   Brand = "BMW",
                   Model = "650",
                   ThumbnailUrl = "https://image.ibb.co/chZJbv/BMW.png"
               },

               new Car
               {
                   Brand = "Audi",
                   Model = "A3",
                   ThumbnailUrl ="https://image.ibb.co/nvAMUF/AUDI.png"
               },

                 new Car
               {
                   Brand = "Fiat",
                   Model = "500",
                   ThumbnailUrl ="https://image.ibb.co/gjzbwv/FIAT.png"
               },

               new Car
               {
                   Brand = "Toyota",
                   Model = "Yaris",
                   ThumbnailUrl ="https://image.ibb.co/mt1jia/TOYOTA.png"
               },

              new Car
               {
                   Brand = "Pagani",
                   Model = "Zonda",
                   ThumbnailUrl ="https://image.ibb.co/nvS1UF/PAGANI.png"
               }
            };
            Cars = CarsSourceList;

        #endregion
        }
    }
}
