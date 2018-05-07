using System;

namespace Assets.Scripts.Pathfinding {

    /**
     * Binary heap to be used in A* algorithm as the open set
     */

    public class BinaryHeap<T> where T : IHeapItem<T> {

        private T[] items;
        public int Count { get; private set; }

        public BinaryHeap(int maxSize) {
            items = new T[maxSize];
        }

        private void SortDown(T item) {
            while (true) {
                int childLeft = item.HeapIndex * 2 + 1;
                int childRight = item.HeapIndex * 2 + 2;
                if (childLeft < Count) {
                    int swapIndex = childLeft;
                    if (childRight < Count) {
                        if (items[childLeft].CompareTo(items[childRight]) < 0) {
                            swapIndex = childRight;
                        }
                    }
                    if (item.CompareTo(items[swapIndex]) < 0) {
                        Swap(item, items[swapIndex]);
                    } else {
                        return;
                    }
                } else {
                    return;
                }
            }
        }

        private void SortUp(T item) {
            while (true) {
                int parentIndex = (item.HeapIndex - 1) / 2;
                T parentItem = items[parentIndex];
                if (item.CompareTo(parentItem) > 0) {
                    Swap(item, parentItem);
                } else {
                    break;
                }
            }
        }

        private void Swap(T itemA, T itemB) {
            items[itemA.HeapIndex] = itemB;
            items[itemB.HeapIndex] = itemA;
            int tempIndex = itemA.HeapIndex;
            itemA.HeapIndex = itemB.HeapIndex;
            itemB.HeapIndex = tempIndex;
        }

        public void Add(T item) {
            item.HeapIndex = Count;
            items[Count] = item;
            SortUp(item);
            Count++;
        }

        public T RemoveFirst() {
            T itemToRemove = items[0];
            Count--;
            items[0] = items[Count];
            items[0].HeapIndex = 0;
            SortDown(items[0]);
            return itemToRemove;
        }

        public bool Contains(T item) {
            return Equals(items[item.HeapIndex], item);
        }

        public void UpdateItem(T item) {
            SortUp(item);
        }
    }

    public interface IHeapItem<T> : IComparable<T> {
        int HeapIndex { get; set; }
    }
}
