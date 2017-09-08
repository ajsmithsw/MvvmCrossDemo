using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using System;
using MvvmCross.Platform;
using MvvmCrossDemo.Core.Services;
using MvvmCrossDemo.Android.Services;

namespace MvvmCrossDemo.Android
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			RegisterTypes();

			return new Core.App();
		}

		void RegisterTypes()
		{
			Mvx.RegisterType<ILoginService, LoginService>();
			Mvx.RegisterType<INotesService, NotesService>();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
