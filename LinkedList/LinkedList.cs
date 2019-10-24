
using System;

namespace LinkedList
{
    public class LinkedList<T> where T : IComparable
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { get; private set; }

        /// <summary>
        /// adding element at the beginning of the List
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            var node = new Node<T> { Item = item };

            node.Next = _head;
            _head = node;

            if (_tail == null)
                _tail = node;
                
            Count++;
        }

        /// <summary>
        /// Adds the item in last
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            var node = new Node<T> { Item = item };
            
            if (_head == null)
                _head = node;
            else
                _tail.Next = node;
            
            _tail = node;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            int index = 0;
            if (_head == null)
                return -1;

            var temp = _head;
            do
            {
                if (item.CompareTo(temp.Item) == 0)
                    return index;
                index++;
                temp = temp.Next;
            } while (temp.Next != null);

            return -1;
        }
    }
}
