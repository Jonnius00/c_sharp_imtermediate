using System;
using System.Collections.Generic;
using System.Linq;

namespace MoshHamedani_C__imtermediate
{
    public class Stack
    {
        // PROPERTIES
        private readonly List<object> _items;
        
        // expression-bodied member syntax, provides a concise way 
        // to define class members that return a single expression. 
        // public int Count { get{ return _items.Count; } }
        public int Count => _items.Count;
        public bool IsEmpty{ get{ return _items.Count == 0; } }

        // CONSTRUCTOR
        public Stack()
        {
            _items = new List<object>();
        }

        // METHODS

        // allows controlled access to the collection's items.
        public IEnumerable<object> GetItems() { return _items; }

        //stores the given object on top of the stack
        public void Push(object obj) {
            if ( obj == null)
            throw new InvalidOperationException("Cannot push a null object onto the stack");

            _items.Add(obj);
        }

        // removes the object on top of the stack and returns it
        public object Pop() {
           if (IsEmpty)
                throw new InvalidOperationException("Cannot pop from an empty stack");

            int lastIndex = _items.Count - 1;
            // var topItem = _items.Last();     // Variant 1 dependant on System.Linq; 
            var topItem = _items[lastIndex];    // Variant 2 more explicit

           _items.RemoveAt(lastIndex);
           // _items.RemoveAll(x => x == topItem); // less efficient as it iterates over the list

           return topItem;
        }

        // returnig the top item without removing it
        public object Peek() {
            if (IsEmpty)
                throw new InvalidOperationException("Cannot pop from an empty stack");
            return _items[_items.Count - 1];
        }

        // removes all objects from the stack. 
        public void Clear() {_items.Clear(); }

    }

    public class StackProgram
    {
        public static void Run()
        {
            // Create a stack
            Stack stack = new Stack();

            // Push elements onto the stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            
            Console.Write($"\nLIFO stack created and filled up: ");
            // foreach (var item in stack.GetItems()) { Console.Write(item + " "); }
            Console.WriteLine( string.Join(" ", stack.GetItems()) );

            // Peek at the top element
            Console.WriteLine($"top element:\t {stack.Peek()}");
            // Pop elements from the stack
            Console.WriteLine($"next popped:\t {stack.Pop()}");
            Console.WriteLine($"and next one:\t {stack.Pop()}");

            // Check if the stack is empty
            Console.WriteLine($"Is stack empty? {stack.Count == 0}");
        }
    }
}   
