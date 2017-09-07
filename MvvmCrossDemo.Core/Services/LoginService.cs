using System;
namespace MvvmCrossDemo.Core.Services
{
	public class LoginService : ILoginService
	{
		public LoginService()
		{
		}

		public bool TryLogin(string username, string password)
		{
			return username == password;
		}
	}
}
