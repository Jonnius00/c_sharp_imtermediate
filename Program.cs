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
                "\n4) Mocking SQL db connection using polymorphism + " +
                "\n5) Workflow Engine using interfaces"
                );

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(); StopWatchProgram.Run(); Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine(); StackOverflowPostProgram.Run(); Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine(); StackProgram.Run(); Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine(); DbCommand_Program.Run(); Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine(); WorkflowEngine_Program.Run(); Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}