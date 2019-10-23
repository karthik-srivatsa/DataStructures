using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataSturctures
{
    partial class Program
    {
        public enum SupportedDataStructures
        {
            Array = 1
        }

        public static IEnumerable<Type> GetDemoClasses() => Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass).ToList();

        public static bool ContinueDemo()
        {
            Console.WriteLine("Do you want to continue demo? Y/N");
            return string.Equals(Console.ReadKey().KeyChar.ToString().ToUpper(), "Y");
        }

                                                 
    }
}
