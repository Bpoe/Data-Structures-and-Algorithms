using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structures_and_Algorithms
{
    public class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> data = new LinkedList<T>();

        public Stack()
        {
        }

        public Stack(IEnumerable<T> collection)
        {
            this.AddRange(collection);
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        #region Public Methods

        public void AddRange(IEnumerable<T> range)
        {
            if (range == null)
            {
                throw new ArgumentNullException("range");
            }

            foreach(T item in range)
            {
                this.Push(item);
            }
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public bool Contains(T value)
        {
            return this.data.Contains(value);
        }

        public T Peek()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.data.First.Value;
        }

        public T Pop()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            LinkedListNode<T> node = this.data.First;
            this.data.RemoveFirst();
            return node.Value;
        }

        public void Push(T value)
        {
            this.data.AddFirst(value);
        }

        #endregion Public Methods

        #region IEnumerable<T>

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="LinkedList&lt;T&gt;" />.
        /// </summary>
        /// <returns>An enumerator that iterates through the <see cref="LinkedList&lt;T&gt;" /></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedList<T>.Enumerator(this.data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerable<T>
    }
}
