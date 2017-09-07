using System;
namespace MvvmCrossDemo.Core.Services
{
	public interface ILoginService
	{
		bool TryLogin(string username, string password);
	}
}
