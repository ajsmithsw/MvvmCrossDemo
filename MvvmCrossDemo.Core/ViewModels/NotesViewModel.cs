using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MvvmCrossDemo.Core.Messages;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NotesViewModel : MvxViewModel
	{
		INotesService _notesService;
		MvxSubscriptionToken _token;

		ObservableCollection<NotesCellViewModel> _notes;
		public ObservableCollection<NotesCellViewModel> Notes
		{
			get
			{
				return _notes;
			}
		}

		public NotesViewModel(INotesService notesService, IMvxMessenger messenger)
		{
			_notesService = notesService;

			_notes = new ObservableCollection<NotesCellViewModel>();
			foreach (var note in _notesService.GetNotes())
			{
				_notes.Add(new NotesCellViewModel(note));
			}

			RaisePropertyChanged(() => Notes);

			SubscribeToMessages(messenger);
		}

		public void AddNote(NewNoteMessage message)
		{
			_notesService.AddNote(message.NewNote);
			RaisePropertyChanged(() => Notes);
		}

		public IMvxCommand CreateNewNote
		{
			get
			{
				return new MvxCommand(() => { ShowViewModel<MainViewModel>(); });
			}
		}

		public IMvxCommand OnItemClicked
		{
			get
			{
				return new MvxCommand<NotesCellViewModel>(ShowNote);
			}
		}

		void ShowNote(NotesCellViewModel vm)
		{
			Debug.WriteLine("note title: {0}", vm.Title);
		}

		void SubscribeToMessages(IMvxMessenger messenger)
		{
			_token = messenger.Subscribe<NewNoteMessage>(AddNote);
		}
	}
}
