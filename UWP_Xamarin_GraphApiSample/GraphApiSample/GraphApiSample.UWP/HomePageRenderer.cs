using GraphApiSample;
using GraphApiSample.UWP;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GraphApiSample.MainPage), typeof(HomePageRenderer))]
namespace GraphApiSample.UWP
{
    class HomePageRenderer : PageRenderer
    {
        private GraphApiSample.MainPage page;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as GraphApiSample.MainPage;
            page.platformParameters = new PlatformParameters();

        }
    }
}
