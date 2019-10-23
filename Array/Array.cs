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
        public int Length { get; private set; }
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
        /// Add new item to an array.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (Length == size)
                ResizeArray();
            array[Length++] = item;
        }

        /// <summary>
        /// To use the object in foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
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
            for (int i = 0; i < Length; i++)
                if (array[i].CompareTo(item) == 0)
                    return i;
            return -1;
        }

        /// <summary>
        /// Removes the item at given index if presents
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Length)
                throw new IndexOutOfRangeException();

            while(index < Length)
            {
                array[index] = array[index + 1];
                index++;
            }
            array[Length] = default;
            Length--;
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
