using Realms;
using RealXamarinFormsDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealXamarinFormsDemo
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Car> CarsCollection { get; set; }
        public MainPage()
        {
            InitializeComponent();

            LoadCars();
            if (CarsCollection == null)
                CreateCarsList();
            BindingContext = this;
        }

        private void LoadCars()
        {
            var realm = Realm.GetInstance();
            CarsCollection = realm.All<Car>() as ObservableCollection<Car>;
        }

        private void SaveCars()
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                foreach (var car in CarsCollection)
                {
                    realm.Add(car);
                }
            });
        }

        private void CreateCarsList()
        {
            CarsCollection = new ObservableCollection<Car>()
            {
                new Car()
                {
                    Brand = "BMW",
                    Thumbnail = "bmw.png"
               },
                new Car()
                {
                    Brand = "Audi",
                    Thumbnail = "audi.png"
               },
                new Car()
                {
                    Brand = "Mercedes",
                    Thumbnail = "mercedes.png"
               }
            };
            SaveCars();
        }
    }
}
