using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCrossDemo.Core.Services;
using UIKit;

namespace MvvmCrossDemo.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}

		public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window, IMvxIosViewPresenter presenter)
			: base(applicationDelegate, presenter)
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
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
