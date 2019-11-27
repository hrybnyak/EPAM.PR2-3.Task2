using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RangeIndexArray
{
    public class RangeArray<T> : IList<T>

    {
        private T[] _items;
        static readonly T[] _emptyArray = new T[0];
        public int StartIndex { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public T this[int index] 
        { 
            get
            {
                if (index < StartIndex || index > StartIndex + Count) throw new IndexOutOfRangeException();
                else return _items[index - StartIndex];
            }
            set
            {
                if (index < StartIndex || index > StartIndex + Count) throw new IndexOutOfRangeException();
                if (value == null) throw new ArgumentNullException();
                else _items[index - StartIndex] = value;
            }
        }

        public RangeArray()
        {
            StartIndex = 0;
            _items = _emptyArray;
            Count = 0;
        }
        public RangeArray(int startIndex)
        {
            StartIndex = startIndex;
            _items = _emptyArray;
            Count = 0;
        }
        public void Add(T item)
        {
            if (item == null) throw new NullReferenceException();
            if (Count == _items.Length) ExpandArray();
            _items[Count] = item;
            Count++;
        }
        private void ExpandArray()
        {
            int newLength = Count+1;
            T[] newArray = new T[newLength];
            for (int i =0; i<_items.Length; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
        public void Clear()
        {
            Count = 0;
            _items = _emptyArray;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i<Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException();
            for (int i = 0; i < Count; i++)
                array[i + arrayIndex] = this[i + StartIndex];
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int IndexOf(T item)
        {
            for (int i = 0; i<Count; i++)
            {
                if (item.Equals(_items[i])) return i + StartIndex;
            }
            return Int32.MinValue;
        }

        public void Insert(int index, T item)
        {
            if (item == null) throw new NullReferenceException();
            if (Count == _items.Length) ExpandArray();
            Count++;
            index -= StartIndex;

            for (int i = Count - 1; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
        }

        public void RemoveAt(int index)
        {
            index -= StartIndex;
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            for (int i = index; i < Count - 1; i++)
                _items[i] = _items[i + 1];
            Count--;
        }
        public bool Remove(T item)
        {
            int index = IndexOf(item) + StartIndex;
            if (index != -1)
            {
                RemoveAt(index - StartIndex);
                return true;
            }
            else return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for(int i = 0; i<Count; i++)
            {
                sb.Append($"{_items[i]} ");
            }
            return sb.ToString();
        }
    }
}
