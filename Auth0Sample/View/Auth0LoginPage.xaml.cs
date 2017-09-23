using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using Auth0Sample.Enums;
using Xamarin.Forms;
using Auth0Sample.Infrastructure.Services.Interfaces;
using Auth0Sample.ViewModel;

namespace Auth0Sample.View
{
	public partial class Auth0LoginPage : ContentPage
	{
		public GrantType GrantType { get; set; }
		public IAccountService AccountService { get; set; }


		public Auth0LoginPage(GrantType grantType)
		{
			InitializeComponent();
			AccountService = ((Auth0LoginViewModel)BindingContext).AccountService;
			GrantType = grantType;
		}
	}
}
