using System;
using System.Collections.Generic;

namespace CompGeo.Library.DataStructures
{
    public class BinaryHeap<T> : ICloneable where T : IComparable<T>
    {
        // Using a list based binary tree.
        private List<T> heap;
        private IComparer<T> comparer = Comparer<T>.Default;
        private MinMax minMax;

        public object Clone()
        {
            BinaryHeap<T> heap = new BinaryHeap<T>(this.minMax);
            heap.heap = new List<T>(this.heap);

            return heap;
        }

        public BinaryHeap(MinMax minMax = MinMax.Max)
        {
            heap = new List<T>();
            this.minMax = minMax;
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        public void Push(T item)
        {
            heap.Add(item);
            UpMaxHeap(heap.Count - 1);
        }

        public T Pop()
        {
            T top = heap[0];
            int last = heap.Count - 1;
            heap[0] = heap[last];
            heap.RemoveAt(last);
            DownMaxHeap(0);

            return top;
        }

        public T Top()
        {
            return heap[0];
        }

        public IEnumerable<T> GetSortedList()
        {
            BinaryHeap<T> heapCopy = (BinaryHeap<T>)this.Clone();
            List<T> sortedList = new List<T>();

            while (heapCopy.Count != 0)
            {
                sortedList.Add(heapCopy.Pop());
            }

            return sortedList;
        }

        private bool IsGreaterThan(int left, int right)
        {
            return comparer.Compare(heap[left], heap[right]) > 0;
        }

        private void SwapItems(int item1, int item2)
        {
            T temp = heap[item1];
            heap[item1] = heap[item2];
            heap[item2] = temp;
        }

        private void UpMaxHeap(int start)
        {
            int current = start;
            while (current > 0)
            {
                int parent = this.Parent(current);
                if (IsGreaterThan(current, parent))
                {
                    SwapItems(current, parent);
                    current = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void DownMaxHeap(int start)
        {
            int current = start;
            int leftChild = 0;
            int rightChild = 0;
            int largest = 0;
            int lastItem = heap.Count - 1;

            while (true)
            {
                leftChild = 2 * current + 1;
                rightChild = 2 * current + 2;

                if (leftChild <= (lastItem) && IsGreaterThan(leftChild, current))
                {
                    largest = leftChild;
                }
                else
                {
                    largest = current;
                }

                if (rightChild <= (lastItem) && IsGreaterThan(rightChild, largest))
                {
                    largest = rightChild;
                }

                if (largest != current)
                {
                    SwapItems(current, largest);
                    current = largest;
                }
                else
                {
                    break;
                }
            }
        }

        private int Parent(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index is less than zero.");
            }
            else if (index == 0)
            {
                return 0;
            }
            else
            {
                // floats will get truncated for integer types: 5 / 2 = 2
                return (index - 1) / 2;
            }
        }
    }

}
