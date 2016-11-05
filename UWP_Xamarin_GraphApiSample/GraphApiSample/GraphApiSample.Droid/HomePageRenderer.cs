using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using GraphApiSample.Droid;
using Microsoft.Identity.Client;

[assembly: ExportRenderer(typeof(GraphApiSample.MainPage), typeof(HomePageRenderer))]
namespace GraphApiSample.Droid
{
    class HomePageRenderer : PageRenderer
    {
        MainPage page;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as MainPage;
            var activity = this.Context as Activity;
            page.platformParameters = new PlatformParameters(activity);
        }
    }
}