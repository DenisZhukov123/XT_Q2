using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public class TableUserAward<T>
    {
        private static int size = 8;
        public int Count { get; private set; } = 0;
        private T[,] Table;
        public TableUserAward()
        {
            Table = new T[size, 2];
        }
        public void Add(T UserId, T AwardId)
        {
            if (Count >= size)
                Resize(Count);
            Table[Count, 0] = UserId;
            Table[Count, 1] = AwardId;
            Count++;
        }

        public void Remove(T id)
        {
            T[,] tmp = new T[Count,2];
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                if (!id.Equals(Table[i,0]))
                {
                    tmp[j, 0] = Table[i, 0];
                    tmp[j, 1] = Table[i, 1];
                    j++;
                }
            }
            Table = tmp;
            Count = j;
        }
        private void Resize(int index)
        {
            while (size < index || size == index)
            {
                NextSize();
            }
            T[,] temp = new T[size, 2];
            for (int i = 0; i < Table.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < Table.GetUpperBound(1) + 1; j++)
                    temp[i, j] = Table[i, j];
            }
            Table = temp;
        }

        private void NextSize()
        {
            size *= 2;
        }

        public T this[int index1, int index2]
        {
            get
            {
                return Table[index1, index2];
            }
            set
            {
                Table[index1, index2] = value;
            }
        }
    }
}
