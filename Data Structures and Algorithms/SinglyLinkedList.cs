using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Data_Structures_and_Algorithms
{
    /// <summary>
    /// Represents a singly linked list
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
    [ComVisible(false)]
    public class SinglyLinkedList<T> : ICollection<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedList&lt;T&gt;"/> class that is empty.
        /// </summary>
        public SinglyLinkedList()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedList&lt;T&gt;"/> class that contains elements copied from the specified IEnumerable.
        /// </summary>
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            this.AddRange(collection);
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets the first node of the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        public LinkedListNode<T> First { get; protected set; }

        /// <summary>
        /// Gets the last node of the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        public LinkedListNode<T> Last { get; protected set; }

        /// <summary>
        /// Gets the number of nodes actually contained in the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="SinglyLinkedList&lt;T&gt;" /> is read-only. This value is always false.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Adds a new node containing the specified value to the <see cref="SinglyLinkedList&lt;T&gt;" /> after the specified <see cref="LinkedListNode&lt;T&gt;" />.
        /// </summary>
        /// <param name="node">The <see cref="LinkedListNode&lt;T&gt;" /> that the value will be added after</param>
        /// <param name="value">The value to add to the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        /// <returns>A new <see cref="LinkedListNode&lt;T&gt;" /> that contains the specified value.</returns>
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            this.AddAfter(node, newNode);
            return newNode;
        }

        /// <summary>
        /// Adds a new node to the <see cref="LinkedList&lt;T&gt;" /> after the specified <see cref="LinkedListNode&lt;T&gt;" />.
        /// </summary>
        /// <param name="node">The <see cref="LinkedListNode&lt;T&gt;" /> that the value will be added after</param>
        /// <param name="newNode">The <see cref="LinkedListNode&lt;T&gt;" /> to add to the <see cref="LinkedList&lt;T&gt;" />.</param>
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            this.ensureArgumentIsNotNull(node, "node");
            this.ensureArgumentIsNotNull(newNode, "newNode");

            newNode.Next = node.Next;
            node.Next = newNode;
            //newNode.List = this;

            this.Count++;

            if (node == this.Last)
            {
                this.Last = newNode;
            }
        }

        /// <summary>
        /// Adds a new node containing the specified value to the <see cref="SinglyLinkedList&lt;T&gt;" /> before the specified <see cref="LinkedListNode&lt;T&gt;" />.
        /// </summary>
        /// <param name="node">The <see cref="LinkedListNode&lt;T&gt;" /> that the value will be added before</param>
        /// <param name="value">The value to add to the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        /// <returns>A new <see cref="LinkedListNode&lt;T&gt;" /> that contains the specified value.</returns>
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            this.ensureArgumentIsNotNull(node, "node");

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            this.AddBefore(node, newNode);
            return newNode;
        }

        /// <summary>
        /// Adds a new node to the <see cref="LinkedList&lt;T&gt;" /> before the specified <see cref="LinkedListNode&lt;T&gt;" />.
        /// </summary>
        /// <param name="node">The <see cref="LinkedListNode&lt;T&gt;" /> that the value will be added before</param>
        /// <param name="newNode">The <see cref="LinkedListNode&lt;T&gt;" /> to add to the <see cref="LinkedList&lt;T&gt;" />.</param>
        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            this.ensureArgumentIsNotNull(node, "node");
            this.ensureArgumentIsNotNull(newNode, "newNode");

            if (this.First == node)
            {
                this.AddFirst(newNode);
                return;
            }

            LinkedListNode<T> previousNode = this.FindPreviousNode(node);
            this.AddAfter(previousNode, newNode);
        }

        /// <summary>
        /// Adds a new node containing the specified value at the start of the <see cref="SinglyLinkedList&lt;T&gt;" />. 
        /// </summary>
        /// <param name="value">The value to add at the start of the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        /// <returns>A new <see cref="LinkedListNode&lt;T&gt;" /> that contains the specified value.</returns>
        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            this.AddFirst(node);
            return node;
        }

        /// <summary>
        /// Adds the specified node at the start of the <see cref="SinglyLinkedList&lt;T&gt;" />. 
        /// </summary>
        /// <param name="node">The new <see cref="LinkedListNode&lt;T&gt;" /> to add at the start of the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        public void AddFirst(LinkedListNode<T> node)
        {
            this.ensureArgumentIsNotNull(node, "node");

            if (this.First == null)
            {
                this.AddFirstListNode(node);
                return;
            }

            node.Next = this.First;
            this.First = node;
            this.Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the <see cref="SinglyLinkedList&lt;T&gt;" />. 
        /// </summary>
        /// <param name="value">The value to add at the end of the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        /// <returns>A new <see cref="LinkedListNode&lt;T&gt;" /> that contains the specified value.</returns>
        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            this.AddLast(node);
            return node;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the <see cref="SinglyLinkedList&lt;T&gt;" />. 
        /// </summary>
        /// <param name="node">The new <see cref="LinkedListNode&lt;T&gt;" /> to add at the end of the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        public void AddLast(LinkedListNode<T> node)
        {
            this.ensureArgumentIsNotNull(node, "node");

            if (this.Last == null)
            {
                this.AddFirstListNode(node);
                return;
            }

            this.AddAfter(this.Last, node);
            this.Last = node;
        }

        /// <summary>
        /// Adds the values of specified collection at the end of the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        /// <param name="collection">The collection of values to add to add at the end of the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            this.ensureArgumentIsNotNull(collection, "collection");

            foreach (T item in collection)
            {
                this.AddLast(item);
            }
        }

        /// <summary>
        /// Find the first occurance of the specified value in the list
        /// </summary>
        /// <param name="value">The value to find</param>
        /// <returns>The first node that has the specified value</returns>
        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> current = this.First;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Removes a node from the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        /// <param name="node">The node to remove from the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        public void Remove(LinkedListNode<T> node)
        {
            this.ensureArgumentIsNotNull(node, "node");

            // If the node to remove is the first node, just call RemoveFirst()
            if (node == this.First)
            {
                this.RemoveFirst();
                return;
            }

            // Find the previous node
            LinkedListNode<T> previous = this.FindPreviousNode(node);

            // If previous is null, then we didn't find the node in the list.
            if (previous == null)
            {
                throw new InvalidOperationException("The node is not part of the list.");
            }

            // Set the previous nodes Next to the node to remove's Next (even if its null),
            // then set the node to remove's Next to null 
            previous.Next = node.Next;
            node.Next = null;

            // If the node to remove was the last node, point Last to the previous node
            if (node == this.Last)
            {
                this.Last = previous;
            }
        }

        /// <summary>
        /// Remove the first node from the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        public void RemoveFirst()
        {
            if (this.First == null)
            {
                return;
            }

            LinkedListNode<T> oldFirst = this.First;
            this.First = this.First.Next;
            oldFirst.Next = null;
            this.Count--;
        }

        /// <summary>
        /// Removes the last node from the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        public void RemoveLast()
        {
            this.Remove(this.Last);
        }

        #endregion Public Methods

        #region ICollection Methods

        /// <summary>
        /// Adds an item to the <see cref="SinglyLinkedList&lt;T&gt;" />. 
        /// </summary>
        /// <param name="item">The object to add to the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        public void Add(T item)
        {
            this.AddLast(item);
        }

        /// <summary>
        /// Removes all nodes from the <see cref="SinglyLinkedList&lt;T&gt;" />. 
        /// </summary>
        public void Clear()
        {
            while (this.First != null)
            {
                this.RemoveFirst();
            }
        }

        /// <summary>
        /// Determines whether the <see cref="SinglyLinkedList&lt;T&gt;" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        /// <returns>true if item is found; otherwise, false.</returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> node = this.Find(item);
            return node != null;
        }

        /// <summary>
        /// Copies the elements of the <see cref="SinglyLinkedList&lt;T&gt;" /> to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="SinglyLinkedList&lt;T&gt;" />. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex is less than 0.");
            }

            if (this.Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the source ICollection<T> is greater than the available space from arrayIndex to the end of the destination array.");
            }

            int i = arrayIndex;
            foreach (T item in this)
            {
                array[i] = item;
                i++;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="SinglyLinkedList&lt;T&gt;" />.</param>
        public bool Remove(T item)
        {
            LinkedListNode<T> node = this.Find(item);

            if (node == null)
            {
                return false;
            }

            this.Remove(node);
            return true;
        }

        #endregion ICollection Methods

        #region IEnumerable<T>

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="SinglyLinkedList&lt;T&gt;" />.
        /// </summary>
        /// <returns>An enumerator that iterates through the <see cref="SinglyLinkedList&lt;T&gt;" /></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedList<T>.Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Enumerator class for SinglyLinkedList
        /// </summary>
        public class Enumerator : IEnumerator<T>
        {
            /// <summary>
            /// The list to enumerator over
            /// </summary>
            private LinkedListNode<T> currentNode;

            /// <summary>
            /// The current node in the list
            /// </summary>
            private SinglyLinkedList<T> list;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> class.
            /// </summary>
            /// <param name="list">The <see cref="SinglyLinkedList&lt;T&gt;" /> to enumerate</param>
            public Enumerator(SinglyLinkedList<T> list)
            {
                this.list = list;
                this.Reset();
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            public T Current
            {
                get
                {
                    if (this.currentNode == null)
                    {
                        return default(T);
                    }

                    return this.currentNode.Value;
                }
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                // If the current node is null, set it the the First node
                // Return if current node is now null (if the list is empty, 
                // the first node will be null)
                if (this.currentNode == null)
                {
                    this.currentNode = this.list.First;
                    return this.currentNode != null;
                }
                
                // If the next node is null, we are at the end
                if (this.currentNode.Next == null)
                {
                    return false;
                }

                // Set the current node to the next node if there is a next node
                this.currentNode = this.currentNode.Next;
                return true;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                this.currentNode = null;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
            }
        }

        #endregion IEnumerable

        #region Private methods

        private LinkedListNode<T> FindPreviousNode(LinkedListNode<T> node)
        {
            // Find the previous node and the node to remove in the list
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = this.First;
            while (current != node && current != this.Last)
            {
                previous = current;
                current = current.Next;
            }

            // If current is not node, then we didn't find the node in the list.
            if (current != node)
            {
                return null;
            }

            return previous;
        }

        private void AddFirstListNode(LinkedListNode<T> node)
        {
            this.First = node;
            this.Last = node;
            this.Count = 1;
        }

        private void ensureArgumentIsNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        #endregion Private methods
    }
}
