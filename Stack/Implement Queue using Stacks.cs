﻿/*
232. Implement Queue using Stacks
easy
Implement Queue using Stacks

Implement the following operations of a queue using stacks.

push(x) -- Push element x to the back of queue.
pop() -- Removes the element from in front of queue.
peek() -- Get the front element.
empty() -- Return whether the queue is empty.
Notes:
You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque (double-ended queue), as long as you use only standard operations of a stack.
You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).
*/

using System.Collections.Generic;

namespace Demo
{
    public class Queue
    {
        private readonly Stack<int> input = new Stack<int>();
        private readonly Stack<int> output = new Stack<int>();

        // Push element x to the back of queue.
        public void Push(int x)
        {
            input.Push(x);
        }

        // Removes the element from front of queue.
        public void Pop()
        {
            Peek();
            output.Pop();
        }

        // Get the front element.
        public int Peek()
        {
            if (output.Count == 0)
            {
                while (input.Count !=0)
                {
                    output.Push(input.Pop());
                }
            }

            return output.Peek();
        }

        // Return whether the queue is empty.
        public bool Empty()
        {
            return input.Count == 0 && output.Count == 0;
        }
    }
}
