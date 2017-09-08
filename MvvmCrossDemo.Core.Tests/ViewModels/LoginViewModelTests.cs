using System;
using System.Diagnostics;
using Moq;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;
using MvvmCrossDemo.Core.Services;
using MvvmCrossDemo.Core.ViewModels;
using NUnit.Framework;

namespace MvvmCrossDemo.Core.Tests.ViewModels
{
	[TestFixture]
	public class LoginViewModelTests : MvxIoCSupportingTest
	{
		Mock<ILoginService> _loginService;

		[SetUp]
		public void TestSetUp()
		{
			Setup();

			_loginService = new Mock<ILoginService>();
		}

		[Test]
		public void OnLoginFailureResetTextFields()
		{
			_loginService.Setup(x => x.TryLogin("user", "password")).Returns(false);

			var ViewModel = CreateViewModel();
			ViewModel.Username = "user";
			ViewModel.Password = "password";

			ViewModel.LoginCommand.Execute(null);

			Assert.That(ViewModel.Username, Is.EqualTo(""));
			Assert.That(ViewModel.Password, Is.EqualTo(""));
		}

		[Test]
		public void OnLoginSuccessNavigateToMainView()
		{
			_loginService.Setup(x => x.TryLogin("success", "success")).Returns(true);

			var ViewModel = CreateViewModel();
			ViewModel.Username = "success";
			ViewModel.Password = "success";

			ViewModel.LoginCommand.Execute(null);

			Assert.That(MockDispatcher.Requests.Count, Is.EqualTo(1));
			Assert.That(MockDispatcher.Requests[0], Is.TypeOf(typeof(MvxViewModelRequest)));
			Assert.That((MockDispatcher.Requests[0] as MvxViewModelRequest).ViewModelType == typeof(MainViewModel));
		}


		LoginViewModel CreateViewModel()
		{
			return new LoginViewModel(_loginService.Object);
		}






		#region setup
		protected BaseMvxDispatcher MockDispatcher
		{
			get;
			private set;
		}

		protected override void AdditionalSetup()
		{
			MockDispatcher = new BaseMvxDispatcher();
			Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
		}
		#endregion
	}
}
