using System;
using MvvmCross.iOS.Views;
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

			//TODO - Bindings
		}

		//TODO - implement table view
	}
}

