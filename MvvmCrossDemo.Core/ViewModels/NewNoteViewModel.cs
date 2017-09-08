using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MvvmCrossDemo.Core.Messages;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Core.ViewModels
{
	public class NewNoteViewModel : MvxViewModel
	{
		IMvxMessenger _messenger;

		public NewNoteViewModel(IMvxMessenger messenger)
		{
			_messenger = messenger;
		}

		public Note Note
		{
			get 
			{ 
				return new Note 
				{ 
					Title = Title, 
					Detail = Detail
				};  
			}
		}

		string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		string _detail;
		public string Detail
		{ 
			get { return _detail; }
			set { _detail = value; }
		}

		public IMvxCommand Save
		{
			get 
			{
				return new MvxCommand(() => {
					if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Detail))
					{
						var message = new NewNoteMessage(this, Note);

						_messenger.Publish(message);
						Close(this);
					}
				});
			}
		}

	}
}
