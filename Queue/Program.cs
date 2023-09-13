using System;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            queue.Dequeue();
            queue.Enqueue(4);

            Console.WriteLine("Hello World!");
        }
    }
}
