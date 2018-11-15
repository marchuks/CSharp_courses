using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    /* Container class. Uses as an item for linked list*/
    public class Item<T>
    {
        public Item<T> next;
        public Item<T> prev;
        public T data;
    }

    /*  */
    public class CustomList<T>
    {
        private Item<T> _start;
        private int _length;

        public CustomList()
        {
            _start = new Item<T>();
            _length = 0;
        }

        public void Add(T elem)
        {
            Item<T> ptr = _start;

            while (ptr.next != null)
            {
                ptr = ptr.next;
            }

            ptr.data = elem;
            ptr.next = new Item<T>();
            ptr.next.prev = ptr;
            _length++;
        }

        public void Del(int idx)
        {
            if (idx >= _length)
            {
                throw new IndexOutOfRangeException();
            }

            Item<T> ptr = _start;
            for (int i = 0; i < idx; i++)
            {
                ptr = ptr.next;
            }

            ptr.data = default(T);
            ptr.prev.next = ptr.next;
            ptr.next.prev = ptr.prev;
            _length--;
        }

        public T GetByIndex(int idx)
        {
            if (idx >= _length)
            {
                throw new IndexOutOfRangeException();
            }

            Item<T> ptr = _start;
            for (int i = 0; i < idx; i++)
            {
                ptr = ptr.next;
            }

            return ptr.data;
        }

        public void SetByIndex(int idx, T value)
        {
            if (idx >= _length)
            {
                throw new IndexOutOfRangeException();
            }

            Item<T> ptr = _start;
            for (int i = 0; i < idx; i++)
            {
                ptr = ptr.next;
            }

            ptr.data = value;
        }

        public T this[int idx]
        {
            get
            {
                return GetByIndex(idx);
            }
            set
            {
                SetByIndex(idx, value);
            }
        }

        public int getLength()
        {
            return _length;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> myList = new CustomList<string>();
            myList.Add("firtVal");
            myList.Add("secVal");
            myList.Add("thirdVal");
            myList[1] = "newSecVal";
            Console.WriteLine(myList[1]);
            myList.Del(1);
            Console.WriteLine(myList[1]);
            Console.ReadKey();
        }
    }
}
