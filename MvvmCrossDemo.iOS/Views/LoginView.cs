using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.iOS.Views
{
	public partial class LoginView : MvxViewController
	{
		public LoginView() : base("LoginView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Set the bindings:
			var set = this.CreateBindingSet<LoginView, LoginViewModel>();
			set.Bind(TryAgainLabel).To(vm => vm.TryAgainText);
			set.Bind(TryAgainLabel).For(x => x.Hidden).To(vm => vm.TryAgainTextHidden);
			set.Bind(UsernameField).To(vm => vm.Username);
			set.Bind(PasswordField).To(vm => vm.Password);
			set.Bind(LoginButton).To(vm => vm.LoginCommand);
			set.Apply();
		}
	}
}

