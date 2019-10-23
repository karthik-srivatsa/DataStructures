using Array;
using System;

namespace DataSturctures.Demos
{
    public class ArrayDemo : IShowDemo
    {
        private Array<string> array;
        public string DefineDataStructure()
        {
            return @"
Array is the basic data structure which holds the items in contigous memory. It gives basic operations like 
1)Add 
2)Remove At
3)Index Of etc";
        }

        public void PerformDemo()
        {
            PrintSpaces();
            Console.WriteLine("Performing Array Demo");
            Console.WriteLine("Creating array of trype strings of length 3...");
            array = new Array<string>(3);
            Console.WriteLine($"Array created.{Environment.NewLine}Length of the Array: {array.Count}.{Environment.NewLine}Size of Array is {array.MaxSize()}");
            PrintSpaces();
            Console.WriteLine("Inserting the items...");
            array.Add("Harman");
            array.Add("SymphonyAi");
            array.Add("Resideo");
            PrintSpaces();
            PrintArray();
            PrintSpaces();
            Console.WriteLine("Now the array is full. Trying to add new item. Expectation is resize in array");
            array.Add("Odessa");
            Console.WriteLine($"New Item added.{Environment.NewLine}Current Length of the Array: {array.Count}.{Environment.NewLine}Current Size of Array is {array.MaxSize()}");
            PrintArray();
            PrintSpaces();
            Console.WriteLine("Checking the index of the items");
            Console.WriteLine($"The index of Resideo is {array.IndexOf("Resideo")}");
            Console.WriteLine($"The index of MIT is {array.IndexOf("MIT")}");
            PrintSpaces();
            Console.WriteLine("Removing items from array.\nRemoving Resideo");
            array.RemoveAt(array.IndexOf("Resideo"));
            Console.WriteLine($"Current Length of the Array: {array.Count}.{Environment.NewLine}Current Size of Array is {array.MaxSize()}");
            Console.WriteLine("Accessing array using index");
            for(int i = 0; i < array.Count; i++)
                Console.WriteLine(array[i]);
            Console.WriteLine("Array operation completed");
        }

        private void PrintArray()
        {
            Console.WriteLine("Printing the Array items");
            foreach (var item in array)
                Console.WriteLine(item);
        }

        private void PrintSpaces(int lines = 3)
        {
            for(int i = 1; i <= lines; i++)
                Console.WriteLine();
        }
    }
}
