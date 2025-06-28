using System;
using MoshHamedani_C__imtermediate;

// uses a single Main method that lets to choose which file to run:
namespace MoshHamedani_Csharp_imtermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose exercise: " +
                "\n1) StopWatch " +
                "\n2) StackOverflowPost" + 
                "\n3) Stack LIFO datastructure"
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
                case "3":
                    StackProgram.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}