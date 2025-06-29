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
                "\n1) StopWatch shows OOP abstraction" +
                "\n2) StackOverflowPost shows OOP encaplsulation" + 
                "\n3) implemeting Stack LIFO datastructure using inheritance" +
                "\n4) Mocking SQL db connection using polymorphism"
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
                case "4":
                    DbCommand_Program.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}