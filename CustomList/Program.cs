using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

        public void Empty()
        {
            Item<T> ptr = _start;

            while (ptr.next != null)
            {
                ptr = ptr.next;
                ptr.prev.data = default(T);
                ptr.prev= null;
            }
            _length = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Item<T> ptr = _start;

            while (ptr.next != null)
            {
                yield return ptr.data;
                ptr = ptr.next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::CustomList tests::");

            CustomList<string> myList = new CustomList<string>();
            Console.WriteLine("Object creation: " + (myList != null ? "success" : "fail"));

            Console.Write("Try to add 3 objects: ");
            try
            {
                myList.Add("firtVal");
                myList.Add("secVal");
                myList.Add("thirdVal");
                Console.WriteLine("success");
            }
            catch
            {
                Console.WriteLine("fail");
            }

            Console.Write("Set second value by index: ");
            try
            {
                myList[1] = "newSecVal";
                Console.WriteLine("success");
            }
            catch
            {
                Console.WriteLine("fail");
            }

            Console.WriteLine("Get second value by index: ");
            try
            {
                Console.WriteLine("  myList[1] = " + myList[1]);
                Console.WriteLine("Get second value by index: success");
            }
            catch
            {
                Console.WriteLine("Get second value by index: fail");
            }

            /* Removing by index */
            Console.Write("Remove third record by index: ");
            try
            {
                myList.Del(2);
                Console.WriteLine("success");
            }
            catch
            {
                Console.WriteLine("fail");
            }
            Console.WriteLine("Test enumerator: ");
            try
            {
                foreach (var elem in myList)
                {
                    Console.WriteLine("  elem = " + elem);
                }
                Console.WriteLine("Test enumerator: success");
            }
            catch
            {
                Console.WriteLine("Test enumerator: fail");
            }

            Console.Write("Del non-existing index: ");
            try
            {
                myList.Del(11);
                Console.WriteLine("fail");
            }
            catch
            {
                Console.WriteLine("success");
            }

            Console.Write("Access to non-existing index: ");
            try
            {
                myList[11] = "";
                Console.WriteLine("fail");
            }
            catch
            {
                Console.WriteLine("success");
            }

            myList.Empty();
            Console.Write("Empty List: " + (myList.getLength() == 0 ? "success" : "fail"));

            Console.ReadKey();
        }
    }
}