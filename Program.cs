using System;

// uses a single Main method that lets to choose which file to run:
namespace MoshHamedani_Csharp_imtermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose exercise: " +
                "\n1) StopWatch " +
                "\n2) StackOverflowPost"
                );

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    StopWatchProgram.Run();
                    break;
                case "2":
                    StackOverflowPostProgram.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}