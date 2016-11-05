using GraphApiSample.GraphHelpers;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace GraphApiSample
{
    public partial class App : Application
    {
        public static PublicClientApplication IdentityClientApp = null;
        static string ClientID = "<<your app id>>";
        public App()
        {
            IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new MainPage();
        }

    }
}
