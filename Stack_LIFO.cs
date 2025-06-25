using System;
using System.Collections.Generic;
using System.Linq;

namespace MoshHamedani_C__imtermediate
{
    internal class Stack
    {
        // PROPERTIES
        private List<object> _items;

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

            // var topItem = _items.Last();        // Variant 1 dependant on System.Linq; 
           var topItem = _items[_items.Count - 1]; // Variant 2 more explicit

           _items.RemoveAt(_items.Count - 1);
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
            var stack = new Stack();
            // Push elements onto the stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Peek at the top element
            Console.WriteLine($"Top element: {stack.Peek()}");
            // Pop elements from the stack
            Console.WriteLine($"Popped element: {stack.Pop()}");
            Console.WriteLine($"Popped element: {stack.Pop()}");
            // Check if the stack is empty
            Console.WriteLine($"Is stack empty? {stack.Count == 0}");
        }
    }
}   
