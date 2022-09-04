using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] elements;
        private const int InitialCapacity = 4;
        public Queue()
        {
            elements = new T[InitialCapacity];
        }

        public int Count { get; private  set; }

        public void Enqueue(T item)
        {
            if (elements.Length==Count)
            {
                Resize();
            }
            elements[Count++] = item;
        }
        public T Dequeue()
        {
            IsEmpty();
            Count--;
            var firstElement = elements[0];
            SwitchElements();
            if (Count <= elements.Length / 4)
            {
                Shrink();
            }
            return firstElement;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
        public T Peek()
        {
            return elements[0];
        }
        public void Clear()
        {
            if (Count==0)
            {
                throw new InvalidOperationException("The collection is empty");
            }
            elements = new T[InitialCapacity];
            
      
        }

        private void Resize()
        {
            T[] copyArray = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                copyArray[i] = elements[i];
            }
            elements = copyArray;
        }
        private void SwitchElements()
        {
            elements[0] = default;
            for (int i = 1; i < elements.Length; i++)
            {
                elements[i - 1] = elements[i];
            }
            elements[elements.Length - 1] = default;
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }
        private void Shrink()
        {
            T[] copyArray = new T[elements.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copyArray[i] = elements[i];
            }
            elements = copyArray;
        }

    }
}
