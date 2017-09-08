using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
	public partial class NoteDetailsView : MvxViewController
	{
		public NoteDetailsView() : base("NoteDetailsView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			EdgesForExtendedLayout = UIRectEdge.None;

			var set = this.CreateBindingSet<NoteDetailsView, NoteDetailsViewModel>();
			set.Bind(TitleLabel).To(vm => vm.Title);
			set.Bind(DetailTextView).To(vm => vm.Detail);
			set.Apply();
		}
	}
}

