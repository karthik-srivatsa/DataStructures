using System;
using System.Collections;

namespace Array
{
    /// <summary>
    /// Generic class which provides basic array operation
    /// Takes any Type which can be comparable 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Array<T>: IEnumerable where T : IComparable
    {
        private long size;

        private T[] array; 
        public int Count { get; private set; }
        /// <summary>
        /// Returns the current maximum capacity of Array
        /// </summary>
        /// <returns></returns>
        public long MaxSize () =>  size;

        public Array(int length)
        {
            size = length;
            array = new T[size];
        }

        /// <summary>
        /// Indexer. To access array items using object
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException();
                return array[index];
            }
        }
        
        /// <summary>
        /// Add new item to an array.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (Count == size)
                ResizeArray();
            array[Count++] = item;
        }

        /// <summary>
        /// To use the object in foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return array[i];
        }

        /// <summary>
        /// Retrurns the index of first occurance of the item in array
        /// Returns -1 by default if not found
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (array[i].CompareTo(item) == 0)
                    return i;
            return -1;
        }

        /// <summary>
        /// Insert the passed item at given index
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void InsertAt(T item, int index)
        {
            if (index < 0)
                throw new ArgumentException("Array cannot have negative index");
            if (index > Count)
                throw new ArgumentException($"Insertion cannot happen beyond the count of array");

            if (Count == size)
                ResizeArray();

            for (int i = Count; i > index; i--)
                array[i] = array[i - 1];

            array[index] = item;
            Count++;
        }

        /// <summary>
        /// Removes the item at given index if presents
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException();

            while(index < Count)
            {
                array[index] = array[index + 1];
                index++;
            }
            array[Count] = default;
            Count--;
        }
        
        /// <summary>
        /// Reverse the order of the array
        /// </summary>
        public void Reverse()
        {
            var tempArr = new T[size];
            for (int i = Count - 1; i >= 0; i--)
                tempArr[Count - i - 1] = array[i];

            array = tempArr;
        }

        private void ResizeArray()
        {
            var tempArr = new T[size*2];
            for (int i = 0; i < size; i++)
                tempArr[i] = array[i];

            array = tempArr;
            size *= 2;
        }

    }
}
