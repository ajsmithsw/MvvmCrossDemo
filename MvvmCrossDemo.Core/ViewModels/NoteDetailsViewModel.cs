using System;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NoteDetailsViewModel : MvxViewModel
	{
		public NoteDetailsViewModel()
		{
		}

		public void Init(NoteDetailsParameterValues values)
		{
			Title = values.Title;
			Detail = values.Detail;
		}

		string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				RaisePropertyChanged(() => Title);
			}
		}

		string _detail;
		public string Detail
		{
			get
			{
				return _detail;
			}
			set
			{
				_detail = value;
				RaisePropertyChanged(() => Detail);
			}
		}
	}
}
