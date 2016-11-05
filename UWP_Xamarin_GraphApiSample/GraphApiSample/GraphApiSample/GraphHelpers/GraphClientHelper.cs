using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GraphApiSample.GraphHelpers
{
    public class GraphClientHelper
    {
        //Scopes with the information which specific data you want to retrieve (it was declared in apps portal):
        public static string[] Scopes = {
                        "https://graph.microsoft.com/Mail.Read",
                        "https://graph.microsoft.com/People.Read",
                        "https://graph.microsoft.com/User.Read",
                         "https://graph.microsoft.com/Contacts.Read"
                         };
        public static string TokenForUser = null;
        public static DateTimeOffset Expiration;
        private static GraphServiceClient graphClient = null;

        public static GraphServiceClient GetAuthenticatedClient()
        {
            if (graphClient == null)
            {
                // Create Microsoft Graph client.
                try
                {

                    graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                            async (requestMessage) =>
                            {
                                //Authenticate first if needed:
                                var token = await GetTokenForUserAsync();
                                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

                            }));
                    return graphClient;
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Could not create a graph client: " + ex.Message);
                }
            }

            return graphClient;
        }

        //Authenticate user and acquire token -this will display login dialog:
        public static async Task<string> GetTokenForUserAsync()
        {
            if (TokenForUser == null || Expiration <= DateTimeOffset.UtcNow.AddMinutes(5))
            {
                AuthenticationResult authResult = await App.IdentityClientApp.AcquireTokenAsync(Scopes);

                TokenForUser = authResult.Token;
                Expiration = authResult.ExpiresOn;
            }

            return TokenForUser;
        }

        //Sign out:
        public static void SignOut()
        {
            foreach (var user in App.IdentityClientApp.Users)
            {
                user.SignOut();
            }
            graphClient = null;
            TokenForUser = null;

        }
    }
}
