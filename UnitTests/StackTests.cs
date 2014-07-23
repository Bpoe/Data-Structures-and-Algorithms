using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data_Structures_and_Algorithms.UnitTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestAddRange()
        {
            int[] expected = new int[4] { 0, 1, 2, 3 };
            Stack<int> stack = new Stack<int>();
            stack.AddRange(expected);

            Assert.AreEqual(expected.Length, stack.Count);
            Assert.AreEqual(expected[expected.Length - 1], stack.Peek());
        }

        [TestMethod]
        public void TestClear()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            Assert.AreEqual(1, stack.Count);

            stack.Clear();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            Assert.AreEqual(1, stack.Count);

            Assert.IsTrue(stack.Contains(0));
            Assert.IsFalse(stack.Contains(1));
        }

        [TestMethod]
        public void TestEnumator()
        {
            int[] expected = new int[4] { 0, 1, 2, 3 };
            Stack<int> stack = new Stack<int>();
            stack.AddRange(new int[4] { 3, 2, 1, 0 });

            int i = 0;
            foreach(int item in stack)
            {
                Assert.AreEqual(expected[i], item);
                i++;
            }
        }

        [TestMethod]
        public void TestPush()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void TestPop()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            Assert.AreEqual(0, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestPeek()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            Assert.AreEqual(0, stack.Peek());
            Assert.AreEqual(1, stack.Count);
        }
    }
}
