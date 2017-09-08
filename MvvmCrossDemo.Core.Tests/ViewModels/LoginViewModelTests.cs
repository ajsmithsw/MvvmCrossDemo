using Moq;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Services;
using MvvmCrossDemo.Core.ViewModels;
using NUnit.Framework;

namespace MvvmCrossDemo.Core.Tests.ViewModels
{
	[TestFixture]
	public class LoginViewModelTests : BaseMvxTest
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

		[Test]
		public void OnLoginFailureTryAgainPromptAppears()
		{
			_loginService.Setup(x => x.TryLogin("user", "password")).Returns(false);

			var ViewModel = CreateViewModel();
			ViewModel.Username = "user";
			ViewModel.Password = "password";

			ViewModel.LoginCommand.Execute(null);

			Assert.IsTrue(ViewModel.TryAgainTextVisible);
		}


		LoginViewModel CreateViewModel()
		{
			return new LoginViewModel(_loginService.Object);
		}
	}
}
