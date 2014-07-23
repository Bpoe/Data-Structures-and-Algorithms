using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structures_and_Algorithms
{
    public class Queue<T> : IEnumerable<T>
    {
        #region Private Fields

        private LinkedList<T> data = new LinkedList<T>();

        #endregion Private Fields

        #region Constructors

        public Queue()
        {
        }

        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.AddRange(collection);
        }

        #endregion Constructors

        #region Public Properties

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach(T item in collection)
            {
                this.Enqueue(item);
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

        public void Enqueue(T value)
        {
            this.data.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            LinkedListNode<T> node = this.data.First;
            this.data.RemoveFirst();
            return node.Value;
        }

        public T Peek()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return this.data.First.Value;
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
