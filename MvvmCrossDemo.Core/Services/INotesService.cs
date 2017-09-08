using System;
using System.Collections.Generic;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Core.Services
{
	public interface INotesService
	{
		IList<Note> GetNotes();
		void AddNote(Note note);
	}
}
