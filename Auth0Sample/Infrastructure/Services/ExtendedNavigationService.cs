using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0Sample.Enums;
using Xamarin.Forms;
using System.Reflection;
using System.Collections.Concurrent;

namespace Auth0Sample.Infrastructure.Services
{
    public class ExtendedNavigationService : INavigationService
    {

        private readonly ConcurrentDictionary<AppPages, Type> _pagesByKey = new ConcurrentDictionary<AppPages, Type>();
        public Page RootPage { get; set; }
        public Page CurrentPage { get; set; }

        public void Configure(AppPages pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.TryAdd(pageKey, pageType);
                }
            }
        }

        public async Task GoBack()
        {
            if (RootPage is NavigationPage)
            {
                var mainPage = RootPage as NavigationPage;
                await mainPage.CurrentPage.Navigation.PopAsync();
            }

            if (RootPage is CarouselPage)
                await CurrentPage.Navigation.PopModalAsync();
        }

        public void InitializeRootPage(Page page)
        {
            RootPage = page;
            Application.Current.MainPage = page;
        }

        public async Task NavigateTo(AppPages pageKey)
        {
            await NavigateTo(pageKey, null);
        }

        public async Task NavigateTo(AppPages pageKey, object parameter)
        {
            if (_pagesByKey.ContainsKey(pageKey))
            {
                var type = _pagesByKey[pageKey];
                ConstructorInfo constructor;
                object[] parameters;

                if (parameter == null)
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(c => !c.GetParameters().Any());

                    parameters = new object[]
                    {
                    };
                }
                else
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(
                            c =>
                            {
                                var p = c.GetParameters();
                                return p.Count() == 1
                                       && p[0].ParameterType == parameter.GetType();
                            });

                    parameters = new[]
                    {
                            parameter
                        };
                }

                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "No suitable constructor found for page " + pageKey);
                }

                var page = constructor.Invoke(parameters) as Page;
                CurrentPage = page;

                if (RootPage is NavigationPage)
                {
                    var navigationPage = RootPage as NavigationPage;
                    await navigationPage.Navigation.PushAsync(page);
                }

                if (RootPage is CarouselPage)
                {
                    var contentPage = RootPage as CarouselPage;
                    await contentPage.Navigation.PushModalAsync(page);
                }

                if (RootPage is ContentPage)
                {
                    var contentPage = RootPage as ContentPage;
                    await contentPage.Navigation.PushModalAsync(page);
                }
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        "No such page: {0}. Did you forget to call NavigationService.Configure?",
                        pageKey), nameof(pageKey));
            }
        }
    }
}
