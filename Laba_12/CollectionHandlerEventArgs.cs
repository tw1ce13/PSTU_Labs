using System;
namespace Laba_12
{
	public class CollectionHandlerEventArgs : System.EventArgs
	{

		public string Name { get; set; }
		public string ChangeType { get; set; }
		public Place ChangeObject { get; set; }
		public CollectionHandlerEventArgs(string name, string type, Place place)
		{
			Name = name;
            ChangeType = type;
            ChangeObject = place; 
		}
        public override string ToString()
        {
			return "Название коллекции " + Name + " Информация об изменении " + ChangeType + "\n Изменяемый объект " + ChangeObject.ToString();
        }
    }
}

