using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MvvmCrossDemo.Core.Messages;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NotesViewModel : MvxViewModel
	{
		INotesService _notesService;
		IMvxMessenger _messenger;
		List<MvxSubscriptionToken> _subscriptionTokens;

		public NotesViewModel(INotesService notesService, 
		                      IMvxMessenger messenger)
		{
			_notesService = notesService;
			_messenger = messenger;

			RaisePropertyChanged(() => Notes);

			SubscribeToMessages();
		}

		ObservableCollection<NotesCellViewModel> _notes;
		public ObservableCollection<NotesCellViewModel> Notes
		{
			get
			{
				PopulateNotes();
				return _notes;
			}
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
				return new MvxCommand(() => 
				{ 
					ShowViewModel<NewNoteViewModel>(); 
				});
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
			ShowViewModel<NoteDetailsViewModel>(new NoteDetailsParameterValues { Title = vm.Title, Detail = vm.Detail });
		}

		void PopulateNotes()
		{
			_notes = new ObservableCollection<NotesCellViewModel>();
			foreach (var note in _notesService.GetNotes())
				_notes.Add(new NotesCellViewModel(note));
		}

		void SubscribeToMessages()
		{
			_subscriptionTokens = new List<MvxSubscriptionToken>();
			_subscriptionTokens.Add(_messenger.Subscribe<NewNoteMessage>(AddNote));
		}
	}
}
