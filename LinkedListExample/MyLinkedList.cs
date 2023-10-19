using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace LinkedListExample
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of data to be stored into the linked list</typeparam>
    public class MyLinkedList<T> : IEnumerable<T>, ICollection<T>, IList<T> where T : IEquatable<T>
    {
        private MyLinkedListNode<T>? head;
        private MyLinkedListNode<T>? tail;

        /// <summary>
        /// Append everything in the right linked list to the left linked list
        /// </summary>
        /// <returns>The Left linked list</returns>
        public static MyLinkedList<T> operator +(MyLinkedList<T> left, MyLinkedList<T> right)
        {
            if (left.head == null && left.tail == null)
            {
                return right;
            }
            left.head.prev = right.tail;
            right.head.prev = left.tail;
            left.tail.next = right.head;
            right.tail.next = left.head;
            left._Count += right._Count;
            return left;
        }

        /// <summary>
        /// Adds a value to the linked list
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The left linked list</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyLinkedList<T> operator +(MyLinkedList<T> left, T right)
        {
            if (left.head == null && left.tail == null) { left = new(right); }
            else
            {
                left.AddToEnd(right);
            }
            return left;
        }

        /// <summary>
        /// Removes a value to the linked list
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The left linked list</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyLinkedList<T> operator -(MyLinkedList<T> left, T right)
        {
            left.RemoveValue(right);
            return left;
        }
        private int _Count;
        public int Count => head == null ? 0 : _Count;

        public bool IsReadOnly => false;

        /// <summary>
        /// Not required for this assignment.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public T this[int index]
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public MyLinkedList()
        {
            head = null;
            tail = null;
            _Count = 0;
        }

        #region Functions We Made in Lecture
        public MyLinkedList(T data)
        {
            head = new MyLinkedListNode<T>(data);
            tail = head;
            head.next = head;
            head.prev = head;
        }

        public void Clear()
        {
            if (head == null)
            {
                return;
            }
            head = null;
            tail = null;
            _Count = 0;
        }

        public void AddToEnd(T data)
        {
            if (tail == null && head == null)
            {
                MyLinkedListNode<T> node = new MyLinkedListNode<T>(data);
                head = node;
                tail = head;
                _Count = 1;
            }
            else
            {
                MyLinkedListNode<T> node = new MyLinkedListNode<T>(data);
                tail.next = node;
                node.prev = tail;
                tail = node;
                _Count++;
            }

        }

        public void AddToFront(T data)
        {
            if (tail == null)
            {
                MyLinkedListNode<T> node = new MyLinkedListNode<T>(data);
                head = node;
                tail = head;
                _Count = 1;
            }
            else
            {
                MyLinkedListNode<T> node = new MyLinkedListNode<T>(data);
                node.next = head;
                node.prev = tail;
                head.prev = node;
                head = node;
                tail.next = head;
                _Count++;
            }
        }

        public T RemoveFromFront()
        {
            T value = head.data;
            head = head.next;
            tail.next = head;
            head.prev = tail;
            return value;
        }

        public T RemoveFromEnd()
        {
            var endValue = tail.data;
            tail = tail.prev;
            tail.next = head;
            head.prev = tail;
            _Count--;
            return endValue;
        }

        void RemoveValue(T value)
        {
            try
            {
                if (tail != null && head != null)
                {
                    var currentNode = head;
                    while (currentNode != null)
                    {
                        if (currentNode.data.Equals(value))
                        {
                            currentNode.prev.next = currentNode.next;
                            currentNode.next.prev = currentNode.prev;
                            _Count--;
                            return;
                        }
                        currentNode = currentNode.next;
                    }
                }
                else return;
            }
            catch (Exception) { return; }
        }

        #endregion




        /// <summary>
        /// Creates an enumerator to interop with C#'s foreach loop.
        /// Should iterate through each element in the linked list
        /// then yield return each item in the collection.
        /// </summary>
        /// <remark>
        /// Yields surrender your control flow over to the caller
        /// such that the next time the method is called by caller,
        /// if they are using the Enumerator properly, it will
        /// restart the method at the point of the yield return,
        /// and the start of variables within the method will
        /// be maintained.
        /// 
        /// Yield returns and IEnumerators are very powerful
        /// features in C# and many other languages like 
        /// C++, rust, and Python. However, students often struggle
        /// with them because they operate completely different to
        /// how you may have been taught functions and methods
        /// prior to today.
        /// </remark>
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield"/>
        /// <see href="https://learn.microsoft.com/en-us/archive/msdn-magazine/2017/june/essential-net-custom-iterators-with-yield"/>
        /// <returns>Yield returns each item in the linked list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Students: Implement your enumerator here
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Students: Don't touch
            return GetEnumerator();
        }

        /// <summary>
        /// Required by the ICollection interface.
        /// Adds an element somewhere into the linked list.
        /// </summary>
        /// <param name="item">The item to add to the linked list</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(T item)
        {
            AddToEnd(item);
        }

        public bool Contains(T item)
        {
            try
            {
                if (head == null || tail == null)
                {
                    // cannot remove
                    return false;
                }
                else
                {
                    var currentNode = head;
                    do
                    {
                        if (currentNode.data.Equals(item))
                        {
                            return true;
                        }
                        currentNode = currentNode.next;
                    } while (currentNode != head);
                }
            }
            catch (Exception) { };
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            try
            {
                RemoveValue(item);
            }
            catch (Exception) { return false; }
            return true;
        }

        /// <summary>
        /// Find the location of an element in the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns>If this list contains the element, then returns the index.
        /// If this list DOES NOT contain the element, then returns -1</returns>
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1.indexof?view=net-7.0#system-collections-generic-ilist-1-indexof(-0)"/>
        /// <exception cref="NotImplementedException"></exception>
        public int IndexOf(T item)
        {
            if (head == null) { return -1; }
            int indexer = 0;
            var currentNode = head;
            try
            {
                do
                {
                    if (currentNode.data.Equals(item))
                    {
                        return indexer;
                    }
                    currentNode = currentNode.next;
                    indexer++;
                } while (currentNode != head);
                return indexer;
            }
            catch (NullReferenceException) { return -1; }
        }

        public void Insert(int index, T item)
        {
            if (head == null) { throw new NullReferenceException(); }
            if (index >= _Count)
            {
                throw new IndexOutOfRangeException();
            }
            var currentNode = head;
            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    currentNode.next = currentNode;
                    currentNode.data = item;
                }
                currentNode = currentNode.next;
            }
        }

        public void RemoveAt(int index)
        {
            try
            {
                if (tail == null && head == null) { return; }
                var currentNode = head;
                for (int i = 0; i <= _Count; i++)
                {
                    if (i == index)
                    {
                        currentNode.prev.next = currentNode.next;
                        currentNode.next.prev = currentNode.prev;
                        _Count--;
                    }
                    currentNode = currentNode.next;
                }
            }
            catch (NullReferenceException) { return; }
        }
    }
}