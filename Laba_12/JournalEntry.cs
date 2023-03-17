using System;
namespace Laba_12
{
	public class JournalEntry
	{
		public JournalEntry(string name, string changeType, Place place)
		{
			Name = name;
			ChangeType = changeType;
			ChangeObject = place;
		}
		public string Name { get; set; }
		public string ChangeType { get; set; }
        public Place ChangeObject { get; set; }

        public override string ToString()
        {
			return "Название коллекции " + this.Name + " Тип изменения " + ChangeType + "\n Объект изменения " + ChangeObject.ToString();
        }
    }
}

