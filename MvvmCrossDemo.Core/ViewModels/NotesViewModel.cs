using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NotesViewModel : MvxViewModel
	{
		INotesService _notesService;

		ObservableCollection<NotesCellViewModel> _notes;
		public ObservableCollection<NotesCellViewModel> Notes
		{
			get
			{
				return _notes;
			}
		}

		public NotesViewModel(INotesService notesService)
		{
			_notesService = notesService;

			_notes = new ObservableCollection<NotesCellViewModel>();
			foreach (var note in _notesService.GetNotes())
			{
				_notes.Add(new NotesCellViewModel(note));
			}

			RaisePropertyChanged(() => Notes);
		}

		public void AddNote(Note note)
		{
			_notesService.AddNote(note);
			RaisePropertyChanged(() => Notes);
		}

		public ICommand OnItemClicked
		{
			get
			{
				return new MvxCommand(() => { Debug.WriteLine("clicked an item"); });
			}
		}

	}
}
