using System;

namespace MvvmCrossDemo.Core.Services
{
	public class LoginService : ILoginService
	{
		public bool TryLogin(string username, string password)
		{
			return username == password 
				&& !string.IsNullOrWhiteSpace(username) 
				          && !string.IsNullOrWhiteSpace(password);
		}
	}
}
