using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3._3_Dynamic_array
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private static int capacity = 0;
        private int length = 0;
        private T[] Array;
   
        public DynamicArray()
        {
            Array = new T[8];
            Capacity = 8; ;
        }
      
        public DynamicArray(int size)
        {
            if (size >= 0)
            {
                Array = new T[size];
                Capacity = size;
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
        private int CountElCollection(IEnumerable<T> collection)
        {
            int CountEl = 0;
            foreach (var item in collection)
                CountEl++;
            return CountEl;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            int freecapacity = Capacity - Length;
            int newcapacity = CountElCollection(collection) - freecapacity;
            if (Capacity < freecapacity + newcapacity)
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
            if (Length == Capacity)
                Resize(Length);
            Array[Length] = elem;
            length++;
        }
        private void Resize(int index)
        {
            if (Capacity <= index)
                Capacity += index;
            T[] Temp = new T[Capacity];
            for (int i = 0; i < Array.Length; i++)
                Temp[i] = Array[i];
            Array = Temp;
        }
        private void NextSize()
        {
            if (Capacity == 0)
                Capacity = 8;
            Capacity *= 2;
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
        private bool CheckMass(int index)
        {
            if (index > Capacity)
                throw new ArgumentOutOfRangeException("Out of bounds array!");
            else if (index > Length)
                return false;
            return true;
        }
        public bool Insert(T elem, int index)
        {
            if (CheckMass(index))
            {
                if (Length == Capacity)
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
            get { return length;}
            private set { }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new ArgumentOutOfRangeException("Out of bounds array!");
                else
                    return Array[index];
            }
            set
            {
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
    }
    class Program
    {
        public static void Main()
        {
            DynamicArray<int> NewArray = new DynamicArray<int>();
            Console.WriteLine("Capacity test massive = {0}, Length = {1}", NewArray.Capacity, NewArray.Length);
            Console.WriteLine("Add 5 new element in end test massive");
            for (int i = 0; i < 5; i++)
                NewArray.Add(i);
            Console.WriteLine("Capacity after Add element = {0}, Length = {1}", NewArray.Capacity, NewArray.Length);
            Console.Write("Element test massive: ");
            for (int i = 0; i < NewArray.Length; i++)
                Console.Write("{0}  ", NewArray[i]);
            Console.WriteLine();
            if(NewArray.Remove(3))
            {
                Console.WriteLine("Capacity after Remove element = {0}, Length = {1}", NewArray.Capacity, NewArray.Length);
                Console.Write("Element test massive: ");
                for (int i = 0; i < NewArray.Length; i++)
                    Console.Write("{0}  ", NewArray[i]);
                Console.WriteLine("");
            }
            else Console.WriteLine("Element test massive don't found");
        }
    }
}
