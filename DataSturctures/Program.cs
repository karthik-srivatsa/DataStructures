using System;
using System.Linq;

namespace DataSturctures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Structures Demo");
            while (true)
            {
                Console.WriteLine("Please choose the Data Structure");
                foreach (var item in Enum.GetValues(typeof(SupportedDataStructures)))
                {
                    Console.WriteLine($"{(int)item}. {item.ToString()}");
                }
                if(int.TryParse(Console.ReadLine(), out int key) && Enum.IsDefined(typeof(SupportedDataStructures), key))
                {
                    try
                    {
                        var demo = (IShowDemo)Activator.CreateInstance(GetDemoClasses().Where(t => t.Name.StartsWith(((SupportedDataStructures)key).ToString())).First());
                        Console.WriteLine(demo.DefineDataStructure());
                        demo.PerformDemo();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Something went wrong");
                        Console.WriteLine($"Details: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                if (!ContinueDemo())
                    break;
                Console.WriteLine();
            }
        }
    }
}
