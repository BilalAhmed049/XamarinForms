using GraphApiSample.GraphHelpers;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GraphApiSample
{
    public partial class MainPage : ContentPage
    {
        public IPlatformParameters platformParameters { get; set; }

        public MainPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            App.IdentityClientApp.PlatformParameters = platformParameters;
            var graphClient = GraphClientHelper.GetAuthenticatedClient();

            var me = await graphClient.Me.Request().GetAsync();
            InfoLabel.Text = me.DisplayName;
            InfoLabel.Text = me.JobTitle;

        }
    }
}
