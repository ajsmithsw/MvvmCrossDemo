using System;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NotesCellViewModel : MvxViewModel
	{
		Note _note;

		public NotesCellViewModel(Note note)
		{
			_note = note;
		}

		public string Title
		{
			get { return _note.Title; }
		}

		public string Detail
		{
			get { return _note.Detail; }
		}

		public string Summary
		{
			get { return _note.Summary; }
		}
	}
}
