using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data_Structures_and_Algorithms.UnitTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void TestAddRange()
        {
            int[] expected = new int[4] { 0, 1, 2, 3 };
            var q = new Queue<int>();
            q.AddRange(expected);

            Assert.AreEqual(expected.Length, q.Count);
            Assert.AreEqual(expected[0], q.Peek());
        }

        [TestMethod]
        public void TestClear()
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            Assert.AreEqual(1, q.Count);

            q.Clear();
            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            Assert.AreEqual(1, q.Count);

            Assert.IsTrue(q.Contains(0));
            Assert.IsFalse(q.Contains(1));
        }

        [TestMethod]
        public void TestEnumator()
        {
            int[] expected = new int[4] { 0, 1, 2, 3 };
            var q = new Queue<int>();
            q.AddRange(expected);

            int i = 0;
            foreach (int item in q)
            {
                Assert.AreEqual(expected[i], item);
                i++;
            }
        }

        [TestMethod]
        public void TestEnqueue()
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            Assert.AreEqual(1, q.Count);
        }

        [TestMethod]
        public void TestDequeue()
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            Assert.AreEqual(0, q.Dequeue());
            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void TestPeek()
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            Assert.AreEqual(0, q.Peek());
            Assert.AreEqual(1, q.Count);
        }
    }
}
