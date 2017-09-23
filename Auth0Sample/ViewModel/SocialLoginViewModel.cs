using System;
using GalaSoft.MvvmLight;
using Auth0Sample.Infrastructure.Services.Interfaces;

namespace Auth0Sample.ViewModel
{
	public class Auth0LoginViewModel: ViewModelBase
	{
		private IAccountService _accountService;
		public IAccountService AccountService
		{
			get { return _accountService; }
		}

		public Auth0LoginViewModel(IAccountService accountService)
		{
			_accountService = accountService;
		}
	}
}
