using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba_12
{

	public class DoublyLinkedList<T>: IEnumerable<T> , ICollection<T>, IDisposable
	{
		private DoublyNode<T> head;
		private int count;
        private bool disposed = false;


        public DoublyLinkedList()
		{
			head = null;
			count = 0;
		}


		public DoublyLinkedList(int capacity)
		{
			count = capacity;
		}


		public DoublyLinkedList(DoublyLinkedList<T> values)
		{
			DoublyLinkedList <T> list = new DoublyLinkedList<T>();
			list = values.Clone();
		}

		public string name { get; set; }
		
		public virtual T this[int index]
		{
			get { return GetObject(index); }
			set
			{
				DoublyNode <T> current = head;
				int i = 0;
				while (i != index)
				{
					current = current.Next;
					i++;
				}
				current.Data = value;
			}
		}
		
		public virtual void Add(T data)
		{
			DoublyNode < T > node = new DoublyNode<T>(data);
			if (head == null)
			{
				head = node;
				head.Next = node;
				head.Previous = node;

			}
			else
			{
				node.Previous = head.Previous;
                node.Next = head;
                head.Previous.Next = node;
                head.Previous = node;

            }
			count++;
		}


		public virtual bool Remove(int j)
		{
			DoublyNode<T> current = head;
			int i = 0;
			if (head == null)
				return false;
			while (i != j)
			{
				current = current.Next;
				i++;
			}
			Remove(current.Data);
			return true;
		}


		public virtual bool Remove(T data)
		{
			DoublyNode<T> current = head;
			bool founded = false;
			DoublyNode<T> removeItem = null;
			if (count == 0)
			{
				Console.WriteLine("Список пустой. Добавьте элементы");
				
			}
			while (!founded)
			{
				if (current.Data.Equals(data))
                {
					removeItem = current;
					founded = true;
				}
				current = current.Next;
				if (current == head)
					break;
			}
			if (removeItem == null)
			{
				Console.WriteLine("Элемент не найден");
				return false;
			}
			else
			{
				if (removeItem == head)
					head = head.Next;
				removeItem.Previous.Next = removeItem.Next;
				removeItem.Next.Previous = removeItem.Previous;
				count--;

				return true;
			}
        }


		public int Count { get { return count; } }


		public bool IsReadOnly { get; }
		

        public void Clear()
		{
			head = null;
			count = 0;
		}


		public bool Contains(T data)
		{
			DoublyNode<T> current = head;
			if (current == null)
				return false;
            bool founded = false;
			while (!founded)
			{
				if (current.Data.Equals(data))
				{
					founded = true;
					return true;
				}
				current = current.Next;
				if (current == head)
					break;
			}
			return false;

        }


        public DoublyLinkedList<T> Clone()
        {
            DoublyLinkedList<T> listClone = new DoublyLinkedList<T>();
            DoublyNode<T> current = this.head;
            if (current != null)
            {
                foreach (var p in this)
				{
					listClone.Add(p);
				}
            }
            else
                Console.WriteLine("Клонируемый список пуст");
            return listClone;
        }


        public void CopyTo(T[] values, int count)
		{
			DoublyLinkedList<T> listClone = new DoublyLinkedList<T>();
			if (count != 0)
			{
				for (int i = 0; i < count; i++)
				{
					listClone.Add(values[i]);
				}
			}
        }


		public T GetObject(int n)
		{
			int count = 0;
			DoublyNode<T> current = this.head;
			if (current != null)
			{
				if (n == 0)
					return this.head.Data;
				while (count != n) 
				{
					current = current.Next; 
					count++;
				}
			}
			return current.Data;
		}


		public void Sort()
		{
			
		}


		public void Print()
		{
			DoublyNode<T> current = this.head;
			if (current != null)
			{
				Console.WriteLine(current.Data.ToString());
				current = current.Next;
				while (current != head)
				{
					Console.WriteLine(current.Data.ToString());
					current = current.Next;
				}
			}
		}


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        public void Dispose()
        {
			Dispose(true);
            GC.SuppressFinalize(this);

        }


        protected void Dispose(bool isDisposed)
		{
			if (disposed) return;
			if (isDisposed)
			{

			}
			disposed = true;
		}

		~DoublyLinkedList()
		{
			Console.Write("Деструктор");
			Dispose(false);
		}
    }
}

