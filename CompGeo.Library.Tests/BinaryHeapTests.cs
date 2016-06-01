using System;
using CompGeo.Library.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompGeo.Library.Tests
{
    [TestClass]
    public class BinaryHeapTests
    {
        [TestMethod]
        public void PushTest()
        {
            int[] input = { 5, 3, 2, 10, 6, 7, 8, 1, 9, 11 };
            BinaryHeap<int> heap = new BinaryHeap<int>();

            int prev = int.MinValue;
            for (int i = 0; i < input.Length; i++)
            {
                heap.Push(input[i]);
                Assert.IsTrue(heap.Top() >= prev);
                prev = heap.Top();
            }

            Assert.AreEqual(input.Length, heap.Count);
        }

        [TestMethod]
        public void PopTest()
        {
            int[] input = { 5, 3, 2, 10, 6, 7, 8, 1, 9, 11 };
            BinaryHeap<int> heap = new BinaryHeap<int>();
            int prev = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                heap.Push(input[i]);
            }

            while (heap.Count != 0)
            {
                int cur = heap.Pop();
                Assert.IsTrue(cur <= prev);
                prev = cur;
            }
        }

    }
}
