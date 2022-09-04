using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack <T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] elements;
        public Stack()
        {
            elements = new T[InitialCapacity];
        }
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (Count == elements.Length)
            {
                Resize();
            }
            elements[Count++] = element;
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            Count--;
            T element = elements[Count - 1];
            if (Count <= elements.Length / 4)
            {
                Shrink();
            }
            return element; 
            
        }
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[Count - 1];
        }
        public void ForEach(Action<T>action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }
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
            return this.GetEnumerator();
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

        private void Resize()
        {
            T[] copyArray = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                copyArray[i] = elements[i];
            }
            elements = copyArray;
        }


       
    }
}
