using System;
using Moq;
using MvvmCrossDemo.Core.Services;
using MvvmCrossDemo.Core.ViewModels;
using NUnit.Framework;

namespace MvvmCrossDemo.Core.Tests.ViewModels
{
	[TestFixture]
	public class LoginViewModelTests
	{
		Mock<ILoginService> _loginService;

		[SetUp]
		public void TestSetUp()
		{
			_loginService = new Mock<ILoginService>();
		}

		[Test]
		public void OnLoginFailureResetTextFields()
		{
			_loginService.Setup(x => x.TryLogin("user", "password")).Returns(false);

			var ViewModel = CreateViewModel();
			ViewModel.Username = "user";
			ViewModel.Password = "password";

			ViewModel.LoginCommand.Execute(this);

			Assert.That(ViewModel.Username, Is.EqualTo(""));
			Assert.That(ViewModel.Password, Is.EqualTo(""));
		}

		LoginViewModel CreateViewModel()
		{
			return new LoginViewModel(_loginService.Object);
		}

	}
}
