using System.Collections.Generic;

namespace LinkedListExample
{

    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<string> list = new MyLinkedList<string>("Pumpkin");
            
            list.AddToEnd("Corn Maze");
            list.AddToEnd("Gengar");
            list.AddToEnd("Haunted");
            list.AddToEnd("Skeleton");

/*            Console.WriteLine(list.head.data);
            Console.WriteLine(list.head.next.data);
            Console.WriteLine(list.head.next.prev.data);*/

        }
    }
}