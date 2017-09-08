using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
	public partial class NewNoteView : MvxViewController
	{
		public NewNoteView() : base("NewNoteView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			EdgesForExtendedLayout = UIRectEdge.None;

			var set = this.CreateBindingSet<NewNoteView, NewNoteViewModel>();
			set.Bind(TitleTextField).To(vm => vm.Title);
			set.Bind(DetailTextField).To(vm => vm.Detail);
			set.Bind(SaveButton).To(vm => vm.Save);
			set.Apply();
		}
	}
}

