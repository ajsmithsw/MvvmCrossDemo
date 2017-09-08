using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;

namespace MvvmCrossDemo.Core.Tests
{
	public class BaseMvxTest : MvxIoCSupportingTest
	{
		#region setup
		protected BaseMvxDispatcher MockDispatcher
		{
			get;
			private set;
		}

		protected override void AdditionalSetup()
		{
			MockDispatcher = new BaseMvxDispatcher();
			Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
		}
		#endregion
	}

	public class BaseMvxDispatcher : MvxMainThreadDispatcher, IMvxViewDispatcher
	{
		public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();
		public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			Hints.Add(hint);
			return true;
		}

		public bool RequestMainThreadAction(Action action, bool maskExceptions = true)
		{
			action();
			return true;
		}

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			Requests.Add(request);
			return true;
		}
	}
}
