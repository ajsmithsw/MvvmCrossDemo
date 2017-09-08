using MvvmCross.Plugins.Messenger;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Core.Messages
{
	public class NewNoteMessage : MvxMessage
	{
		public Note NewNote { get; private set; }

		public NewNoteMessage(object sender, Note note) : base(sender)
		{
			NewNote = note;
		}
	}
}
