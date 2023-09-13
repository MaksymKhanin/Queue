using System;

namespace Queue
{
    public class Queue<T>
    {
        private T[] _array;
        private int _tail = -1;
        private int _head = 0;
        private int _size = 0;
        public Queue(int capacity = 10)
        {
            _array = new T[capacity];
        }

        public int Count
        {
            get { return _size; }
        }

        public void Enqueue(T item)
        {
            if (_size == _array.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }

            if (_tail == _array.Length - 1)
            {
                var _newArray = new T[_array.Length];
                _array.CopyTo(_newArray, 0);
                _array = _newArray;
            }
            else
            {
                _tail++;
            }

            _array[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T dequeuedItem = _array[_head];
            _head++;
            _size--;
            return dequeuedItem;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new ApplicationException("Queue is Empty");
            }

            return _array[_head];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Clear()
        {
            _head = 0;
            _tail = -1;
            _size = 0;
        }
    }
}
