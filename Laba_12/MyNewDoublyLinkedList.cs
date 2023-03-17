using System;
namespace Laba_12
{
	public class MyNewDoublyLinkedList : MyDoublyLinkedList
	{
		public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
		public event CollectionHandler? CollectionCountChange;
		public event CollectionHandler? CollectionReferenceChange;

		public string name { get; set; }


		public MyNewDoublyLinkedList()
		{

		}


		public virtual void OnCollectionCountChange(object source, CollectionHandlerEventArgs args)
		{
			if (CollectionCountChange != null)
				CollectionCountChange(source, args);
		}


		public virtual void OnCollectionReferenceChange(object source, CollectionHandlerEventArgs args)
		{
			if (CollectionReferenceChange != null)
				CollectionReferenceChange(source, args);
		}

		public override bool Remove(Place data)
		{
			OnCollectionCountChange(this, new CollectionHandlerEventArgs(this.name, "delete", data));
			return base.Remove(data);
		}


		public override Place this[int index]
		{ 
			get
			{
				return base[index];
			}
			set
			{
				base[index] = value;
				OnCollectionReferenceChange(this, new CollectionHandlerEventArgs(this.name, "change", value));
			}
		}

        public override void Add(Place data)
        {
			OnCollectionCountChange(this, new CollectionHandlerEventArgs(this.name, "add", data));
            base.Add(data);
        }
    }
}

