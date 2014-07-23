using System;
using System.Runtime.InteropServices;

namespace Data_Structures_and_Algorithms
{
    /// <summary>
    /// Represents a doubly linked list node
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
    [ComVisible(false)]
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedListNode&lt;T&gt;"/> class that is empty.
        /// </summary>
        public LinkedListNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedListNode&lt;T&gt;"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value of the node</param>
        public LinkedListNode(T value) : this(value, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedListNode&lt;T&gt;"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value of the <see cref="LinkedListNode&lt;T&gt;"/>.</param>
        /// <param name="list">The <see cref="LinkedList&lt;T&gt;"/> that the <see cref="LinkedListNode&lt;T&gt;"/> belongs to.</param>
        internal LinkedListNode(T value, LinkedList<T> list)
        {
            this.Value = value;
            this.List = list;
            this.Previous = null;
            this.Next = null;
        }

        /// <summary>
        /// Gets or sets the value of the <see cref="LinkedListNode&lt;T&gt;"/>
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the next node of the <see cref="LinkedListNode&lt;T&gt;"/>
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Gets or sets the previous node of the <see cref="LinkedListNode&lt;T&gt;"/>
        /// </summary>
        public LinkedListNode<T> Previous { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LinkedList&lt;T&gt;"/> that the <see cref="LinkedListNode&lt;T&gt;"/> belongs to.
        /// </summary>
        public LinkedList<T> List { get; internal set; }

        /// <summary>
        /// Removes the Node from a list by clearing Previous, Next and List
        /// </summary>
        internal void Unlink()
        {
            this.Previous = null;
            this.Next = null;
            this.List = null;
        }
    }
}
