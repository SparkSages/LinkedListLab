
namespace LinkedListExampleTests
{
    [TestClass]
    public class MyLinkedListTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {

            // Arrange
            MyLinkedList<int> list;

            // Act
            list = new MyLinkedList<int>();

            // Assert
            Assert.IsNotNull(list);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        public void TestEnumerator(int itemsToAdd)
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                list.Add(i);
            }

            // Assert
            Assert.AreEqual(itemsToAdd, list.Count);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        public void TestCount(int itemsToAdd)
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();
            for (int j = 0; j < itemsToAdd; j++)
            {
                list.Add(j);
            }

            // Act / Assert
            Assert.AreEqual(itemsToAdd, list.Count);
        }

        [TestMethod]
        public void TestDoesContains()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            bool doesContainOne = list.Contains(1);
            bool doesContainTwo = list.Contains(2);
            bool doesContainThree = list.Contains(3);

            // Assert
            Assert.IsTrue(doesContainOne);
            Assert.IsTrue(doesContainTwo);
            Assert.IsTrue(doesContainThree);
        }

        [TestMethod]
        public void TestDoesNotContain()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            bool doesNotContainFour = list.Contains(4);
            bool doesNotContainFive = list.Contains(5);
            bool doesNotContainSix = list.Contains(6);

            // Assert
            Assert.IsFalse(doesNotContainFour);
            Assert.IsFalse(doesNotContainFive);
            Assert.IsFalse(doesNotContainSix);
        }

        [TestMethod]
        public void TestAddIncreasesCount()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Assert
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestAddToCollection()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Assert
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod]
        public void TestClearCollection()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);

            Assert.IsFalse(list.Contains(1));
            Assert.IsFalse(list.Contains(2));
            Assert.IsFalse(list.Contains(3));
        }

        [TestMethod]
        public void TestClearThenAddCollection()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            list.Add(4);
            list.Add(5);
            list.Add(6);    

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.IsFalse(list.Contains(1));
            Assert.IsFalse(list.Contains(2));
            Assert.IsFalse(list.Contains(3));

            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(6));
        }

        [TestMethod]
        public void TestReadOnly()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();

            // Act

            // Assert
            Assert.IsFalse(list.IsReadOnly);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        public void TestCopyTo(int itemsToAdd)
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();
            int[] targetArray = new int[itemsToAdd];

            for (int i = 0; i < itemsToAdd; i++)
            {
                list.Add(i);
            }

            // Act
            list.CopyTo(targetArray, 0);

            // Assert
            Assert.AreEqual(itemsToAdd, targetArray.Length);
            for (int i = 0; i < itemsToAdd; i++)
            {
                Assert.IsTrue(targetArray.Contains<int>(i));
            }
        }

        [TestMethod]
        public void TestRemoveFromFront()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Act
            list.Remove(1);

            // Assert
            Assert.AreEqual(2, list.Count);

            Assert.IsFalse(list.Contains(1));

            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod]
        public void TestRemoveFromMiddle()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Act
            list.Remove(2);

            // Assert
            Assert.AreEqual(2, list.Count);

            Assert.IsFalse(list.Contains(2));

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod]
        public void TestRemoveFromEnd()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Act
            list.Remove(3);

            // Assert
            Assert.AreEqual(list.Count, 2);

            Assert.IsFalse(list.Contains(3));

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
        }

        [TestMethod]
        public void TestRemoveToClearThenAdd()
        {

            // Arrange
            ICollection<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(1);
            list.Remove(2);
            list.Remove(3);

            // Act
            list.Add(4);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list.Contains(4));
        }

        [TestMethod]
        [DataRow(1, 0, 1, 2, 3, 4, 5, 6)]
        [DataRow(6, 5, 1, 2, 3, 4, 5, 6)]
        [DataRow(3, 2, 1, 2, 3, 4, 5, 6)]
        public void TestIndexOf(int valueToFind, int index, params int[] values)
        {

            // Arrange
            IList<int> list = new MyLinkedList<int>();

            foreach (int value in values) 
            {
                list.Add(value);
            }

            // Ensure the test is setup correctly
            Assert.AreEqual(values.Length, list.Count);
            Assert.IsTrue(list.Contains(valueToFind));

            // Act
            int foundAt = list.IndexOf(valueToFind);

            // Assert
            // Ensure the correct results of the action
            Assert.AreEqual(index, foundAt);
        }

        [TestMethod]
        [DataRow(7, -1, 1, 2, 3, 4, 5, 6)]
        [DataRow(-20, -1, 1, 2, 3, 4, 5, 6)]
        [DataRow(20 -1, 1, 2, 3, 4, 5, 6)]
        public void TestIndexOfFails(int valueToFind, int index, params int[] values)
        {

            // Arrange
            IList<int> list = new MyLinkedList<int>();

            foreach (int value in values)
            {
                list.Add(value);
            }

            // Ensure the test is setup correctly
            Assert.AreEqual(values.Length, list.Count);
            Assert.IsFalse(list.Contains(valueToFind));

            // Act
            int foundAt = list.IndexOf(valueToFind);

            // Assert
            // Ensure the correct results of the action
            Assert.AreEqual(index, foundAt);
        }

        [TestMethod]
        [DataRow(0, 1, 2, 3, 4, 5, 6)]
        [DataRow(5, 1, 2, 3, 4, 5, 6)]
        [DataRow(6, 1, 2, 3, 4, 5, 6)]
        [DataRow(2, 1, 2, 3, 4, 5, 6)]
        public void TestInsert(int index, params int[] values)
        {

            // Arrange
            IList<int> list = new MyLinkedList<int>();
            const int VALUE_TO_INSERT = 10;

            foreach (int value in values)
            {
                list.Add(value);
            }

            // Ensure the test is setup correctly
            Assert.AreEqual(values.Length, list.Count);

            // Act
            list.Insert(index, VALUE_TO_INSERT);
            int indexOf = list.IndexOf(VALUE_TO_INSERT);

            // Assert
            // Ensure the correct results of the action
            Assert.IsTrue(list.Contains(VALUE_TO_INSERT));

            Assert.AreEqual(index, indexOf);

        }

        [TestMethod]
        [DataRow(-20, 1, 2, 3, 4, 5, 6)]
        [DataRow(20, 1, 2, 3, 4, 5, 6)]
        public void TestInsertFails(int index, params int[] values)
        {

            // Arrange
            IList<int> list = new MyLinkedList<int>();
            const int VALUE_TO_INSERT = 10;

            foreach (int value in values)
            {
                list.Add(value);
            }

            // Ensure the test is setup correctly
            Assert.AreEqual(values.Length, list.Count);

            // Act / Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => 
                list.Insert(index, VALUE_TO_INSERT));
        }

        [TestMethod]
        [DataRow(0, 1, 1, 2, 3, 4, 5, 6)]
        [DataRow(1, 2, 1, 2, 3, 4, 5, 6)]
        [DataRow(5, 6, 1, 2, 3, 4, 5, 6)]
        public void TestRemoveAt(int index, int valueRemoved, params int[] values)
        {

            // Arrange
            IList<int> list = new MyLinkedList<int>();

            foreach (int value in values)
            {
                list.Add(value);
            }

            // Ensure the test is setup correctly
            Assert.AreEqual(values.Length, list.Count);
            Assert.AreEqual(index, list.IndexOf(valueRemoved));

            int TARGET_COUNT = list.Count - 1;

            // Act
            list.RemoveAt(index);

            // Assert
            Assert.AreEqual(TARGET_COUNT, list.Count);
            Assert.IsFalse(list.Contains(valueRemoved));
            Assert.AreEqual(-1, list.IndexOf(valueRemoved));
        }

        [TestMethod]
        [DataRow(-20, 1, 2, 3, 4, 5, 6)]
        [DataRow(20, 1, 2, 3, 4, 5, 6)]
        public void TestRemoveAtFails(int index, params int[] values)
        {
            // Arrange
            IList<int> list = new MyLinkedList<int>();

            foreach (int value in values)
            {
                list.Add(value);
            }

            // Ensure the test is setup correctly
            Assert.AreEqual(values.Length, list.Count);

            // Act / Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
                list.RemoveAt(index));
        }

        [TestMethod]
        public void TestAddDataOperator()
        {

            // Arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            // Act
            list += 1;
            list += 2 + 3 + 4 + 5;

            // Assert
            Assert.AreEqual(5, list.Count);

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(5));
        }

        [TestMethod]
        public void TestSubtractDataOperator()
        {

            // Arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            // Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list -= 1;
            list -= 3;
            list -= 5;

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(4));

            Assert.IsFalse(list.Contains(3));
            Assert.IsFalse(list.Contains(4));
            Assert.IsFalse(list.Contains(5));
        }

        [TestMethod]
        public void TestAddTwoLinkedList()
        {

            // Arrange
            MyLinkedList<int> listA = new MyLinkedList<int>();
            MyLinkedList<int> listB = new MyLinkedList<int>();

            listA.Add(1);
            listA.Add(2);
            listA.Add(3);
            listA.Add(4);

            listB.Add(5);
            listB.Add(6);
            listB.Add(7);
            listB.Add(8);

            // Act
            listA += listB;

            // Assert
            Assert.AreEqual(8, listA.Count);

            Assert.IsTrue(listA.Contains(1));
            Assert.IsTrue(listA.Contains(2));
            Assert.IsTrue(listA.Contains(4));
            Assert.IsTrue(listA.Contains(5));
            Assert.IsTrue(listA.Contains(6));
            Assert.IsTrue(listA.Contains(7));
            Assert.IsTrue(listA.Contains(8));
        }
    }
}