using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
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

			var set = this.CreateBindingSet<LoginView, LoginViewModel>();

			set.Bind(TryAgainLabel).To(vm => vm.TryAgainText);
			set.Bind(TryAgainLabel).For(x => x.Hidden).To(vm => vm.TryAgainTextVisible);

			//set.Bind(Button).To(vm => vm.ResetTextCommand);
			set.Apply();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

