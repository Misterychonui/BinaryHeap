using System;
using System.Collections.Generic;

public class Binaryheap<T> where T : IComparable<T>
{
    private readonly List<T> _heap;

    public Binaryheap()
    {
        _heap = new List<T>();
    }
    public int Count()
    {
        return _heap.Count;
    }
    public void Insert(T value)
    {
        _heap.Add(value);

        int i = _heap.Count - 1;
        int parent = (i - 1) / 2;

        while (i > 0 && _heap[parent].CompareTo(_heap[i])>0)
        {
            T temp = _heap[i];
            _heap[i] = _heap[parent];
            _heap[parent] = temp;

            i = parent;
            parent = (i - 1) / 2;
        }
    }
    public T FindMax()
    {
        return _heap[0];
    }
    public T FindNextElement(int index)
    {
        return _heap[index];
    }
    public T DeleteElement() 
    {
        T temp = _heap[0];
        _heap[0] = _heap[_heap.Count - 1];
        _heap.RemoveAt(_heap.Count - 1);
        Heapify(0);
        return temp;
    }
    private void Heapify(int i)
    {
        int leftChild;
        int rightChild;
        int minChild;

        for (; ; )
        {
            leftChild = 2 * i + 1;
            rightChild = 2 * i + 2;
            minChild = i;

            if (leftChild < _heap.Count && _heap[leftChild].CompareTo(_heap[minChild])<0)
            {
                minChild = leftChild;
            }

            if (rightChild < _heap.Count && _heap[rightChild].CompareTo(_heap[minChild])<0)
            {
                minChild = rightChild;
            }

            if (minChild == i)
            {
                break;
            }
            T temp = _heap[i];
            _heap[i] = _heap[minChild];
            _heap[minChild] = temp;
            i = minChild;
        }
    }
}