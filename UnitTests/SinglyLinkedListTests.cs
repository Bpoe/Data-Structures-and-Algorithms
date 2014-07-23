using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data_Structures_and_Algorithms.UnitTests
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void TestAddAfter()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            var node = list.AddLast(0);
            list.AddLast(2);

            list.AddAfter(node, 1);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddAfterNoNext()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(0);
            var node = list.AddLast(1);

            list.AddAfter(node, 2);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddAfterNoPrevious()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            var node = list.AddLast(0);
            list.AddLast(2);

            list.AddAfter(node, 1);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddAfterLast()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);

            var node = list.AddAfter(list.Last, 2);

            Verify(expected, list);
            Assert.AreSame(list.Last, node);
        }

        [TestMethod]
        public void TestAddBefore()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(0);
            var node = list.AddLast(2);

            list.AddBefore(node, 1);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddBeforeNoNext()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(0);
            var node = list.AddLast(2);

            list.AddBefore(node, 1);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddBeforeFirst()
        {
            var expected = new int[3] { 0, 1, 2 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            var node = list.AddBefore(list.First, 0);

            Verify(expected, list);
            Assert.AreSame(list.First, node);
        }

        [TestMethod]
        public void TestEnumerator()
        {
            var expected = new int[4] { 0, 1, 2, 3 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestConstructor()
        {
            var expected = new int[4] { 0, 1, 2, 3 };

            var list = new SinglyLinkedList<int>(expected);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddFirst()
        {
            var expected = new int[2] { 0, 1 };

            var list = new SinglyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(0);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddLast()
        {
            var expected = new int[2] { 0, 1 };

            var list = new SinglyLinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            var expected = new int[2] { 0, 1 };

            var list = new SinglyLinkedList<int>(expected);
            list.AddFirst(-1);
            Assert.AreEqual(-1, list.First.Value);

            list.RemoveFirst();
            
            Verify(expected, list);
        }

        [TestMethod]
        public void TestRemoveLast()
        {
            var expected = new int[2] { 0, 1 };

            var list = new SinglyLinkedList<int>(expected);
            list.AddLast(-1);
            Assert.AreEqual(-1, list.Last.Value);

            list.RemoveLast();

            Verify(expected, list);
        }

        [TestMethod]
        public void TestClear()
        {
            var expected = new int[4] { 0, 1, 2, 3 };

            var list = new SinglyLinkedList<int>(expected);
            list.Clear();

            int x = 0;
            foreach (int i in list)
            {
                x++;
            }

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(0, x);
        }

        [TestMethod]
        public void TestAddRangeToEmpty()
        {
            var expected = new int[4] { 0, 1, 2, 3 };

            var list = new SinglyLinkedList<int>();
            list.AddRange(expected);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestAddRangeToExisting()
        {
            var expected = new int[4] { 0, 1, 2, 3 };
            var existing = new int[2] { 0, 1 };
            var addition = new int[2] { 2, 3 };

            var list = new SinglyLinkedList<int>(existing);
            list.AddRange(addition);

            Verify(expected, list);
        }

        [TestMethod]
        public void TestCopyTo0()
        {
            var expected = new int[4] { 0, 1, 2, 3 };

            var list = new SinglyLinkedList<int>(expected);

            var actual = new int[4];
            list.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCopyToIndex()
        {
            var expected = new int[4] { 0, 1, 2, 3 };
            
            var list = new SinglyLinkedList<int>(new int[2] { 2, 3 });
            var actual = new int[4] { 0, 1, -1, -1 };
            list.CopyTo(actual, 2);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFind()
        {
            var expected = new int[4] { 0, 1, 2, 3 };

            var list = new SinglyLinkedList<int>(expected);
            var actual = list.Find(2);

            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Value);
        }

        [TestMethod]
        public void TestRemoveNode()
        {
            var list = new SinglyLinkedList<string>();
            list.AddLast("Expected");
            list.AddLast("Expected");
            var notExpected = list.AddLast("Not expected");
            list.AddLast("Expected");
            list.Remove(notExpected);

            bool found = false;
            var current = list.First;
            while (current != null && !found)
            {
                found = current == notExpected;
                current = current.Next;
            }

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void TestRemoveValue()
        {
            var list = new SinglyLinkedList<string>();
            list.AddLast("Expected");
            list.AddLast("Expected");
            list.AddLast("Not expected");
            list.AddLast("Expected");
            
            Assert.IsTrue(list.Remove("Not expected"));
            Assert.IsFalse(list.Contains("Not expected"));
        }

        [TestMethod]
        public void TestContains()
        {
            var list = new SinglyLinkedList<string>();
            list.AddLast("Expected");
            list.AddLast("Expected");
            list.AddLast("Expected");

            Assert.IsTrue(list.Contains("Expected"));
            Assert.IsFalse(list.Contains("Not expected"));
        }

        private static void Verify(int[] expected, SinglyLinkedList<int> list)
        {
            var actual = new int[expected.Length];
            int x = 0;
            foreach (int i in list)
            {
                actual[x] = i;
                x++;
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
