using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Auth0Sample.View
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
