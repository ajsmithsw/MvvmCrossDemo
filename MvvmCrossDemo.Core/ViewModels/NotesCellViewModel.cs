using System;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NotesCellViewModel : MvxViewModel
	{
		public Note Note;

		public NotesCellViewModel(Note note)
		{
			Note = note;
		}

		public string Title
		{
			get { return Note.Title; }
		}

		public string Detail
		{
			get { return Note.Detail; }
		}

		public string Summary
		{
			get { return Note.Summary; }
		}
	}
}
