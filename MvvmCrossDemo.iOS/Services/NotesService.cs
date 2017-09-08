using System;
using System.Collections.Generic;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.iOS.Services
{
	public class NotesService : INotesService
	{
		List<Note> _notes;

		public NotesService()
		{
			_notes = new List<Note> {
				new Note { Title = "iOS note 1", Detail = "This is a note that demonstrates an observable collection binding on iOS" },
				new Note { Title = "iOS note 2", Detail = "This is another great note!" } 
			};
		}

		public void AddNote(Note note)
		{
			_notes.Add(note);
		}

		public IList<Note> GetNotes()
		{
			return _notes;
		}
	}
}
