using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;

namespace MvvmCrossDemo.Core.Tests
{
	public class BaseMvxDispatcher : MvxMainThreadDispatcher, IMvxViewDispatcher
	{
		public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();
		public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

		public BaseMvxDispatcher()
		{
		}

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
