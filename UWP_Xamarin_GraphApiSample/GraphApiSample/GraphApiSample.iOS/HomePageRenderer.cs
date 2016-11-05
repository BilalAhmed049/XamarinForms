using GraphApiSample.iOS;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GraphApiSample.MainPage), typeof(HomePageRenderer))]
namespace GraphApiSample.iOS
{
    class HomePageRenderer : PageRenderer
    {
        GraphApiSample.MainPage page;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as GraphApiSample.MainPage;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            page.platformParameters = new PlatformParameters(this);
        }
    }
}
