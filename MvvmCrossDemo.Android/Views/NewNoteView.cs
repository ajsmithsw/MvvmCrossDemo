using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace MvvmCrossDemo.Android.Views
{
	[Activity(Label = "View for NewNoteViewModel")]
	public class NewNoteView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.NewNoteView);
		}
	}
}
