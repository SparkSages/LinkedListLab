namespace LinkedListExample
{
    internal class MyLinkedListNode<T>
    {
        // Data
        internal T data;
        // Pointer to Next Node
        internal MyLinkedListNode<T> next;
        internal MyLinkedListNode<T> prev;

        internal MyLinkedListNode(T data)
        {
            this.data = data;
        }
    }
}