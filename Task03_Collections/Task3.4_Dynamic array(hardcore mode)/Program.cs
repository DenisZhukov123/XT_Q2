using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3._4_Dynamic_array_hardcore_mode_
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        protected int capacity = 0;
        protected int length = 0;
        protected T[] Array;
        public DynamicArray()
        {
            Array = new T[8];
            capacity = 8; ;
        }
        public DynamicArray(int size)
        {
            if (size >= 0)
            {
                Array = new T[size];
                capacity = size;
            }
            else
                throw new ArgumentException("The dimension of the array cannot be negative!");
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentException("The argument that is passed NULL!");
            else
            {
                int size = CountElCollection(collection);
                Array = new T[size];
                Capacity = size;
                foreach (var item in collection)
                {
                    Array[length] = item;
                    length++;
                }
            }
        }
        protected int CountElCollection(IEnumerable<T> collection)
        {
            int CountEl = 0;
            foreach (var item in collection)
                CountEl++;
            return CountEl;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            int freecapacity = capacity - Length;
            int newcapacity = CountElCollection(collection) - freecapacity;
            if (capacity < freecapacity + newcapacity)
                Resize(freecapacity + newcapacity);
            int index = Length;
            foreach (var item in collection)
            {
                Array[index] = item;
                length++;
                index++;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return Array.GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }
        public void Add(T elem)
        {
            if (Length == capacity)
                Resize(Length);
            Array[Length] = elem;
            length++;
        }
        protected void Resize(int index)
        {
            if (capacity <= index)
                capacity += index;
            T[] Temp = new T[capacity];
            for (int i = 0; i < Array.Length; i++)
                Temp[i] = Array[i];
            Array = Temp;
        }
        protected void NextSize()
        {
            if (capacity == 0)
                capacity = 8;
            capacity *= 2;
        }
        public bool Remove(T elem)
        {
            T[] tmp = new T[Length];
            bool flag = false;
            int tmp_length = Length;
            int j = 0;
            for (int i = 0; i < tmp_length; i++)
            {
                if (elem.Equals(Array[i]))
                {
                    if (flag == true)
                    {
                        tmp[j] = Array[i];
                        j++;
                    }
                    else
                    {
                        flag = true;
                        length--;
                    }
                }
                else
                {
                    tmp[j] = Array[i];
                    j++;
                }
            }
            Array = tmp;
            return flag;
        }
        protected bool CheckMass(int index)
        {
            if (index > capacity)
                throw new ArgumentOutOfRangeException("Out of bounds array!");
            else if (index > Length)
                return false;
            return true;
        }
        public bool Insert(T elem, int index)
        {
            if (index < 0)
                index = ReturnIndex(index);
            if (CheckMass(index))
            {
                if (Length == capacity)
                    Resize(Length);
                if (index == Length)
                {
                    Add(elem);
                    return true;
                }
                else
                {
                    for (int i = Length - 1; i > index; i--)
                        Array[i + 1] = Array[i];
                    Array[index] = elem;
                    length++;
                    return true;
                }
            }
            return false;
        }
        public int Length
        {
            get { return length; }
            private set { }
        }
        protected void HandResize(int index)
        {
            capacity = index;
            T[] Temp = new T[capacity];
            if (capacity < Length)
            {
                for (int i = 0; i < capacity; i++)
                    Temp[i] = Array[i];
            }
            else
            {
                for (int i = 0; i < Length; i++)
                    Temp[i] = Array[i];
            }
            length = capacity;
            Array = Temp;
        }
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Out of bounds array!");
                else HandResize(value);

            }
        }
        protected int ReturnIndex(int index)
        {
            if (index < 0)
            {
                int offset = Length + index; ;
                while (offset < 0)
                    offset = Length + offset;
                return (offset);
            }
            else return index;
        }
        public T this[int index]
        {

            get
            {
                if (index >= Length)
                    throw new ArgumentOutOfRangeException("Out of bounds array!");
                else
                    return Array[ReturnIndex(index)];
            }
            set
            {
                if (index < 0)
                    index = ReturnIndex(index);
                if (CheckMass(index))
                {
                    if (index == Length)
                        Add(value);
                    else
                        Array[index] = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Out of bounds array!");
            }
        }

        public object Clone()
        {
            return new DynamicArray<T>
            { Array = Array, capacity = capacity, length = length };
        }

        public T[] ToArray()
        {
            return Array;
        }
    }

    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public new IEnumerator GetEnumerator()
        {
            for (int i = 0; i <= Length; i++)
            {
                if (i == Length)
                    i = 0;
                yield return Array[i];
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            CycledDynamicArray<int> NewArray = new CycledDynamicArray<int>();
            Console.WriteLine("Capacity test massive = {0}, Length = {1}", NewArray.Capacity, NewArray.Length);
            Console.WriteLine("Add 5 new element in end test massive");
            for (int i = 0; i < 5; i++)
                NewArray.Add(i * 5);
            Console.WriteLine("Capacity after Add element = {0}, Length = {1}", NewArray.Capacity, NewArray.Length);
            Console.Write("Element test massive: ");
            for (int i = 0; i < NewArray.Length; i++)
                Console.Write("{0}  ", NewArray[i]);
            Console.WriteLine();
            foreach (var item in NewArray)
                Console.WriteLine("Item = {0}", item);
        }
    }
}
