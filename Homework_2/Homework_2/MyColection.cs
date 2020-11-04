using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class MyColection<T> : IDisposable, IEnumerable<T>, IEnumerator<T>
    {
        private T[] elements = new T[0];
        private int position = -1;

        public T Current {
            get
            {
                return elements[position];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return elements[position];
            }
        }

        public void Dispose()
        {
            position = -1;
        }

        public bool MoveNext()
        {
            position++;
            return position < elements.Length;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Add(T item)
        {

            T[] new_elements = new T[elements.Length + 1];
            for (int i = 0; i < elements.Length; i++)
            {
                new_elements[i] = elements[i];
            }
            new_elements[elements.Length] = item;

            elements = new_elements;

        }

        public void Remove(T item)
        {
            if (Contains(item))
            {
                T[] new_elements = new T[elements.Length - 1];
                int iterator = 0;
                bool delete = false;
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i].Equals(item) && !delete)
                    {
                        delete = true;
                        continue;
                    }
                    new_elements[iterator++] = elements[i];
                }

                elements = new_elements;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < elements.Length)
            {
                T[] new_elements = new T[elements.Length - 1];
                int iterator = 0;
                for (int i = 0; i < elements.Length; i++)
                {
                    if (i==index)
                    {
                        continue;
                    }
                    new_elements[iterator++] = elements[i];
                }

                elements = new_elements;
            }
        }

        public bool Contains(T item)
        {
            foreach (var it in elements)
            {
                if (it.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(int index,T item)
        {
            elements[index] = item;
        }
    }
}

