using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCrossDemo.Core.ViewModels;
using MvvmCrossDemo.iOS.Views.CustomCells;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
	public partial class NotesView : MvxViewController
	{
		public NotesView() : base("NotesView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			EdgesForExtendedLayout = UIRectEdge.None;

			var source = new MvxSimpleTableViewSource(TableView, "NotesViewCell", NotesViewCell.Key);
			source.DeselectAutomatically = true;

			TableView.RowHeight = 60;

			var set = this.CreateBindingSet<NotesView, NotesViewModel>();
			set.Bind(AddNoteButton).To(vm => vm.CreateNewNote);
			set.Bind(source).For(x => x.SelectionChangedCommand).To(vm => vm.OnItemClicked);
			set.Bind(source).To(vm => vm.Notes);
			set.Apply();

			TableView.Source = source;
			TableView.ReloadData();
		}
	}
}

