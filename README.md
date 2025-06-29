# Mosh Hamedani C# Intermediate Exercises

This repository contains solutions to selected exercises from Mosh Hamedani's C# Intermediate course. The project is designed for self-study and practice, focusing on object-oriented programming concepts and .NET Framework 4.7.2.

## Project Structure

- **_imtermediate/StopWatch.cs**  
  Implements a custom `StopWatch` class that simulates a stopwatch with start, stop, and reset functionality. It demonstrates exception handling and proper state management.

- **_imtermediate/StackOverflowPost.cs**  
  Models a simple StackOverflow post with properties for title, description, creation time, and voting (upvote/downvote). It demonstrates encapsulation and basic class design.

- **_imtermediate/Stack_LIFO.cs**  
  Implements a custom `Stack` class that simulates a Last-In-First-Out (LIFO) data structure. It includes methods for pushing, popping, peeking, and clearing items, along with exception handling for invalid operations.

- **_imtermediate\DbConnection.cs**  
  Implements an abstract `DbConnection` class and derived classes for `MsSqlConnection` and `OracleConnection`. Demonstrates polymorphism and exception handling. Also includes a `DbCommand` class to execute SQL commands.

- **_imtermediate/Program.cs**  
  Entry point for the application. Allows the user to select and run exercises from the console.

## How to Run

1. Open the solution in Visual Studio 2022.
2. Build the project (targeting .NET Framework 4.7.2).
3. Run the application.  
   You will be prompted to choose an exercise:
   - Enter `1` for the StopWatch demo.
   - Enter `2` for the StackOverflowPost demo.
   - Enter `3` for the Stack demo.
   - Enter `4` for the DbConnection and DbCommand demo.

## Learning Goals

- Practice with C# classes, properties, and methods.
- Understand encapsulation and state management.
- Implement simple exception handling.
- Gain experience with console applications in .NET.
- Learn about data structures like Stack and their operations.
- Understand polymorphism and abstract class design.

## Notes

- This project is for educational purposes and follows the coding style and requirements from the course exercises.
- All code is self-contained and can be extended for further practice.

---