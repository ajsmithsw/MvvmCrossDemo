using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class LoginViewModel : MvxViewModel
	{
		ILoginService _loginService;

		public LoginViewModel(ILoginService loginService)
		{
			_loginService = loginService;
		}

		string _username;
		public string Username
		{ 
			get 
			{
				return _username;
			}
			set
			{
				_username = value;
				RaisePropertyChanged(() => Username);
			}
		}

		string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				RaisePropertyChanged(() => Password);
			}
		}

		public string TryAgainText => "Try again!";

		bool _tryAgainTextVisible;
		public bool TryAgainTextVisible
		{ 
			get
			{
				return _tryAgainTextVisible;
			}
			set 
			{
				_tryAgainTextVisible = value;
				RaisePropertyChanged(() => TryAgainTextVisible);
			}
		}

		public ICommand LoginCommand => new MvxCommand(Login);
		void Login()
		{
			var authSuccess = _loginService.TryLogin(Username, Password);

			if (authSuccess)
			{
				ShowViewModel<MainViewModel>();
			}
			else
			{
				PromptForRetry();
			}
		}

		void PromptForRetry()
		{
			Username = "";
			Password = "";
			TryAgainTextVisible = true;
		}
	}
}
