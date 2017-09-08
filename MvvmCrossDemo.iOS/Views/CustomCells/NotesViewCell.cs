using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views.CustomCells
{
	public partial class NotesViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("NotesViewCell");
		public static readonly UINib Nib;

		static NotesViewCell()
		{
			Nib = UINib.FromName("NotesViewCell", NSBundle.MainBundle);
		}

		protected NotesViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<NotesViewCell, NotesCellViewModel>();
				set.Bind(TitleLabel).To(vm => vm.Title);
				set.Bind(SummaryLabel).To(vm => vm.Summary);
				set.Apply();
			});
		}
	}
}
