using System;

/* Designing a class to simulate a Stopwatch.
It should provide two methods: Start and Stop. 
Call the Start() method first, and the Stop(). 
Then ask the Stopwatch about the duration between start and stop. 
Duration should be a value in TimeSpan. Display the duration on the console.

THe programm should be able to used Stopwatch multiple times. 
So Start and Stop might be called again and again. 
Make sure the duration value each time is calculated properly. 

The program shouldn't be able to run a Stopwatch twice in a row, 
because that may overwrite the initial start time. 
So the class should throw an InvalidOperationException if its started twice */
namespace MoshHamedani_Csharp_imtermediate
{
    internal class StopWatch
    {
        private DateTime? _start_time;
        private DateTime? _stop_time;
        private TimeSpan _duration;
        private bool _isRunning;

        public void Start() {
            if (_isRunning)
                throw new InvalidOperationException("Stopwatch is already running.");

            _start_time = DateTime.Now;
            _isRunning = true;
        }

        public void Stop() {
            if (!_isRunning) // Check if the stopwatch is actually running before stopping
                throw new InvalidOperationException("Stopwatch is already running.");
            _isRunning = false;

            _stop_time = DateTime.Now;
            // To access the actual DateTime value inside a nullable, uses the .Value property
            _duration += _start_time.Value - _stop_time.Value;
        }

        // provides controlled, read-only access to the stopwatch’s total measured duration,
        // while keeping the actual storage field _duration private.
        public TimeSpan Duration => _duration;

        public void Reset() {
            _start_time = null;
            _stop_time = null;
            _duration = TimeSpan.Zero;
            _isRunning = false;
        }

        public void ShowResult() { Console.WriteLine($"duration is {_duration}"); }
    }

    public class StopWatchProgram
    {
        public static void Run()
        {
            var watch = new StopWatch();
            watch.Start();
            System.Threading.Thread.Sleep(2000); // Simulate some work
            watch.Stop();
            watch.ShowResult();

            // Demonstrate exception handling if Start is called again without Stop
            /* add or remove / to switch this block 
            watch.Start();
            System.Threading.Thread.Sleep(1000);
            watch.Stop();
            watch.ShowResult();  // */

            // Demonstrate multiple uses
            watch.Reset();
            watch.Start();
            System.Threading.Thread.Sleep(500);
        }
    }
}