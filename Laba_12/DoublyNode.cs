using System;
namespace Laba_12
{
	class DoublyNode<T>
	{
		public DoublyNode()
		{

		}
		public DoublyNode(T data)
		{
			Data = data;
		}
		public T Data { get; set; }
		public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
}

