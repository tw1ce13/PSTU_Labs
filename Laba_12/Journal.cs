using System;
namespace Laba_12
{
	public class Journal
	{
		public List<JournalEntry> list = new List<JournalEntry>();
		public void OnCollectionCountChange(object source, CollectionHandlerEventArgs args)
		{
			list.Add(new JournalEntry(args.Name, args.ChangeType, args.ChangeObject));
		}


		public void OnCollectionReferenceChange(object source, CollectionHandlerEventArgs args)
		{
			list.Add(new JournalEntry(args.Name, args.ChangeType, args.ChangeObject));
		}


    }
}

